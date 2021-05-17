using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.HelperModels;
using AbstractCarRepairShopBisinessLogic.Interfaces;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopBisinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IRepairStorage _repairStorage;
        private readonly IOrderStorage _orderStorage;
        public ReportLogic(IRepairStorage repairStorage, IComponentStorage componentStorage, IOrderStorage orderStorage)
        {
            _repairStorage = repairStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportRepairComponentViewModel> GetRepairComponents()
        {
            var compenents = _componentStorage.GetFullList();
            var repairs = _repairStorage.GetFullList();
            var list = new List<ReportRepairComponentViewModel>();
            foreach (var repair in repairs)
            {
                var record = new ReportRepairComponentViewModel
                {
                    RepairName = repair.RepairName,
                    RepairComponents = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var compenent in compenents)
                {
                    if (repair.RepairComponents.ContainsKey(compenent.Id))
                    {
                        record.RepairComponents.Add(new Tuple<string, int>(compenent.ComponentName,
                        repair.RepairComponents[compenent.Id].Item2));
                        record.TotalCount += repair.RepairComponents[compenent.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                RepairName = x.RepairName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение изделий в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveRepairToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список ремонтов",
                Repairs = _repairStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveRepairComponentsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Комоненты по ремонтам",
                RepairComponents = GetRepairComponents()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
