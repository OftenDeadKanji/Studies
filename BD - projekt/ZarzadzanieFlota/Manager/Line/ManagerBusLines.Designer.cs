namespace ZarzadzanieFlota
{
    partial class ManagerBusLine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonAddLine = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.linesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.publicTransportDataSet = new ZarzadzanieFlota.PublicTransportDataSet();
            this.buttonShow = new System.Windows.Forms.Button();
            this.linesTableAdapter = new ZarzadzanieFlota.PublicTransportDataSetTableAdapters.LinesTableAdapter();
            this.textBoxNumberFilter = new System.Windows.Forms.TextBox();
            this.comboBoxTypeFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxVehicleType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddLine.Location = new System.Drawing.Point(486, 323);
            this.buttonAddLine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddLine.Name = "buttonAddLine";
            this.buttonAddLine.Size = new System.Drawing.Size(103, 32);
            this.buttonAddLine.TabIndex = 0;
            this.buttonAddLine.Text = "Dodaj nową";
            this.buttonAddLine.UseVisualStyleBackColor = true;
            this.buttonAddLine.Click += new System.EventHandler(this.buttonAddLine_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(9, 323);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(103, 32);
            this.buttonReturn.TabIndex = 6;
            this.buttonReturn.Text = "Powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(126, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(344, 327);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // linesBindingSource
            // 
            this.linesBindingSource.DataMember = "Lines";
            this.linesBindingSource.DataSource = this.publicTransportDataSet;
            // 
            // publicTransportDataSet
            // 
            this.publicTransportDataSet.DataSetName = "PublicTransportDataSet";
            this.publicTransportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonShow
            // 
            this.buttonShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShow.Location = new System.Drawing.Point(486, 287);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(103, 31);
            this.buttonShow.TabIndex = 8;
            this.buttonShow.Text = "Pokaż";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // linesTableAdapter
            // 
            this.linesTableAdapter.ClearBeforeFill = true;
            // 
            // textBoxNumberFilter
            // 
            this.textBoxNumberFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxNumberFilter.Location = new System.Drawing.Point(12, 94);
            this.textBoxNumberFilter.Name = "textBoxNumberFilter";
            this.textBoxNumberFilter.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumberFilter.TabIndex = 9;
            // 
            // comboBoxTypeFilter
            // 
            this.comboBoxTypeFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeFilter.FormattingEnabled = true;
            this.comboBoxTypeFilter.Items.AddRange(new object[] {
            "Wszystkie",
            "Zwykła",
            "Nocna"});
            this.comboBoxTypeFilter.Location = new System.Drawing.Point(12, 180);
            this.comboBoxTypeFilter.Name = "comboBoxTypeFilter";
            this.comboBoxTypeFilter.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTypeFilter.TabIndex = 10;
            this.comboBoxTypeFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Numer linii";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Typ linii";
            // 
            // buttonFind
            // 
            this.buttonFind.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonFind.Location = new System.Drawing.Point(26, 120);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(67, 25);
            this.buttonFind.TabIndex = 13;
            this.buttonFind.Text = "Wyszukaj";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Typ pojazdu";
            // 
            // comboBoxVehicleType
            // 
            this.comboBoxVehicleType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVehicleType.FormattingEnabled = true;
            this.comboBoxVehicleType.Items.AddRange(new object[] {
            "Wszystkie",
            "Autobus",
            "Tramwaj",
            "Trolejbus"});
            this.comboBoxVehicleType.Location = new System.Drawing.Point(12, 241);
            this.comboBoxVehicleType.Name = "comboBoxVehicleType";
            this.comboBoxVehicleType.Size = new System.Drawing.Size(100, 21);
            this.comboBoxVehicleType.TabIndex = 14;
            this.comboBoxVehicleType.SelectedIndexChanged += new System.EventHandler(this.comboBoxVehicleType_SelectedIndexChanged);
            // 
            // ManagerBusLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxVehicleType);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTypeFilter);
            this.Controls.Add(this.textBoxNumberFilter);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonAddLine);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "ManagerBusLine";
            this.Text = "Zarządzanie Flotą - Linie";
            this.Controls.SetChildIndex(this.buttonAddLine, 0);
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.buttonShow, 0);
            this.Controls.SetChildIndex(this.textBoxNumberFilter, 0);
            this.Controls.SetChildIndex(this.comboBoxTypeFilter, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.buttonFind, 0);
            this.Controls.SetChildIndex(this.comboBoxVehicleType, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddLine;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonShow;
        private PublicTransportDataSet publicTransportDataSet;
        private System.Windows.Forms.BindingSource linesBindingSource;
        private PublicTransportDataSetTableAdapters.LinesTableAdapter linesTableAdapter;
        private System.Windows.Forms.TextBox textBoxNumberFilter;
        private System.Windows.Forms.ComboBox comboBoxTypeFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxVehicleType;
    }
}