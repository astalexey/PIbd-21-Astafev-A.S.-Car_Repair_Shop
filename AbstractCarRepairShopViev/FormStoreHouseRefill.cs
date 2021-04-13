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
    public partial class FormStoreHouseRefill : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int StoreHouserId
        {
            get => Convert.ToInt32(storehouseComboBox.SelectedValue);
            set => storehouseComboBox.SelectedValue = value;
        }

        public int ComponentId
        {
            get => Convert.ToInt32(componentComboBox.SelectedValue);
            set => componentComboBox.SelectedValue = value;
        }

        public int Count
        {
            get => Convert.ToInt32(countTextBox.Text);
            set => countTextBox.Text = value.ToString();
        }

        private readonly StoreHouseLogic storehouseLogic;
        public FormStoreHouseRefill(StoreHouseLogic storehouseLogic, ComponentLogic componentLogic)
        {
            InitializeComponent();
            this.storehouseLogic = storehouseLogic;
            List<ComponentViewModel> componentViews = componentLogic.Read(null);
            if (componentViews != null)
            {
                componentComboBox.DisplayMember = "ComponentName";
                componentComboBox.ValueMember = "Id";
                componentComboBox.DataSource = componentViews;
                componentComboBox.SelectedItem = null;
            }

            List<StoreHouseViewModel> storehouseViews = storehouseLogic.Read(null);
            if (storehouseViews != null)
            {
                storehouseComboBox.DisplayMember = "StoreHouseName";
                storehouseComboBox.ValueMember = "Id";
                storehouseComboBox.DataSource = storehouseViews;
                storehouseComboBox.SelectedItem = null;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(countTextBox.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (componentComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (storehouseComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            storehouseLogic.AddComponent(new AddComponentBindingModel
            {
                ComponentId = Convert.ToInt32(componentComboBox.SelectedValue),
                StoreHouseId = Convert.ToInt32(storehouseComboBox.SelectedValue),
                Count = Convert.ToInt32(countTextBox.Text)
            });

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}