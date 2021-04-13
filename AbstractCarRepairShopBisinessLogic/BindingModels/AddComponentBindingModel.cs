using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopBisinessLogic.BindingModels
{
    public class AddComponentBindingModel
    {
        public int StoreHouseId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}
