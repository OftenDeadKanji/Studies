namespace ZarzadzanieFlota
{
    partial class ManagerDrivers
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
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.driversBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.publicTransportDataSet = new ZarzadzanieFlota.PublicTransportDataSet();
            this.driversTableAdapter = new ZarzadzanieFlota.PublicTransportDataSetTableAdapters.DriversTableAdapter();
            this.surnameToSearch = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.nameToSearch = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.driversBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.driversBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driversBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(9, 323);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(92, 32);
            this.buttonReturn.TabIndex = 1;
            this.buttonReturn.Text = "powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonShow
            // 
            this.buttonShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShow.Location = new System.Drawing.Point(505, 323);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(83, 30);
            this.buttonShow.TabIndex = 2;
            this.buttonShow.Text = "Pokaż";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // driversBindingSource
            // 
            this.driversBindingSource.DataMember = "Drivers";
            this.driversBindingSource.DataSource = this.publicTransportDataSet;
            // 
            // publicTransportDataSet
            // 
            this.publicTransportDataSet.DataSetName = "PublicTransportDataSet";
            this.publicTransportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // driversTableAdapter
            // 
            this.driversTableAdapter.ClearBeforeFill = true;
            // 
            // surnameToSearch
            // 
            this.surnameToSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.surnameToSearch.AutoSize = true;
            this.surnameToSearch.Location = new System.Drawing.Point(48, 64);
            this.surnameToSearch.Name = "surnameToSearch";
            this.surnameToSearch.Size = new System.Drawing.Size(56, 13);
            this.surnameToSearch.TabIndex = 15;
            this.surnameToSearch.Text = "Nazwisko:";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxName.Location = new System.Drawing.Point(107, 35);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(186, 20);
            this.textBoxName.TabIndex = 11;
            // 
            // nameToSearch
            // 
            this.nameToSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nameToSearch.AutoSize = true;
            this.nameToSearch.Location = new System.Drawing.Point(74, 37);
            this.nameToSearch.Name = "nameToSearch";
            this.nameToSearch.Size = new System.Drawing.Size(29, 13);
            this.nameToSearch.TabIndex = 13;
            this.nameToSearch.Text = "Imię:";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxSurname.Location = new System.Drawing.Point(107, 61);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(186, 20);
            this.textBoxSurname.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(124, 92);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(364, 245);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // driversBindingSource1
            // 
            this.driversBindingSource1.DataMember = "Drivers";
            this.driversBindingSource1.DataSource = this.publicTransportDataSet;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSearch.Location = new System.Drawing.Point(298, 35);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 43);
            this.buttonSearch.TabIndex = 16;
            this.buttonSearch.Text = "Szukaj";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Autobus",
            "Tramwaj",
            "Trolejbus",
            "Wszystkie"});
            this.comboBoxType.Location = new System.Drawing.Point(403, 59);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(159, 21);
            this.comboBoxType.TabIndex = 17;
            this.comboBoxType.Text = "Wszystkie";
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Typ pojazdu";
            // 
            // ManagerDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.surnameToSearch);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.nameToSearch);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonReturn);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "ManagerDrivers";
            this.Text = "Zarządzanie Flotą - Kierowcy";
            this.Load += new System.EventHandler(this.ManagerDrivers_Load);
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.buttonShow, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.textBoxName, 0);
            this.Controls.SetChildIndex(this.nameToSearch, 0);
            this.Controls.SetChildIndex(this.textBoxSurname, 0);
            this.Controls.SetChildIndex(this.surnameToSearch, 0);
            this.Controls.SetChildIndex(this.buttonSearch, 0);
            this.Controls.SetChildIndex(this.comboBoxType, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.driversBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driversBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonShow;
        private PublicTransportDataSet publicTransportDataSet;
        private System.Windows.Forms.BindingSource driversBindingSource;
        private PublicTransportDataSetTableAdapters.DriversTableAdapter driversTableAdapter;
        private System.Windows.Forms.Label surnameToSearch;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label nameToSearch;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource driversBindingSource1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label1;
    }
}