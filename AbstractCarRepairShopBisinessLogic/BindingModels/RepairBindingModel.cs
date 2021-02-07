using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopBisinessLogic.BindingModels
{
    /// <summary>
    /// Предоставляемый ремонт в автомастерской
    /// </summary>
    public class RepairBindingModel
    {
        public int? Id { get; set; }
        public string RepairName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> RepairComponents { get; set; }
    }
}
