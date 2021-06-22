namespace ZarzadzanieFlota
{
    partial class ManagerCourseManage
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.textBoxTransit = new System.Windows.Forms.TextBox();
            this.textBoxVehicle = new System.Windows.Forms.TextBox();
            this.textBoxDriver = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(384, 132);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 20);
            this.button2.TabIndex = 32;
            this.button2.Text = "Zmień";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(384, 92);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 20);
            this.button1.TabIndex = 31;
            this.button1.Text = "Zmień";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxDate
            // 
            this.textBoxDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDate.Enabled = false;
            this.textBoxDate.Location = new System.Drawing.Point(187, 205);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.ReadOnly = true;
            this.textBoxDate.Size = new System.Drawing.Size(192, 20);
            this.textBoxDate.TabIndex = 30;
            // 
            // textBoxTransit
            // 
            this.textBoxTransit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxTransit.Enabled = false;
            this.textBoxTransit.Location = new System.Drawing.Point(187, 167);
            this.textBoxTransit.Name = "textBoxTransit";
            this.textBoxTransit.ReadOnly = true;
            this.textBoxTransit.Size = new System.Drawing.Size(192, 20);
            this.textBoxTransit.TabIndex = 29;
            // 
            // textBoxVehicle
            // 
            this.textBoxVehicle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxVehicle.Location = new System.Drawing.Point(187, 129);
            this.textBoxVehicle.Name = "textBoxVehicle";
            this.textBoxVehicle.Size = new System.Drawing.Size(192, 20);
            this.textBoxVehicle.TabIndex = 28;
            // 
            // textBoxDriver
            // 
            this.textBoxDriver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDriver.Location = new System.Drawing.Point(187, 92);
            this.textBoxDriver.Name = "textBoxDriver";
            this.textBoxDriver.Size = new System.Drawing.Size(192, 20);
            this.textBoxDriver.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Data";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Linia i trasa:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Pojazd:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Kierowca:";
            // 
            // delete
            // 
            this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delete.Location = new System.Drawing.Point(341, 289);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(92, 32);
            this.delete.TabIndex = 22;
            this.delete.Text = "Usuń";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.Location = new System.Drawing.Point(438, 290);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(92, 32);
            this.buttonSubmit.TabIndex = 21;
            this.buttonSubmit.Text = "Zatwierdź";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(11, 290);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(92, 32);
            this.buttonReturn.TabIndex = 20;
            this.buttonReturn.Text = "Powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // ManagerCourseManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 333);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.textBoxTransit);
            this.Controls.Add(this.textBoxVehicle);
            this.Controls.Add(this.textBoxDriver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonReturn);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "ManagerCourseManage";
            this.Text = "Zarządzanie Flotą - Kursy";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.buttonSubmit, 0);
            this.Controls.SetChildIndex(this.delete, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBoxDriver, 0);
            this.Controls.SetChildIndex(this.textBoxVehicle, 0);
            this.Controls.SetChildIndex(this.textBoxTransit, 0);
            this.Controls.SetChildIndex(this.textBoxDate, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.TextBox textBoxTransit;
        private System.Windows.Forms.TextBox textBoxVehicle;
        private System.Windows.Forms.TextBox textBoxDriver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonReturn;
    }
}