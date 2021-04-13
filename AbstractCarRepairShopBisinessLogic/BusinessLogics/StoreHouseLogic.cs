using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.Interfaces;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopBisinessLogic.BusinessLogics
{
    public class StoreHouseLogic
    {
        private readonly IStoreHouseStorage _storehouseStorage;
        private readonly IComponentStorage _componentStorage;

        public StoreHouseLogic(IStoreHouseStorage storehouseStorage, IComponentStorage componentStorage)
        {
            _storehouseStorage = storehouseStorage;
            _componentStorage = componentStorage;
        }

        public List<StoreHouseViewModel> Read(StoreHouseBindingModel model)
        {
            if (model == null)
            {
                return _storehouseStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<StoreHouseViewModel> { _storehouseStorage.GetElement(model) };
            }

            return _storehouseStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(StoreHouseBindingModel model)
        {
            StoreHouseViewModel element = _storehouseStorage.GetElement(
                new StoreHouseBindingModel
                {
                    Id = model.Id
                });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже существует склад с идентичным названием");
            }

            if (model.Id.HasValue)
            {
                _storehouseStorage.Update(model);
            }
            else
            {
                _storehouseStorage.Insert(model);
            }
        }

        public void Delete(StoreHouseBindingModel model)
        {
            StoreHouseViewModel element = _storehouseStorage.GetElement(
                new StoreHouseBindingModel
                {
                    Id = model.Id
                });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            _storehouseStorage.Delete(model);
        }

        public void AddComponent(AddComponentBindingModel model)
        {
            StoreHouseViewModel storehouse = _storehouseStorage.GetElement(new StoreHouseBindingModel
            {
                Id = model.StoreHouseId
            });

            ComponentViewModel material = _componentStorage.GetElement(new ComponentBindingModel
            {
                Id = model.ComponentId
            });

            if (storehouse == null)
            {
                throw new Exception("Склад не найден");
            }

            if (material == null)
            {
                throw new Exception("Материал не найден");
            }

            Dictionary<int, (string, int)> storehouseComponents = storehouse.StoreHouseComponents;

            if (storehouseComponents.ContainsKey(model.ComponentId))
            {
                storehouseComponents[model.ComponentId] = (storehouseComponents[model.ComponentId].Item1, storehouseComponents[model.ComponentId].Item2 + model.Count);
            }
            else
            {
                storehouseComponents.Add(model.ComponentId, (material.ComponentName, model.Count));
            }

            _storehouseStorage.Update(new StoreHouseBindingModel
            {
                Id = storehouse.Id,
                StoreHouseName = storehouse.StoreHouseName,
                NameOfRepairPerson = storehouse.NameOfRepairPerson,
                DateCreate = storehouse.DateCreate,
                StoreHouseComponents = storehouseComponents
            });
        }
    }
}
