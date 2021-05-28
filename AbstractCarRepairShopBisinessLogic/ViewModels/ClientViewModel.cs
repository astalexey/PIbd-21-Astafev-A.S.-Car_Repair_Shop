using System;
using System.Collections.Generic;
using System.ComponentModel;
using AbstractCarRepairShopBisinessLogic.Attributes;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopBisinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "ФИО клиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Логин", width: 100)]
        public string Email { get; set; }

        [DataMember]
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
    }
}