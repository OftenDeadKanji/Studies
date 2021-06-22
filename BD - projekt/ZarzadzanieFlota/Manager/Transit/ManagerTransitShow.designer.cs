namespace ZarzadzanieFlota
{
    partial class ManagerTransitShow
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
            this.textBoxLastStop = new System.Windows.Forms.TextBox();
            this.textBoxFirstStop = new System.Windows.Forms.TextBox();
            this.textBoxLine = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStartTime = new System.Windows.Forms.TextBox();
            this.textBoxWeekday = new System.Windows.Forms.TextBox();
            this.textBoxDayType = new System.Windows.Forms.TextBox();
            this.textBoxCapacity = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxLastStop
            // 
            this.textBoxLastStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLastStop.Enabled = false;
            this.textBoxLastStop.Location = new System.Drawing.Point(238, 152);
            this.textBoxLastStop.Name = "textBoxLastStop";
            this.textBoxLastStop.Size = new System.Drawing.Size(278, 20);
            this.textBoxLastStop.TabIndex = 47;
            // 
            // textBoxFirstStop
            // 
            this.textBoxFirstStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFirstStop.Enabled = false;
            this.textBoxFirstStop.Location = new System.Drawing.Point(238, 118);
            this.textBoxFirstStop.Name = "textBoxFirstStop";
            this.textBoxFirstStop.Size = new System.Drawing.Size(278, 20);
            this.textBoxFirstStop.TabIndex = 46;
            // 
            // textBoxLine
            // 
            this.textBoxLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLine.Enabled = false;
            this.textBoxLine.Location = new System.Drawing.Point(238, 83);
            this.textBoxLine.Name = "textBoxLine";
            this.textBoxLine.Size = new System.Drawing.Size(72, 20);
            this.textBoxLine.TabIndex = 45;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(502, 354);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(93, 44);
            this.buttonEdit.TabIndex = 41;
            this.buttonEdit.Text = "Edytuj";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBack.Location = new System.Drawing.Point(12, 411);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(91, 44);
            this.buttonBack.TabIndex = 40;
            this.buttonBack.Text = "Powrót";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Preferowana pojemność:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Typ dnia:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Dzień tygodnia:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Godzina startu:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Przystanek końcowy:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Przystanek początkowy:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Linia:";
            // 
            // textBoxStartTime
            // 
            this.textBoxStartTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxStartTime.Enabled = false;
            this.textBoxStartTime.Location = new System.Drawing.Point(238, 220);
            this.textBoxStartTime.Name = "textBoxStartTime";
            this.textBoxStartTime.Size = new System.Drawing.Size(108, 20);
            this.textBoxStartTime.TabIndex = 48;
            // 
            // textBoxWeekday
            // 
            this.textBoxWeekday.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxWeekday.Enabled = false;
            this.textBoxWeekday.Location = new System.Drawing.Point(238, 258);
            this.textBoxWeekday.Name = "textBoxWeekday";
            this.textBoxWeekday.Size = new System.Drawing.Size(108, 20);
            this.textBoxWeekday.TabIndex = 49;
            // 
            // textBoxDayType
            // 
            this.textBoxDayType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDayType.Enabled = false;
            this.textBoxDayType.Location = new System.Drawing.Point(238, 289);
            this.textBoxDayType.Name = "textBoxDayType";
            this.textBoxDayType.Size = new System.Drawing.Size(108, 20);
            this.textBoxDayType.TabIndex = 50;
            // 
            // textBoxCapacity
            // 
            this.textBoxCapacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCapacity.Enabled = false;
            this.textBoxCapacity.Location = new System.Drawing.Point(238, 327);
            this.textBoxCapacity.Name = "textBoxCapacity";
            this.textBoxCapacity.Size = new System.Drawing.Size(108, 20);
            this.textBoxCapacity.TabIndex = 51;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(502, 411);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(93, 44);
            this.buttonDelete.TabIndex = 52;
            this.buttonDelete.Text = "Usuń";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(195, 191);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Trasa:";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(238, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 20);
            this.button1.TabIndex = 54;
            this.button1.Text = "Pokaż trasę";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ManagerTransitShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 462);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxCapacity);
            this.Controls.Add(this.textBoxDayType);
            this.Controls.Add(this.textBoxWeekday);
            this.Controls.Add(this.textBoxStartTime);
            this.Controls.Add(this.textBoxLastStop);
            this.Controls.Add(this.textBoxFirstStop);
            this.Controls.Add(this.textBoxLine);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManagerTransitShow";
            this.Text = "Zarządzanie Flotą - Przejazdy";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.buttonBack, 0);
            this.Controls.SetChildIndex(this.buttonEdit, 0);
            this.Controls.SetChildIndex(this.textBoxLine, 0);
            this.Controls.SetChildIndex(this.textBoxFirstStop, 0);
            this.Controls.SetChildIndex(this.textBoxLastStop, 0);
            this.Controls.SetChildIndex(this.textBoxStartTime, 0);
            this.Controls.SetChildIndex(this.textBoxWeekday, 0);
            this.Controls.SetChildIndex(this.textBoxDayType, 0);
            this.Controls.SetChildIndex(this.textBoxCapacity, 0);
            this.Controls.SetChildIndex(this.buttonDelete, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLastStop;
        private System.Windows.Forms.TextBox textBoxFirstStop;
        private System.Windows.Forms.TextBox textBoxLine;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStartTime;
        private System.Windows.Forms.TextBox textBoxWeekday;
        private System.Windows.Forms.TextBox textBoxDayType;
        private System.Windows.Forms.TextBox textBoxCapacity;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}