using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractCarRepairShopBisinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для ремонта
    /// </summary>
    public class ComponentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}
