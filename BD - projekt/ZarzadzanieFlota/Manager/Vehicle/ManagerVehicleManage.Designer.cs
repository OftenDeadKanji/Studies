namespace ZarzadzanieFlota
{
    partial class ManagerVehicleManage
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
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxCapacity = new System.Windows.Forms.TextBox();
            this.textBoxSideNumber = new System.Windows.Forms.TextBox();
            this.textBoxRegistrationNumber = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.numericCapacity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Autobus",
            "Tramwaj",
            "Trolejbus"});
            this.comboBoxType.Location = new System.Drawing.Point(170, 216);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(246, 21);
            this.comboBoxType.TabIndex = 22;
            this.comboBoxType.Text = "Typ pojazdu";
            // 
            // textBoxCapacity
            // 
            this.textBoxCapacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCapacity.Location = new System.Drawing.Point(170, 169);
            this.textBoxCapacity.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCapacity.Name = "textBoxCapacity";
            this.textBoxCapacity.ReadOnly = true;
            this.textBoxCapacity.Size = new System.Drawing.Size(120, 20);
            this.textBoxCapacity.TabIndex = 21;
            this.textBoxCapacity.Text = "Pojemność";
            // 
            // textBoxSideNumber
            // 
            this.textBoxSideNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSideNumber.Location = new System.Drawing.Point(170, 122);
            this.textBoxSideNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSideNumber.Name = "textBoxSideNumber";
            this.textBoxSideNumber.Size = new System.Drawing.Size(246, 20);
            this.textBoxSideNumber.TabIndex = 19;
            this.textBoxSideNumber.Text = "Numer boczny";
            // 
            // textBoxRegistrationNumber
            // 
            this.textBoxRegistrationNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxRegistrationNumber.Location = new System.Drawing.Point(170, 79);
            this.textBoxRegistrationNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRegistrationNumber.Name = "textBoxRegistrationNumber";
            this.textBoxRegistrationNumber.Size = new System.Drawing.Size(246, 20);
            this.textBoxRegistrationNumber.TabIndex = 18;
            this.textBoxRegistrationNumber.Text = "Numer rejestracyjny";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.Location = new System.Drawing.Point(499, 323);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(92, 32);
            this.buttonSubmit.TabIndex = 17;
            this.buttonSubmit.Text = "Zapisz";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(9, 323);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(92, 32);
            this.buttonReturn.TabIndex = 16;
            this.buttonReturn.Text = "Powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // numericCapacity
            // 
            this.numericCapacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericCapacity.Location = new System.Drawing.Point(294, 170);
            this.numericCapacity.Margin = new System.Windows.Forms.Padding(2);
            this.numericCapacity.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCapacity.Name = "numericCapacity";
            this.numericCapacity.Size = new System.Drawing.Size(122, 20);
            this.numericCapacity.TabIndex = 23;
            this.numericCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ManagerVehicleManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.numericCapacity);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxCapacity);
            this.Controls.Add(this.textBoxSideNumber);
            this.Controls.Add(this.textBoxRegistrationNumber);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonReturn);
            this.Name = "ManagerVehicleManage";
            this.Text = "Zarządzanie Flotą - Pojazdy";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.buttonSubmit, 0);
            this.Controls.SetChildIndex(this.textBoxRegistrationNumber, 0);
            this.Controls.SetChildIndex(this.textBoxSideNumber, 0);
            this.Controls.SetChildIndex(this.textBoxCapacity, 0);
            this.Controls.SetChildIndex(this.comboBoxType, 0);
            this.Controls.SetChildIndex(this.numericCapacity, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxCapacity;
        private System.Windows.Forms.TextBox textBoxSideNumber;
        private System.Windows.Forms.TextBox textBoxRegistrationNumber;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.NumericUpDown numericCapacity;
    }
}