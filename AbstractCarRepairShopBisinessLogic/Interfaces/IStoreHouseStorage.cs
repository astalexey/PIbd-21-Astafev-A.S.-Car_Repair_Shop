using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopBisinessLogic.Interfaces
{
    public interface IStoreHouseStorage
    {
        List<StoreHouseViewModel> GetFullList();

        List<StoreHouseViewModel> GetFilteredList(StoreHouseBindingModel model);

        StoreHouseViewModel GetElement(StoreHouseBindingModel model);

        void Insert(StoreHouseBindingModel model);

        void Update(StoreHouseBindingModel model);

        void Delete(StoreHouseBindingModel model);
    }
}
