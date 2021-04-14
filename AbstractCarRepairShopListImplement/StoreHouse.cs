using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopListImplement
{
    public class StoreHouse
    {
        public int Id { get; set; }
        public string StoreHouseName { get; set; }
        public string NameOfRepairPerson { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, int> StoreHouseComponents { get; set; }
    }
}
