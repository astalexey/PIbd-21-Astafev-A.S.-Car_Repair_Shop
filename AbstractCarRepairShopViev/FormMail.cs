﻿using AbstractCarRepairShopBisinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;

namespace AbstractCarRepairShopViev
{
    public partial class FormMail : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MailLogic logic;
        public FormMail(MailLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormMail_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewMail.DataSource = list;
                    dataGridViewMail.Columns[0].Visible = false;
                    dataGridViewMail.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
