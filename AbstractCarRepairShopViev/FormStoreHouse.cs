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
    public partial class FormStoreHouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private int? id;

        public int Id
        {
            set => id = value;
        }

        private readonly StoreHouseLogic logic;

        private Dictionary<int, (string, int)> storeHouseComponents;
        public FormStoreHouse(StoreHouseLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormStoreHouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    StoreHouseViewModel view = logic.Read(
                        new StoreHouseBindingModel
                        {
                            Id = id.Value
                        })?[0];

                    if (view != null)
                    {
                        nameOfStoreHouseTextBox.Text = view.StoreHouseName;
                        nameOfRepairTextBox.Text = view.NameOfRepairPerson;
                        storeHouseComponents = view.StoreHouseComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                storeHouseComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (storeHouseComponents != null)
                {
                    componentsDataGridView.Rows.Clear();
                    foreach (KeyValuePair<int, (string, int)> storehouseComponent in storeHouseComponents)
                    {
                        componentsDataGridView.Rows.Add(new object[] { storehouseComponent.Key, storehouseComponent.Value.Item1,
                        storehouseComponent.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameOfStoreHouseTextBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(nameOfStoreHouseTextBox.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.CreateOrUpdate(new StoreHouseBindingModel
                {
                    Id = id,
                    StoreHouseName = nameOfStoreHouseTextBox.Text,
                    NameOfRepairPerson = nameOfRepairTextBox.Text,
                    StoreHouseComponents = storeHouseComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
