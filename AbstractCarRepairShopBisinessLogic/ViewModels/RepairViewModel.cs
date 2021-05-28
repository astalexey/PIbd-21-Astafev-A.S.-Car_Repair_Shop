using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using AbstractCarRepairShopBisinessLogic.Attributes;

namespace AbstractCarRepairShopBisinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    [DataContract]
    public class RepairViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Название ремонта", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string RepairName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> RepairComponents { get; set; }
    }
}
