namespace ZarzadzanieFlota
{
    partial class ManagerDriverLines
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxLine = new System.Windows.Forms.ComboBox();
            this.buttonChoose = new System.Windows.Forms.Button();
            this.linesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.publicTransportDataSet = new ZarzadzanieFlota.PublicTransportDataSet();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.linesTableAdapter = new ZarzadzanieFlota.PublicTransportDataSetTableAdapters.LinesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.linesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Numer linii";
            // 
            // comboBoxLine
            // 
            this.comboBoxLine.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxLine.FormattingEnabled = true;
            this.comboBoxLine.Location = new System.Drawing.Point(283, 204);
            this.comboBoxLine.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLine.Name = "comboBoxLine";
            this.comboBoxLine.Size = new System.Drawing.Size(232, 24);
            this.comboBoxLine.TabIndex = 18;
            // 
            // buttonChoose
            // 
            this.buttonChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChoose.Location = new System.Drawing.Point(635, 401);
            this.buttonChoose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(151, 38);
            this.buttonChoose.TabIndex = 16;
            this.buttonChoose.Text = "Wybierz";
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.buttonChoose_Click);
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
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(12, 400);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(123, 39);
            this.buttonReturn.TabIndex = 14;
            this.buttonReturn.Text = "Powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // linesTableAdapter
            // 
            this.linesTableAdapter.ClearBeforeFill = true;
            // 
            // ManagerDriverLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxLine);
            this.Controls.Add(this.buttonChoose);
            this.Controls.Add(this.buttonReturn);
            this.Name = "ManagerDriverLines";
            this.Text = "ManagerDriverLines";
            this.Load += new System.EventHandler(this.ManagerDriverLines_Load);
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.buttonChoose, 0);
            this.Controls.SetChildIndex(this.comboBoxLine, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.linesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publicTransportDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLine;
        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.Button buttonReturn;
        private PublicTransportDataSet publicTransportDataSet;
        private System.Windows.Forms.BindingSource linesBindingSource;
        private PublicTransportDataSetTableAdapters.LinesTableAdapter linesTableAdapter;
    }
}