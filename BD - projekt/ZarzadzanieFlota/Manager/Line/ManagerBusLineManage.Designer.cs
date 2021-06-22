namespace ZarzadzanieFlota
{
    partial class ManagerBusLineManage
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
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.comboBoxVehicleType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.Location = new System.Drawing.Point(499, 323);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(92, 32);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "Zapisz";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Zwykła",
            "Nocna"});
            this.comboBoxType.Location = new System.Drawing.Point(188, 161);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(212, 21);
            this.comboBoxType.TabIndex = 13;
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumber.Location = new System.Drawing.Point(188, 113);
            this.textBoxNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(212, 20);
            this.textBoxNumber.TabIndex = 10;
            this.textBoxNumber.Text = "Numer linii";
            this.textBoxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(9, 323);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(92, 32);
            this.buttonReturn.TabIndex = 9;
            this.buttonReturn.Text = "Powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // comboBoxVehicleType
            // 
            this.comboBoxVehicleType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVehicleType.FormattingEnabled = true;
            this.comboBoxVehicleType.Items.AddRange(new object[] {
            "Autobusowa",
            "Tramwajowa",
            "Trolejbusowa"});
            this.comboBoxVehicleType.Location = new System.Drawing.Point(188, 214);
            this.comboBoxVehicleType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxVehicleType.Name = "comboBoxVehicleType";
            this.comboBoxVehicleType.Size = new System.Drawing.Size(212, 21);
            this.comboBoxVehicleType.TabIndex = 15;
            // 
            // ManagerBusLineManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.comboBoxVehicleType);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.buttonReturn);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "ManagerBusLineManage";
            this.Text = "Zarządzanie Flotą - Linie";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.textBoxNumber, 0);
            this.Controls.SetChildIndex(this.comboBoxType, 0);
            this.Controls.SetChildIndex(this.buttonSubmit, 0);
            this.Controls.SetChildIndex(this.comboBoxVehicleType, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.ComboBox comboBoxVehicleType;
    }
}