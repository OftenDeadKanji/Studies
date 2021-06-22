namespace ZarzadzanieFlota
{
    partial class PassengerTimetableLine
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
            this.components = new System.ComponentModel.Container();
            this.textBoxLineName = new System.Windows.Forms.TextBox();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Przystanek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopsonrouteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.publicTransportDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.publicTransportDataSet = new ZarzadzanieFlota.PublicTransportDataSet();
            this.stops_on_routeTableAdapter = new ZarzadzanieFlota.PublicTransportDataSetTableAdapters.Stops_on_routeTableAdapter();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.comboBoxTime = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.labelDay = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopsonrouteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLineName
            // 
            this.textBoxLineName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxLineName.Location = new System.Drawing.Point(49, 69);
            this.textBoxLineName.Name = "textBoxLineName";
            this.textBoxLineName.ReadOnly = true;
            this.textBoxLineName.ShortcutsEnabled = false;
            this.textBoxLineName.Size = new System.Drawing.Size(83, 22);
            this.textBoxLineName.TabIndex = 9;
            this.textBoxLineName.Text = "Numer linii";
            this.textBoxLineName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(12, 408);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(120, 30);
            this.buttonReturn.TabIndex = 10;
            this.buttonReturn.Text = "powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(319, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(414, 359);
            this.dataGridView1.TabIndex = 12;
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
            // stopsonrouteBindingSource
            // 
            this.stopsonrouteBindingSource.DataMember = "Stops_on_route";
            this.stopsonrouteBindingSource.DataSource = this.publicTransportDataSetBindingSource;
            // 
            // publicTransportDataSetBindingSource
            // 
            this.publicTransportDataSetBindingSource.DataSource = this.publicTransportDataSet;
            this.publicTransportDataSetBindingSource.Position = 0;
            // 
            // publicTransportDataSet
            // 
            this.publicTransportDataSet.DataSetName = "PublicTransportDataSet";
            this.publicTransportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stops_on_routeTableAdapter
            // 
            this.stops_on_routeTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Zwykły",
            "Wakacje",
            "Wielkanoc",
            "Boże Narodzenie",
            "Sylwester"});
            this.comboBoxType.Location = new System.Drawing.Point(136, 139);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 24);
            this.comboBoxType.TabIndex = 14;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDay.FormattingEnabled = true;
            this.comboBoxDay.Items.AddRange(new object[] {
            "Poniedziałek",
            "Wtorek",
            "Środa",
            "Czwartek",
            "Piątek",
            "Sobota",
            "Niedziela"});
            this.comboBoxDay.Location = new System.Drawing.Point(136, 169);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(121, 24);
            this.comboBoxDay.TabIndex = 15;
            this.comboBoxDay.SelectedIndexChanged += new System.EventHandler(this.comboBoxDay_SelectedIndexChanged);
            // 
            // comboBoxTime
            // 
            this.comboBoxTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTime.FormattingEnabled = true;
            this.comboBoxTime.Location = new System.Drawing.Point(136, 199);
            this.comboBoxTime.Name = "comboBoxTime";
            this.comboBoxTime.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTime.TabIndex = 16;
            this.comboBoxTime.SelectedIndexChanged += new System.EventHandler(this.comboBoxTime_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(65, 142);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(63, 17);
            this.labelType.TabIndex = 20;
            this.labelType.Text = "Typ dnia";
            // 
            // labelDay
            // 
            this.labelDay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDay.AutoSize = true;
            this.labelDay.Location = new System.Drawing.Point(26, 172);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(102, 17);
            this.labelDay.TabIndex = 21;
            this.labelDay.Text = "Dzień tygodnia";
            // 
            // labelTime
            // 
            this.labelTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(67, 206);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(61, 17);
            this.labelTime.TabIndex = 22;
            this.labelTime.Text = "Godzina";
            // 
            // PassengerTimetableLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelDay);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.comboBoxTime);
            this.Controls.Add(this.comboBoxDay);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.textBoxLineName);
            this.Name = "PassengerTimetableLine";
            this.Text = "Pomocnik pasażera - rozkład jazdy";
            this.Controls.SetChildIndex(this.textBoxLineName, 0);
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.comboBoxType, 0);
            this.Controls.SetChildIndex(this.comboBoxDay, 0);
            this.Controls.SetChildIndex(this.comboBoxTime, 0);
            this.Controls.SetChildIndex(this.labelType, 0);
            this.Controls.SetChildIndex(this.labelDay, 0);
            this.Controls.SetChildIndex(this.labelTime, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopsonrouteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxLineName;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource publicTransportDataSetBindingSource;
        private PublicTransportDataSet publicTransportDataSet;
        private System.Windows.Forms.BindingSource stopsonrouteBindingSource;
        private PublicTransportDataSetTableAdapters.Stops_on_routeTableAdapter stops_on_routeTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.ComboBox comboBoxTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Przystanek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
    }
}