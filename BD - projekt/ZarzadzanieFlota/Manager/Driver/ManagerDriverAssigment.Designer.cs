namespace ZarzadzanieFlota
{
    partial class ManagerDriverAssigments
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
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.textBoxVehicle = new System.Windows.Forms.TextBox();
            this.textBoxDriver = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Przystanek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(12, 400);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(124, 39);
            this.buttonReturn.TabIndex = 30;
            this.buttonReturn.Text = "powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // textBoxDate
            // 
            this.textBoxDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxDate.Location = new System.Drawing.Point(96, 161);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.ReadOnly = true;
            this.textBoxDate.Size = new System.Drawing.Size(142, 22);
            this.textBoxDate.TabIndex = 31;
            // 
            // textBoxVehicle
            // 
            this.textBoxVehicle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxVehicle.Location = new System.Drawing.Point(96, 217);
            this.textBoxVehicle.Name = "textBoxVehicle";
            this.textBoxVehicle.ReadOnly = true;
            this.textBoxVehicle.Size = new System.Drawing.Size(142, 22);
            this.textBoxVehicle.TabIndex = 32;
            // 
            // textBoxDriver
            // 
            this.textBoxDriver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxDriver.Location = new System.Drawing.Point(96, 189);
            this.textBoxDriver.Name = "textBoxDriver";
            this.textBoxDriver.ReadOnly = true;
            this.textBoxDriver.Size = new System.Drawing.Size(142, 22);
            this.textBoxDriver.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "Data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxLine
            // 
            this.textBoxLine.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxLine.Location = new System.Drawing.Point(96, 133);
            this.textBoxLine.Name = "textBoxLine";
            this.textBoxLine.ReadOnly = true;
            this.textBoxLine.Size = new System.Drawing.Size(142, 22);
            this.textBoxLine.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Numer linii";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Kierowca";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Pojazd";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Przystanek,
            this.Time});
            this.dataGridView1.Location = new System.Drawing.Point(322, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(414, 359);
            this.dataGridView1.TabIndex = 39;
            // 
            // Przystanek
            // 
            this.Przystanek.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Przystanek.HeaderText = "Przystanek";
            this.Przystanek.MinimumWidth = 6;
            this.Przystanek.Name = "Przystanek";
            this.Przystanek.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Godzina";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 125;
            // 
            // ManagerDriverTransits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDriver);
            this.Controls.Add(this.textBoxVehicle);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.buttonReturn);
            this.Name = "ManagerDriverTransits";
            this.Text = "ManagerDriverTransits";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.textBoxDate, 0);
            this.Controls.SetChildIndex(this.textBoxVehicle, 0);
            this.Controls.SetChildIndex(this.textBoxDriver, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.textBoxLine, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.TextBox textBoxVehicle;
        private System.Windows.Forms.TextBox textBoxDriver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Przystanek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
    }
}