using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.Interfaces;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using AbstractCarRepairShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractCarRepairShopDatabaseImplement.Implements
{
    public class RepairStorage : IRepairStorage
    {
        public List<RepairViewModel> GetFullList()
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                return context.Repairs.Include(rec => rec.RepairComponents).ThenInclude(rec => rec.Component).ToList().Select(rec => new RepairViewModel
                {
                    Id = rec.Id,
                    RepairName = rec.RepairName,
                    Price = rec.Price,
                    RepairComponents = rec.RepairComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                }).ToList();
            }
        }
        public List<RepairViewModel> GetFilteredList(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                return context.Repairs.Include(rec => rec.RepairComponents).ThenInclude(rec => rec.Component)
                .Where(rec => rec.RepairName.Contains(model.RepairName)).ToList().Select(rec => new RepairViewModel
                {
                    Id = rec.Id,
                    RepairName = rec.RepairName,
                    Price = rec.Price,
                    RepairComponents = rec.RepairComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                }).ToList();
            }
        }
        public RepairViewModel GetElement(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Repair repair = context.Repairs.Include(rec => rec.RepairComponents).ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.RepairName == model.RepairName || rec.Id == model.Id);
                return repair != null ? new RepairViewModel
                {
                    Id = repair.Id,
                    RepairName = repair.RepairName,
                    Price = repair.Price,
                    RepairComponents = repair.RepairComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }
        public void Insert(RepairBindingModel model)
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Repair(), context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(RepairBindingModel model)
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Repair element = context.Repairs.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(RepairBindingModel model)
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Repair element = context.Repairs.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Repairs.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Repair CreateModel(RepairBindingModel model, Repair repair, AbstractCarShopDatabase context)
        {
            repair.RepairName = model.RepairName;
            repair.Price = model.Price;
            if (repair.Id == 0)
            {
                context.Repairs.Add(repair);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                List<RepairComponent> reinforcedMaterials = context.RepairComponents.Where(rec => rec.RepairId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.RepairComponents.RemoveRange(reinforcedMaterials.Where(rec => !model.RepairComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (RepairComponent updateMaterial in reinforcedMaterials)
                {
                    updateMaterial.Count = model.RepairComponents[updateMaterial.ComponentId].Item2;
                    model.RepairComponents.Remove(updateMaterial.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (KeyValuePair<int, (string, int)> pc in model.RepairComponents)
            {
                context.RepairComponents.Add(new RepairComponent
                {
                    RepairId = repair.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return repair;
        }
    }
}