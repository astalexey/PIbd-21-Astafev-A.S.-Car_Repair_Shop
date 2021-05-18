using AbstractCarRepairShopBisinessLogic.Attributes;
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
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }
        [Column(title: "Наименование копмонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
