using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.BusinessLogics;
using AbstractCarRepairShopBisinessLogic.ViewModels;
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
    public partial class FormStoreHouses : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly StoreHouseLogic logic;

        public FormStoreHouses(StoreHouseLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void LoadData()
        {
            try
            {
                List<StoreHouseViewModel> list = logic.Read(null);
                if (list != null)
                {
                    storehousesDataGridView.DataSource = list;
                    storehousesDataGridView.Columns[0].Visible = false;
                    storehousesDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    storehousesDataGridView.Columns[4].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormStoreHouses_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addStoreHouseButton_Click(object sender, EventArgs e)
        {
            FormStoreHouse form = Container.Resolve<FormStoreHouse>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void changeStoreHouseButton_Click(object sender, EventArgs e)
        {
            if (storehousesDataGridView.SelectedRows.Count == 1)
            {
                FormStoreHouse form = Container.Resolve<FormStoreHouse>();
                form.Id = Convert.ToInt32(storehousesDataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void deleteStoreHouseButton_Click(object sender, EventArgs e)
        {
            if (storehousesDataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(storehousesDataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new StoreHouseBindingModel
                        {
                            Id = id
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void updateStoreHouseButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
