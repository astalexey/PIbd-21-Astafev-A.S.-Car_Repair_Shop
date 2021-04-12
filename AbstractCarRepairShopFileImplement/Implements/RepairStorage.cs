using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.Interfaces;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using AbstractCarRepairShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractCarRepairShopFileImplement.Implements
{
    public class RepairStorage : IRepairStorage
    {
        private readonly FileDataListSingleton source;
        public RepairStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<RepairViewModel> GetFullList()
        {
            return source.Repairs.Select(CreateModel).ToList();
        }
        public List<RepairViewModel> GetFilteredList(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Repairs.Where(rec => rec.RepairName.Contains(model.RepairName)).Select(CreateModel).ToList();
        }
        public RepairViewModel GetElement(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            Repair reinforced = source.Repairs.FirstOrDefault(rec => rec.RepairName == model.RepairName || rec.Id == model.Id);
            return reinforced != null ? CreateModel(reinforced) : null;
        }
        public void Insert(RepairBindingModel model)
        {
            int maxId = source.Repairs.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            Repair element = new Repair
            {
                Id = maxId + 1,
                RepairComponents = new Dictionary<int, int>()
            };
            source.Repairs.Add(CreateModel(model, element));
        }
        public void Update(RepairBindingModel model)
        {
            Repair element = source.Repairs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(RepairBindingModel model)
        {
            Repair element = source.Repairs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Repairs.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Repair CreateModel(RepairBindingModel model, Repair reinforced)
        {
            reinforced.RepairName = model.RepairName;
            reinforced.Price = model.Price;
            // удаляем убранные
            foreach (int key in reinforced.RepairComponents.Keys.ToList())
            {
                if (!model.RepairComponents.ContainsKey(key))
                {
                    reinforced.RepairComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (KeyValuePair<int, (string, int)> material in model.RepairComponents)
            {
                if (reinforced.RepairComponents.ContainsKey(material.Key))
                {
                    reinforced.RepairComponents[material.Key] = model.RepairComponents[material.Key].Item2;
                }
                else
                {
                    reinforced.RepairComponents.Add(material.Key, model.RepairComponents[material.Key].Item2);
                }
            }
            return reinforced;
        }
        private RepairViewModel CreateModel(Repair reinforced)
        {
            return new RepairViewModel
            {
                Id = reinforced.Id,
                RepairName = reinforced.RepairName,
                Price = reinforced.Price,
                RepairComponents = reinforced.RepairComponents.ToDictionary(recPC => recPC.Key, recPC =>
                (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
