
namespace AbstractCarRepairShopViev
{
    partial class FormStoreHouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameOfStoreHouseLabel = new System.Windows.Forms.Label();
            this.nameOfResponsibleLabel = new System.Windows.Forms.Label();
            this.nameOfRepairTextBox = new System.Windows.Forms.TextBox();
            this.nameOfStoreHouseTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.componentsDataGridView = new System.Windows.Forms.DataGridView();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.componentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nameOfStoreHouseLabel
            // 
            this.nameOfStoreHouseLabel.AutoSize = true;
            this.nameOfStoreHouseLabel.Location = new System.Drawing.Point(384, 54);
            this.nameOfStoreHouseLabel.Name = "nameOfStoreHouseLabel";
            this.nameOfStoreHouseLabel.Size = new System.Drawing.Size(99, 13);
            this.nameOfStoreHouseLabel.TabIndex = 2;
            this.nameOfStoreHouseLabel.Text = "Название склада:";
            // 
            // nameOfResponsibleLabel
            // 
            this.nameOfResponsibleLabel.AutoSize = true;
            this.nameOfResponsibleLabel.Location = new System.Drawing.Point(384, 15);
            this.nameOfResponsibleLabel.Name = "nameOfResponsibleLabel";
            this.nameOfResponsibleLabel.Size = new System.Drawing.Size(37, 13);
            this.nameOfResponsibleLabel.TabIndex = 1;
            this.nameOfResponsibleLabel.Text = "ФИО:";
            // 
            // nameOfRepairTextBox
            // 
            this.nameOfRepairTextBox.Location = new System.Drawing.Point(387, 31);
            this.nameOfRepairTextBox.Name = "nameOfRepairTextBox";
            this.nameOfRepairTextBox.Size = new System.Drawing.Size(127, 20);
            this.nameOfRepairTextBox.TabIndex = 3;
            // 
            // nameOfStoreHouseTextBox
            // 
            this.nameOfStoreHouseTextBox.Location = new System.Drawing.Point(387, 70);
            this.nameOfStoreHouseTextBox.Name = "nameOfStoreHouseTextBox";
            this.nameOfStoreHouseTextBox.Size = new System.Drawing.Size(127, 20);
            this.nameOfStoreHouseTextBox.TabIndex = 4;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(387, 96);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(127, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(387, 125);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(127, 21);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // componentsDataGridView
            // 
            this.componentsDataGridView.AllowUserToAddRows = false;
            this.componentsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.componentsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.componentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.componentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.material,
            this.count});
            this.componentsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.componentsDataGridView.Name = "componentsDataGridView";
            this.componentsDataGridView.RowHeadersVisible = false;
            this.componentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.componentsDataGridView.Size = new System.Drawing.Size(362, 302);
            this.componentsDataGridView.TabIndex = 0;
            // 
            // count
            // 
            this.count.HeaderText = "Количество";
            this.count.Name = "count";
            // 
            // material
            // 
            this.material.HeaderText = "Материал";
            this.material.Name = "material";
            // 
            // FormStoreHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 326);
            this.Controls.Add(this.componentsDataGridView);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameOfResponsibleLabel);
            this.Controls.Add(this.nameOfStoreHouseLabel);
            this.Controls.Add(this.nameOfStoreHouseTextBox);
            this.Controls.Add(this.nameOfRepairTextBox);
            this.Name = "FormStoreHouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormStoreHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.componentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameOfResponsibleLabel;
        private System.Windows.Forms.Label nameOfStoreHouseLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox nameOfStoreHouseTextBox;
        private System.Windows.Forms.TextBox nameOfRepairTextBox;
        private System.Windows.Forms.DataGridView componentsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn material;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
    }
}