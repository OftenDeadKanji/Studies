namespace ZarzadzanieFlota
{
    partial class ManagerBusStopShow
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
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.labelBusStopName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stopName = new System.Windows.Forms.TextBox();
            this.district = new System.Windows.Forms.TextBox();
            this.available = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(12, 398);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(123, 39);
            this.buttonReturn.TabIndex = 2;
            this.buttonReturn.Text = "powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(665, 398);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(123, 39);
            this.buttonEdit.TabIndex = 7;
            this.buttonEdit.Text = "edytuj";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // labelBusStopName
            // 
            this.labelBusStopName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBusStopName.AutoSize = true;
            this.labelBusStopName.Location = new System.Drawing.Point(260, 113);
            this.labelBusStopName.Name = "labelBusStopName";
            this.labelBusStopName.Size = new System.Drawing.Size(50, 17);
            this.labelBusStopName.TabIndex = 8;
            this.labelBusStopName.Text = "Nazwa";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dzielnica";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Liczba dostępnych stanowisk";
            // 
            // stopName
            // 
            this.stopName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stopName.Location = new System.Drawing.Point(320, 110);
            this.stopName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopName.Name = "stopName";
            this.stopName.ReadOnly = true;
            this.stopName.Size = new System.Drawing.Size(251, 22);
            this.stopName.TabIndex = 11;
            this.stopName.Text = "<nazwa>";
            // 
            // district
            // 
            this.district.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.district.Location = new System.Drawing.Point(320, 155);
            this.district.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.district.Name = "district";
            this.district.ReadOnly = true;
            this.district.Size = new System.Drawing.Size(251, 22);
            this.district.TabIndex = 12;
            this.district.Text = "<dzielnica>";
            // 
            // available
            // 
            this.available.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.available.Location = new System.Drawing.Point(320, 198);
            this.available.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.available.Name = "available";
            this.available.ReadOnly = true;
            this.available.Size = new System.Drawing.Size(251, 22);
            this.available.TabIndex = 13;
            this.available.Text = "<liczba>";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(665, 353);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(123, 39);
            this.buttonDelete.TabIndex = 14;
            this.buttonDelete.Text = "usuń";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // ManagerBusStopShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.available);
            this.Controls.Add(this.district);
            this.Controls.Add(this.stopName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelBusStopName);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonReturn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManagerBusStopShow";
            this.Text = "Zarządzanie Flotą - Przystanki";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.buttonEdit, 0);
            this.Controls.SetChildIndex(this.labelBusStopName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.stopName, 0);
            this.Controls.SetChildIndex(this.district, 0);
            this.Controls.SetChildIndex(this.available, 0);
            this.Controls.SetChildIndex(this.buttonDelete, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label labelBusStopName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stopName;
        private System.Windows.Forms.TextBox district;
        private System.Windows.Forms.TextBox available;
        private System.Windows.Forms.Button buttonDelete;
    }
}