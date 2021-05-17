using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AbstractCarRepairShopViev
{
    public partial class FormReportRepairComponents : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportRepairComponents(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormReportRepairComponents_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetRepairComponents();
                if (dict != null)
                {
                    reportRepairComponentsDataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        reportRepairComponentsDataGridView.Rows.Add(new object[] { elem.RepairName, "", "" });
                        foreach (var listElem in elem.RepairComponents)
                        {
                            reportRepairComponentsDataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        reportRepairComponentsDataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        reportRepairComponentsDataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void saveToExcelButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveRepairComponentsToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
