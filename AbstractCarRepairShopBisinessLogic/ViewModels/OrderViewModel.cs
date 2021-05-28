using AbstractCarRepairShopBisinessLogic.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using AbstractCarRepairShopBisinessLogic.Attributes;

namespace AbstractCarRepairShopBisinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public int RepairId { get; set; }
        [DataMember]
        [Column(title: "Клиент", width: 100)]
        public string ClientFIO { get; set; }
        [DataMember]
        [Column(title: "Исполнитель", width: 100)]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [Column(title: "Ремонт", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string RepairName { get; set; }
        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }
        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
    }
}
