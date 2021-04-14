using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.Interfaces;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using AbstractCarRepairShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractCarRepairShopDatabaseImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        public List<ComponentViewModel> GetFullList()
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                return context.Components.Select(rec => new ComponentViewModel
                {
                    Id = rec.Id,
                    ComponentName = rec.ComponentName
                }).ToList();
            }
        }
        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                return context.Components.Where(rec => rec.ComponentName.Contains(model.ComponentName)).Select(rec => new ComponentViewModel
                {
                    Id = rec.Id,
                    ComponentName = rec.ComponentName
                }).ToList();
            }
        }
        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Component material = context.Components.FirstOrDefault(rec => rec.ComponentName == model.ComponentName || rec.Id == model.Id);
                return material != null ? new ComponentViewModel
                {
                    Id = material.Id,
                    ComponentName = material.ComponentName
                } : null;
            }
        }
        public void Insert(ComponentBindingModel model)
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                context.Components.Add(CreateModel(model, new Component()));
                context.SaveChanges();
            }
        }
        public void Update(ComponentBindingModel model)
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Component element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(ComponentBindingModel model)
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Component element = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Components.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Component CreateModel(ComponentBindingModel model, Component material)
        {
            material.ComponentName = model.ComponentName;
            return material;
        }
    }
}
