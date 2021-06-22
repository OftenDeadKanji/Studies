namespace ZarzadzanieFlota
{
    partial class ManagerVehicleShow
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
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxCapacity = new System.Windows.Forms.TextBox();
            this.textBoxSideNumber = new System.Windows.Forms.TextBox();
            this.textBoxRegistrationNumber = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(9, 323);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(92, 32);
            this.buttonReturn.TabIndex = 2;
            this.buttonReturn.Text = "Powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(499, 323);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(92, 32);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Text = "Edytuj";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxType.Enabled = false;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Autobus",
            "Tramwaj",
            "Trolejbus"});
            this.comboBoxType.Location = new System.Drawing.Point(178, 208);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(246, 21);
            this.comboBoxType.TabIndex = 26;
            this.comboBoxType.Text = "Typ pojazdu";
            // 
            // textBoxCapacity
            // 
            this.textBoxCapacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCapacity.Enabled = false;
            this.textBoxCapacity.Location = new System.Drawing.Point(178, 161);
            this.textBoxCapacity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCapacity.Name = "textBoxCapacity";
            this.textBoxCapacity.Size = new System.Drawing.Size(246, 20);
            this.textBoxCapacity.TabIndex = 25;
            this.textBoxCapacity.Text = "Pojemność";
            this.textBoxCapacity.UseWaitCursor = true;
            // 
            // textBoxSideNumber
            // 
            this.textBoxSideNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSideNumber.Enabled = false;
            this.textBoxSideNumber.Location = new System.Drawing.Point(178, 114);
            this.textBoxSideNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSideNumber.Name = "textBoxSideNumber";
            this.textBoxSideNumber.Size = new System.Drawing.Size(246, 20);
            this.textBoxSideNumber.TabIndex = 24;
            this.textBoxSideNumber.Text = "Numer boczny";
            // 
            // textBoxRegistrationNumber
            // 
            this.textBoxRegistrationNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxRegistrationNumber.Enabled = false;
            this.textBoxRegistrationNumber.Location = new System.Drawing.Point(178, 71);
            this.textBoxRegistrationNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRegistrationNumber.Name = "textBoxRegistrationNumber";
            this.textBoxRegistrationNumber.Size = new System.Drawing.Size(246, 20);
            this.textBoxRegistrationNumber.TabIndex = 23;
            this.textBoxRegistrationNumber.Text = "Numer rejestracyjny";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonDelete.Location = new System.Drawing.Point(252, 323);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(92, 32);
            this.buttonDelete.TabIndex = 27;
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // ManagerVehicleShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxCapacity);
            this.Controls.Add(this.textBoxSideNumber);
            this.Controls.Add(this.textBoxRegistrationNumber);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonReturn);
            this.Name = "ManagerVehicleShow";
            this.Text = "Zarządzanie Flotą - Pojazdy";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.buttonEdit, 0);
            this.Controls.SetChildIndex(this.textBoxRegistrationNumber, 0);
            this.Controls.SetChildIndex(this.textBoxSideNumber, 0);
            this.Controls.SetChildIndex(this.textBoxCapacity, 0);
            this.Controls.SetChildIndex(this.comboBoxType, 0);
            this.Controls.SetChildIndex(this.buttonDelete, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxCapacity;
        private System.Windows.Forms.TextBox textBoxSideNumber;
        private System.Windows.Forms.TextBox textBoxRegistrationNumber;
        private System.Windows.Forms.Button buttonDelete;
    }
}