namespace ZarzadzanieFlota
{
    partial class ManagerBusLineShow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.labelLineName = new System.Windows.Forms.Label();
            this.labelRides = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonShowRide = new System.Windows.Forms.Button();
            this.labelType = new System.Windows.Forms.Label();
            this.buttonAddRide = new System.Windows.Forms.Button();
            this.textBoxLineNumber = new System.Windows.Forms.TextBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxWeekday = new System.Windows.Forms.ComboBox();
            this.comboBoxDayType = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxVehicleType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(10, 322);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(93, 32);
            this.buttonReturn.TabIndex = 2;
            this.buttonReturn.Text = "Powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // labelLineName
            // 
            this.labelLineName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLineName.AutoSize = true;
            this.labelLineName.Location = new System.Drawing.Point(24, 37);
            this.labelLineName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLineName.Name = "labelLineName";
            this.labelLineName.Size = new System.Drawing.Size(55, 13);
            this.labelLineName.TabIndex = 4;
            this.labelLineName.Text = "Numer linii";
            // 
            // labelRides
            // 
            this.labelRides.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelRides.AutoSize = true;
            this.labelRides.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRides.Location = new System.Drawing.Point(462, 37);
            this.labelRides.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRides.Name = "labelRides";
            this.labelRides.Size = new System.Drawing.Size(77, 20);
            this.labelRides.TabIndex = 5;
            this.labelRides.Text = "Przejazdy";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonEdit.Location = new System.Drawing.Point(116, 267);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(93, 32);
            this.buttonEdit.TabIndex = 6;
            this.buttonEdit.Text = "Edytuj linię";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonDelete.Location = new System.Drawing.Point(10, 267);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(93, 32);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Usuń linię";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonShowRide
            // 
            this.buttonShowRide.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonShowRide.Location = new System.Drawing.Point(116, 224);
            this.buttonShowRide.Name = "buttonShowRide";
            this.buttonShowRide.Size = new System.Drawing.Size(90, 38);
            this.buttonShowRide.TabIndex = 9;
            this.buttonShowRide.Text = "Pokaż wybrany przejazd";
            this.buttonShowRide.UseVisualStyleBackColor = true;
            this.buttonShowRide.Click += new System.EventHandler(this.buttonShowRide_Click);
            // 
            // labelType
            // 
            this.labelType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(49, 66);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(28, 13);
            this.labelType.TabIndex = 10;
            this.labelType.Text = "Typ:";
            // 
            // buttonAddRide
            // 
            this.buttonAddRide.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonAddRide.Location = new System.Drawing.Point(10, 223);
            this.buttonAddRide.Name = "buttonAddRide";
            this.buttonAddRide.Size = new System.Drawing.Size(90, 38);
            this.buttonAddRide.TabIndex = 11;
            this.buttonAddRide.Text = "Dodaj przejazd";
            this.buttonAddRide.UseVisualStyleBackColor = true;
            this.buttonAddRide.Click += new System.EventHandler(this.buttonAddRide_Click);
            // 
            // textBoxLineNumber
            // 
            this.textBoxLineNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxLineNumber.Enabled = false;
            this.textBoxLineNumber.Location = new System.Drawing.Point(84, 34);
            this.textBoxLineNumber.Name = "textBoxLineNumber";
            this.textBoxLineNumber.ReadOnly = true;
            this.textBoxLineNumber.Size = new System.Drawing.Size(122, 20);
            this.textBoxLineNumber.TabIndex = 13;
            // 
            // textBoxType
            // 
            this.textBoxType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxType.Enabled = false;
            this.textBoxType.Location = new System.Drawing.Point(84, 63);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.ReadOnly = true;
            this.textBoxType.Size = new System.Drawing.Size(122, 20);
            this.textBoxType.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Typ dnia:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 153);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Dzień tygodnia:";
            // 
            // comboBoxWeekday
            // 
            this.comboBoxWeekday.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.comboBoxWeekday.Location = new System.Drawing.Point(89, 150);
            this.comboBoxWeekday.Name = "comboBoxWeekday";
            this.comboBoxWeekday.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWeekday.TabIndex = 17;
            this.comboBoxWeekday.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeekday_SelectedIndexChanged);
            // 
            // comboBoxDayType
            // 
            this.comboBoxDayType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxDayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDayType.FormattingEnabled = true;
            this.comboBoxDayType.Items.AddRange(new object[] {
            "Zwykły",
            "Wakacje",
            "Wielkanoc",
            "Boże Narodzenie",
            "Sylwester"});
            this.comboBoxDayType.Location = new System.Drawing.Point(89, 177);
            this.comboBoxDayType.Name = "comboBoxDayType";
            this.comboBoxDayType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDayType.TabIndex = 18;
            this.comboBoxDayType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDayType_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(241, 66);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(512, 288);
            this.dataGridView.TabIndex = 19;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Typ pojazdu:";
            // 
            // textBoxVehicleType
            // 
            this.textBoxVehicleType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxVehicleType.Enabled = false;
            this.textBoxVehicleType.Location = new System.Drawing.Point(84, 93);
            this.textBoxVehicleType.Name = "textBoxVehicleType";
            this.textBoxVehicleType.ReadOnly = true;
            this.textBoxVehicleType.Size = new System.Drawing.Size(122, 20);
            this.textBoxVehicleType.TabIndex = 21;
            // 
            // ManagerBusLineShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 366);
            this.Controls.Add(this.textBoxVehicleType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.comboBoxDayType);
            this.Controls.Add(this.comboBoxWeekday);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.textBoxLineNumber);
            this.Controls.Add(this.buttonAddRide);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.buttonShowRide);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.labelRides);
            this.Controls.Add(this.labelLineName);
            this.Controls.Add(this.buttonReturn);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "ManagerBusLineShow";
            this.Text = "Zarządzanie Flotą - Linie";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.labelLineName, 0);
            this.Controls.SetChildIndex(this.labelRides, 0);
            this.Controls.SetChildIndex(this.buttonEdit, 0);
            this.Controls.SetChildIndex(this.buttonDelete, 0);
            this.Controls.SetChildIndex(this.buttonShowRide, 0);
            this.Controls.SetChildIndex(this.labelType, 0);
            this.Controls.SetChildIndex(this.buttonAddRide, 0);
            this.Controls.SetChildIndex(this.textBoxLineNumber, 0);
            this.Controls.SetChildIndex(this.textBoxType, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.comboBoxWeekday, 0);
            this.Controls.SetChildIndex(this.comboBoxDayType, 0);
            this.Controls.SetChildIndex(this.dataGridView, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.textBoxVehicleType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Label labelLineName;
        private System.Windows.Forms.Label labelRides;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonShowRide;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Button buttonAddRide;
        private System.Windows.Forms.TextBox textBoxLineNumber;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxWeekday;
        private System.Windows.Forms.ComboBox comboBoxDayType;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVehicleType;
    }
}