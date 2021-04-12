using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.Interfaces;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using AbstractCarRepairShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractCarRepairShopFileImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        private readonly FileDataListSingleton source;
        public ComponentStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<ComponentViewModel> GetFullList()
        {
            return source.Components.Select(CreateModel).ToList();
        }
        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<ComponentViewModel> result = new List<ComponentViewModel>();
            foreach (var component in source.Components)
            {
                if (component.ComponentName.Contains(model.ComponentName))
                {
                    result.Add(CreateModel(component));
                }
            }
            return result;
        }
        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var component in source.Components)
            {
                if (component.Id == model.Id || component.ComponentName == model.ComponentName)
                {
                    return CreateModel(component);
                }
            }
            return null;
        }
        public void Insert(ComponentBindingModel model)
        {
            Component tempComponent = new Component { Id = 1 };
            foreach (var component in source.Components)
            {
                if (component.Id >= tempComponent.Id)
                {
                    tempComponent.Id = component.Id + 1;
                }
            }
            source.Components.Add(CreateModel(model, tempComponent));
        }
        public void Update(ComponentBindingModel model)
        {
            Component tempComponent = null;
            foreach (var component in source.Components)
            {
                if (component.Id == model.Id)
                {
                    tempComponent = component;
                }
            }
            if (tempComponent == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempComponent);
        }
        public void Delete(ComponentBindingModel model)
        {
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == model.Id.Value)
                {
                    source.Components.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Component CreateModel(ComponentBindingModel model, Component component)
        {
            component.ComponentName = model.ComponentName;
            return component;
        }
        private ComponentViewModel CreateModel(Component component)
        {
            return new ComponentViewModel
            {
                Id = component.Id,
                ComponentName = component.ComponentName
            };
        }
    }
}
