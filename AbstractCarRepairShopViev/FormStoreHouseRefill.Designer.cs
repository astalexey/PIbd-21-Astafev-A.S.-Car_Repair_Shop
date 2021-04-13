
namespace AbstractCarRepairShopViev
{
    partial class FormStoreHouseRefill
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
            this.sotrehouseLabel = new System.Windows.Forms.Label();
            this.componentLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.storehouseComboBox = new System.Windows.Forms.ComboBox();
            this.componentComboBox = new System.Windows.Forms.ComboBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sotrehouseLabel
            // 
            this.sotrehouseLabel.AutoSize = true;
            this.sotrehouseLabel.Location = new System.Drawing.Point(27, 9);
            this.sotrehouseLabel.Name = "sotrehouseLabel";
            this.sotrehouseLabel.Size = new System.Drawing.Size(41, 13);
            this.sotrehouseLabel.TabIndex = 0;
            this.sotrehouseLabel.Text = "Склад:";
            // 
            // componentLabel
            // 
            this.componentLabel.AutoSize = true;
            this.componentLabel.Location = new System.Drawing.Point(8, 33);
            this.componentLabel.Name = "componentLabel";
            this.componentLabel.Size = new System.Drawing.Size(66, 13);
            this.componentLabel.TabIndex = 1;
            this.componentLabel.Text = "Компонент:";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(-1, 59);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(69, 13);
            this.countLabel.TabIndex = 2;
            this.countLabel.Text = "Количество:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 82);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(88, 22);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(104, 82);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(81, 22);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // storehouseComboBox
            // 
            this.storehouseComboBox.FormattingEnabled = true;
            this.storehouseComboBox.Location = new System.Drawing.Point(64, 6);
            this.storehouseComboBox.Name = "storehouseComboBox";
            this.storehouseComboBox.Size = new System.Drawing.Size(121, 21);
            this.storehouseComboBox.TabIndex = 5;
            // 
            // componentComboBox
            // 
            this.componentComboBox.FormattingEnabled = true;
            this.componentComboBox.Location = new System.Drawing.Point(64, 30);
            this.componentComboBox.Name = "componentComboBox";
            this.componentComboBox.Size = new System.Drawing.Size(121, 21);
            this.componentComboBox.TabIndex = 6;
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(64, 56);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(121, 20);
            this.countTextBox.TabIndex = 7;
            // 
            // FormStoreHouseRefill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 113);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.componentComboBox);
            this.Controls.Add(this.storehouseComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.componentLabel);
            this.Controls.Add(this.sotrehouseLabel);
            this.Name = "FormStoreHouseRefill";
            this.Text = "Пополнение склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sotrehouseLabel;
        private System.Windows.Forms.Label componentLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox storehouseComboBox;
        private System.Windows.Forms.ComboBox componentComboBox;
        private System.Windows.Forms.TextBox countTextBox;
    }
}