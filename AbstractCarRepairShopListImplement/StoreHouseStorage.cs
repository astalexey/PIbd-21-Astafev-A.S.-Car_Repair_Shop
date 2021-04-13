using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.Interfaces;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopListImplement
{
    public class StoreHouseStorage : IStoreHouseStorage
    {
        private readonly DataListSingleton source;

        public StoreHouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        private StoreHouse CreateModel(StoreHouseBindingModel model, StoreHouse storehouse)
        {
            storehouse.StoreHouseName = model.StoreHouseName;
            storehouse.NameOfRepairPerson = model.NameOfRepairPerson;

            foreach (int key in storehouse.StoreHouseComponents.Keys.ToList())
            {
                if (!model.StoreHouseComponents.ContainsKey(key))
                {
                    storehouse.StoreHouseComponents.Remove(key);
                }
            }

            foreach (KeyValuePair<int, (string, int)> material in model.StoreHouseComponents)
            {
                if (storehouse.StoreHouseComponents.ContainsKey(material.Key))
                {
                    storehouse.StoreHouseComponents[material.Key] =
                        model.StoreHouseComponents[material.Key].Item2;
                }
                else
                {
                    storehouse.StoreHouseComponents.Add(material.Key, model.StoreHouseComponents[material.Key].Item2);
                }
            }

            return storehouse;
        }

        private StoreHouseViewModel CreateModel(StoreHouse storehouse)
        {
            Dictionary<int, (string, int)> storeHouseComponents = new Dictionary<int, (string, int)>();

            foreach (KeyValuePair<int, int> storeHouseComponent in storehouse.StoreHouseComponents)
            {
                string componentName = string.Empty;
                foreach (Component component in source.Components)
                {
                    if (storeHouseComponent.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                storeHouseComponents.Add(storeHouseComponent.Key, (componentName, storeHouseComponent.Value));
            }

            return new StoreHouseViewModel
            {
                Id = storehouse.Id,
                StoreHouseName = storehouse.StoreHouseName,
                NameOfRepairPerson = storehouse.NameOfRepairPerson,
                DateCreate = storehouse.DateCreate,
                StoreHouseComponents = storeHouseComponents
            };
        }

        public void Delete(StoreHouseBindingModel model)
        {
            for (int i = 0; i < source.StoreHouses.Count; ++i)
            {
                if (source.StoreHouses[i].Id == model.Id)
                {
                    source.StoreHouses.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }

        public StoreHouseViewModel GetElement(StoreHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            foreach (StoreHouse storehouse in source.StoreHouses)
            {
                if (storehouse.Id == model.Id)
                {
                    return CreateModel(storehouse);
                }
            }

            return null;
        }

        public List<StoreHouseViewModel> GetFilteredList(StoreHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            List<StoreHouseViewModel> result = new List<StoreHouseViewModel>();
            foreach (StoreHouse storehouse in source.StoreHouses)
            {
                if (storehouse.StoreHouseName.Contains(model.StoreHouseName))
                {
                    result.Add(CreateModel(storehouse));
                }
            }
            return result;
        }

        public List<StoreHouseViewModel> GetFullList()
        {
            List<StoreHouseViewModel> result = new List<StoreHouseViewModel>();
            foreach (StoreHouse storehouse in source.StoreHouses)
            {
                result.Add(CreateModel(storehouse));
            }
            return result;
        }

        public void Insert(StoreHouseBindingModel model)
        {
            StoreHouse tempStoreHouse = new StoreHouse
            {
                Id = 1,
                StoreHouseComponents = new Dictionary<int, int>(),
                DateCreate = DateTime.Now
            };

            foreach (StoreHouse storehouse in source.StoreHouses)
            {
                if (storehouse.Id >= tempStoreHouse.Id)
                {
                    tempStoreHouse.Id = storehouse.Id + 1;
                }
            }

            source.StoreHouses.Add(CreateModel(model, tempStoreHouse));
        }

        public void Update(StoreHouseBindingModel model)
        {
            StoreHouse tempStoreHouse = null;

            foreach (StoreHouse storehouse in source.StoreHouses)
            {
                if (storehouse.Id == model.Id)
                {
                    tempStoreHouse = storehouse;
                }
            }

            if (tempStoreHouse == null)
            {
                throw new Exception("Элемент не найден");
            }

            CreateModel(model, tempStoreHouse);
        }

        public void Print()
        {
            foreach (StoreHouse storehouse in source.StoreHouses)
            {
                Console.WriteLine(storehouse.StoreHouseName + " " + storehouse.NameOfRepairPerson + " " + storehouse.DateCreate);
                foreach (KeyValuePair<int, int> keyValue in storehouse.StoreHouseComponents)
                {
                    string materialName = source.Components.FirstOrDefault(material => material.Id == keyValue.Key).ComponentName;
                    Console.WriteLine(materialName + " " + keyValue.Value);
                }
            }
        }
    }
}
