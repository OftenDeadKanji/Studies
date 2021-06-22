namespace ZarzadzanieFlota
{
    partial class ManagerTransitManage
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
            this.capacity = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.startMinute = new System.Windows.Forms.NumericUpDown();
            this.startHour = new System.Windows.Forms.NumericUpDown();
            this.textBoxLastStop = new System.Windows.Forms.TextBox();
            this.textBoxFirstStop = new System.Windows.Forms.TextBox();
            this.textBoxLine = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonAddRouteNew = new System.Windows.Forms.Button();
            this.buttonChooseRoute = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxDayType = new System.Windows.Forms.ComboBox();
            this.comboBoxWeekday = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.capacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).BeginInit();
            this.SuspendLayout();
            // 
            // capacity
            // 
            this.capacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.capacity.Location = new System.Drawing.Point(236, 344);
            this.capacity.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.capacity.Name = "capacity";
            this.capacity.Size = new System.Drawing.Size(72, 20);
            this.capacity.TabIndex = 51;
            this.capacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = ":";
            // 
            // startMinute
            // 
            this.startMinute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startMinute.Location = new System.Drawing.Point(314, 234);
            this.startMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.startMinute.Name = "startMinute";
            this.startMinute.Size = new System.Drawing.Size(59, 20);
            this.startMinute.TabIndex = 49;
            this.startMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startHour
            // 
            this.startHour.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startHour.Location = new System.Drawing.Point(236, 234);
            this.startHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.startHour.Name = "startHour";
            this.startHour.Size = new System.Drawing.Size(56, 20);
            this.startHour.TabIndex = 48;
            this.startHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxLastStop
            // 
            this.textBoxLastStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLastStop.Enabled = false;
            this.textBoxLastStop.Location = new System.Drawing.Point(236, 180);
            this.textBoxLastStop.Name = "textBoxLastStop";
            this.textBoxLastStop.Size = new System.Drawing.Size(278, 20);
            this.textBoxLastStop.TabIndex = 47;
            // 
            // textBoxFirstStop
            // 
            this.textBoxFirstStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxFirstStop.Enabled = false;
            this.textBoxFirstStop.Location = new System.Drawing.Point(236, 146);
            this.textBoxFirstStop.Name = "textBoxFirstStop";
            this.textBoxFirstStop.Size = new System.Drawing.Size(278, 20);
            this.textBoxFirstStop.TabIndex = 46;
            // 
            // textBoxLine
            // 
            this.textBoxLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLine.Enabled = false;
            this.textBoxLine.Location = new System.Drawing.Point(236, 44);
            this.textBoxLine.Name = "textBoxLine";
            this.textBoxLine.Size = new System.Drawing.Size(72, 20);
            this.textBoxLine.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Trasa";
            // 
            // buttonAddRouteNew
            // 
            this.buttonAddRouteNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddRouteNew.Location = new System.Drawing.Point(236, 78);
            this.buttonAddRouteNew.Name = "buttonAddRouteNew";
            this.buttonAddRouteNew.Size = new System.Drawing.Size(124, 50);
            this.buttonAddRouteNew.TabIndex = 43;
            this.buttonAddRouteNew.Text = "Dodaj nową";
            this.buttonAddRouteNew.UseVisualStyleBackColor = true;
            this.buttonAddRouteNew.Click += new System.EventHandler(this.buttonAddRouteNew_Click);
            // 
            // buttonChooseRoute
            // 
            this.buttonChooseRoute.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonChooseRoute.Location = new System.Drawing.Point(390, 78);
            this.buttonChooseRoute.Name = "buttonChooseRoute";
            this.buttonChooseRoute.Size = new System.Drawing.Size(124, 50);
            this.buttonChooseRoute.TabIndex = 42;
            this.buttonChooseRoute.Text = "Wybierz istniejącą";
            this.buttonChooseRoute.UseVisualStyleBackColor = true;
            this.buttonChooseRoute.Click += new System.EventHandler(this.buttonChooseRoute_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.Location = new System.Drawing.Point(554, 407);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(93, 44);
            this.buttonSubmit.TabIndex = 41;
            this.buttonSubmit.Text = "Zatwierdź";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 407);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 44);
            this.buttonCancel.TabIndex = 40;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click_1);
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
            this.comboBoxDayType.Location = new System.Drawing.Point(236, 305);
            this.comboBoxDayType.Name = "comboBoxDayType";
            this.comboBoxDayType.Size = new System.Drawing.Size(137, 21);
            this.comboBoxDayType.TabIndex = 39;
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
            this.comboBoxWeekday.Location = new System.Drawing.Point(236, 271);
            this.comboBoxWeekday.Name = "comboBoxWeekday";
            this.comboBoxWeekday.Size = new System.Drawing.Size(137, 21);
            this.comboBoxWeekday.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 346);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Preferowana pojemność:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Typ dnia:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Dzień tygodnia:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Godzina startu:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Przystanek końcowy:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Przystanek początkowy:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Linia:";
            // 
            // ManagerTransitManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 463);
            this.Controls.Add(this.capacity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.startMinute);
            this.Controls.Add(this.startHour);
            this.Controls.Add(this.textBoxLastStop);
            this.Controls.Add(this.textBoxFirstStop);
            this.Controls.Add(this.textBoxLine);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonAddRouteNew);
            this.Controls.Add(this.buttonChooseRoute);
            this.Controls.Add(this.buttonSubmit);
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
            this.Name = "ManagerTransitManage";
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
            this.Controls.SetChildIndex(this.buttonSubmit, 0);
            this.Controls.SetChildIndex(this.buttonChooseRoute, 0);
            this.Controls.SetChildIndex(this.buttonAddRouteNew, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.textBoxLine, 0);
            this.Controls.SetChildIndex(this.textBoxFirstStop, 0);
            this.Controls.SetChildIndex(this.textBoxLastStop, 0);
            this.Controls.SetChildIndex(this.startHour, 0);
            this.Controls.SetChildIndex(this.startMinute, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.capacity, 0);
            ((System.ComponentModel.ISupportInitialize)(this.capacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown capacity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown startMinute;
        private System.Windows.Forms.NumericUpDown startHour;
        private System.Windows.Forms.TextBox textBoxLastStop;
        private System.Windows.Forms.TextBox textBoxFirstStop;
        private System.Windows.Forms.TextBox textBoxLine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonAddRouteNew;
        private System.Windows.Forms.Button buttonChooseRoute;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxDayType;
        private System.Windows.Forms.ComboBox comboBoxWeekday;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}