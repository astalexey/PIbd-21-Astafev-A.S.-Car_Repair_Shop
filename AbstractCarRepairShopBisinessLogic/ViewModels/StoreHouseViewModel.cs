using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopBisinessLogic.ViewModels
{
    public class StoreHouseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название склада")]
        public string StoreHouseName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string NameOfRepairPerson { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StoreHouseComponents { get; set; }
    }
}
