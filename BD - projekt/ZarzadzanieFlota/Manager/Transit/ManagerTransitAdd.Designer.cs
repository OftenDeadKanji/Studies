namespace ZarzadzanieFlota
{
    partial class ManagerTransitAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxWeekday = new System.Windows.Forms.ComboBox();
            this.comboBoxDayType = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAddRouteNew = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLine = new System.Windows.Forms.TextBox();
            this.textBoxFirstStop = new System.Windows.Forms.TextBox();
            this.textBoxLastStop = new System.Windows.Forms.TextBox();
            this.startHour = new System.Windows.Forms.NumericUpDown();
            this.startMinute = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.capacity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Linia:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Przystanek początkowy:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Przystanek końcowy:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Godzina startu:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dzień tygodnia:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Typ dnia:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Preferowana pojemność:";
            // 
            // comboBoxWeekday
            // 
            this.comboBoxWeekday.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxWeekday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWeekday.FormattingEnabled = true;
            this.comboBoxWeekday.Items.AddRange(new object[] {
            "Poniedziałek",
            "Wtorek",
            "Środa",
            "Czwartek",
            "Piątek",
            "Sobota",
            "Niedziela"});
            this.comboBoxWeekday.Location = new System.Drawing.Point(236, 270);
            this.comboBoxWeekday.Name = "comboBoxWeekday";
            this.comboBoxWeekday.Size = new System.Drawing.Size(137, 21);
            this.comboBoxWeekday.TabIndex = 9;
            // 
            // comboBoxDayType
            // 
            this.comboBoxDayType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxDayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDayType.FormattingEnabled = true;
            this.comboBoxDayType.Items.AddRange(new object[] {
            "Zwykły",
            "Wakacje",
            "Wielkanoc",
            "Boże Narodzenie",
            "Sylwester"});
            this.comboBoxDayType.Location = new System.Drawing.Point(236, 304);
            this.comboBoxDayType.Name = "comboBoxDayType";
            this.comboBoxDayType.Size = new System.Drawing.Size(137, 21);
            this.comboBoxDayType.TabIndex = 10;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 425);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 44);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(555, 425);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(93, 44);
            this.buttonAdd.TabIndex = 12;
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(390, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 50);
            this.button1.TabIndex = 13;
            this.button1.Text = "Wybierz istniejącą";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAddRouteNew
            // 
            this.buttonAddRouteNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddRouteNew.Location = new System.Drawing.Point(236, 77);
            this.buttonAddRouteNew.Name = "buttonAddRouteNew";
            this.buttonAddRouteNew.Size = new System.Drawing.Size(124, 50);
            this.buttonAddRouteNew.TabIndex = 14;
            this.buttonAddRouteNew.Text = "Dodaj nową";
            this.buttonAddRouteNew.UseVisualStyleBackColor = true;
            this.buttonAddRouteNew.Click += new System.EventHandler(this.buttonAddRouteNew_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Trasa";
            // 
            // textBoxLine
            // 
            this.textBoxLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLine.Enabled = false;
            this.textBoxLine.Location = new System.Drawing.Point(236, 43);
            this.textBoxLine.Name = "textBoxLine";
            this.textBoxLine.Size = new System.Drawing.Size(72, 20);
            this.textBoxLine.TabIndex = 24;
            // 
            // textBoxFirstStop
            // 
            this.textBoxFirstStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFirstStop.Enabled = false;
            this.textBoxFirstStop.Location = new System.Drawing.Point(236, 145);
            this.textBoxFirstStop.Name = "textBoxFirstStop";
            this.textBoxFirstStop.Size = new System.Drawing.Size(278, 20);
            this.textBoxFirstStop.TabIndex = 25;
            // 
            // textBoxLastStop
            // 
            this.textBoxLastStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLastStop.Enabled = false;
            this.textBoxLastStop.Location = new System.Drawing.Point(236, 179);
            this.textBoxLastStop.Name = "textBoxLastStop";
            this.textBoxLastStop.Size = new System.Drawing.Size(278, 20);
            this.textBoxLastStop.TabIndex = 26;
            // 
            // startHour
            // 
            this.startHour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startHour.Location = new System.Drawing.Point(236, 233);
            this.startHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.startHour.Name = "startHour";
            this.startHour.Size = new System.Drawing.Size(56, 20);
            this.startHour.TabIndex = 27;
            this.startHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startMinute
            // 
            this.startMinute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startMinute.Location = new System.Drawing.Point(314, 233);
            this.startMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.startMinute.Name = "startMinute";
            this.startMinute.Size = new System.Drawing.Size(59, 20);
            this.startMinute.TabIndex = 28;
            this.startMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = ":";
            // 
            // capacity
            // 
            this.capacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.capacity.Location = new System.Drawing.Point(236, 343);
            this.capacity.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.capacity.Name = "capacity";
            this.capacity.Size = new System.Drawing.Size(72, 20);
            this.capacity.TabIndex = 30;
            this.capacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ManagerTransitAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 481);
            this.Controls.Add(this.capacity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.startMinute);
            this.Controls.Add(this.startHour);
            this.Controls.Add(this.textBoxLastStop);
            this.Controls.Add(this.textBoxFirstStop);
            this.Controls.Add(this.textBoxLine);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonAddRouteNew);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxDayType);
            this.Controls.Add(this.comboBoxWeekday);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManagerTransitAdd";
            this.Text = "Zarządzanie Flotą - Przejazdy";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.comboBoxWeekday, 0);
            this.Controls.SetChildIndex(this.comboBoxDayType, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.buttonAdd, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.buttonAddRouteNew, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.textBoxLine, 0);
            this.Controls.SetChildIndex(this.textBoxFirstStop, 0);
            this.Controls.SetChildIndex(this.textBoxLastStop, 0);
            this.Controls.SetChildIndex(this.startHour, 0);
            this.Controls.SetChildIndex(this.startMinute, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.capacity, 0);
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxWeekday;
        private System.Windows.Forms.ComboBox comboBoxDayType;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonAddRouteNew;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLine;
        private System.Windows.Forms.TextBox textBoxFirstStop;
        private System.Windows.Forms.TextBox textBoxLastStop;
        private System.Windows.Forms.NumericUpDown startHour;
        private System.Windows.Forms.NumericUpDown startMinute;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown capacity;
    }
}