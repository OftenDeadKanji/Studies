namespace ZarzadzanieFlota
{
    partial class ManagerTimetableStops
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.linesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.publicTransportDataSet = new ZarzadzanieFlota.PublicTransportDataSet();
            this.linesTableAdapter = new ZarzadzanieFlota.PublicTransportDataSetTableAdapters.LinesTableAdapter();
            this.comboBoxStops = new System.Windows.Forms.ComboBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.buttonPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(9, 332);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(90, 24);
            this.buttonReturn.TabIndex = 4;
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
            this.dataGridView1.Location = new System.Drawing.Point(109, 78);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(402, 245);
            this.dataGridView1.TabIndex = 9;
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
            // linesTableAdapter
            // 
            this.linesTableAdapter.ClearBeforeFill = true;
            // 
            // comboBoxStops
            // 
            this.comboBoxStops.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxStops.FormattingEnabled = true;
            this.comboBoxStops.Location = new System.Drawing.Point(243, 45);
            this.comboBoxStops.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStops.Name = "comboBoxStops";
            this.comboBoxStops.Size = new System.Drawing.Size(268, 21);
            this.comboBoxStops.TabIndex = 10;
            this.comboBoxStops.Text = "Wszystkie";
            this.comboBoxStops.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxType
            // 
            this.textBoxType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxType.Location = new System.Drawing.Point(109, 46);
            this.textBoxType.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.ReadOnly = true;
            this.textBoxType.Size = new System.Drawing.Size(76, 20);
            this.textBoxType.TabIndex = 11;
            this.textBoxType.Text = "Przystanek:";
            this.textBoxType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxType.TextChanged += new System.EventHandler(this.textBoxType_TextChanged);
            // 
            // buttonPDF
            // 
            this.buttonPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPDF.Location = new System.Drawing.Point(488, 331);
            this.buttonPDF.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(101, 24);
            this.buttonPDF.TabIndex = 12;
            this.buttonPDF.Text = "Eksportuj do PDF.";
            this.buttonPDF.UseVisualStyleBackColor = true;
            this.buttonPDF.Click += new System.EventHandler(this.buttonPDF_Click);
            // 
            // ManagerTimetableStops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonPDF);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.comboBoxStops);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonReturn);
            this.Name = "ManagerTimetableStops";
            this.Text = "Pomocnik pasażera - rozkład jazdy";
            this.Load += new System.EventHandler(this.ManagerTimetableStops_Load);
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.comboBoxStops, 0);
            this.Controls.SetChildIndex(this.textBoxType, 0);
            this.Controls.SetChildIndex(this.buttonPDF, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReturn;
        private PublicTransportDataSet publicTransportDataSet;
        private System.Windows.Forms.BindingSource linesBindingSource;
        private PublicTransportDataSetTableAdapters.LinesTableAdapter linesTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxStops;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.Button buttonPDF;
    }
}