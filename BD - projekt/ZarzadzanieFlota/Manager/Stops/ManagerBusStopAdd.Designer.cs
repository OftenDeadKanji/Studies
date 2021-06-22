namespace ZarzadzanieFlota.Manager
{
    partial class ManagerBusStopAdd
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
            this.district = new System.Windows.Forms.TextBox();
            this.stopName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBusStopName = new System.Windows.Forms.Label();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.available = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.available)).BeginInit();
            this.SuspendLayout();
            // 
            // district
            // 
            this.district.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.district.Location = new System.Drawing.Point(333, 171);
            this.district.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.district.Name = "district";
            this.district.Size = new System.Drawing.Size(251, 22);
            this.district.TabIndex = 21;
            this.district.Text = "<dzielnica>";
            // 
            // stopName
            // 
            this.stopName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stopName.Location = new System.Drawing.Point(333, 126);
            this.stopName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopName.Name = "stopName";
            this.stopName.Size = new System.Drawing.Size(251, 22);
            this.stopName.TabIndex = 20;
            this.stopName.Text = "<nazwa>";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Liczba dostępnych stanowisk";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Dzielnica";
            // 
            // labelBusStopName
            // 
            this.labelBusStopName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBusStopName.AutoSize = true;
            this.labelBusStopName.Location = new System.Drawing.Point(273, 129);
            this.labelBusStopName.Name = "labelBusStopName";
            this.labelBusStopName.Size = new System.Drawing.Size(50, 17);
            this.labelBusStopName.TabIndex = 17;
            this.labelBusStopName.Text = "Nazwa";
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(15, 398);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(123, 39);
            this.buttonReturn.TabIndex = 25;
            this.buttonReturn.Text = "powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.Location = new System.Drawing.Point(663, 398);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(123, 39);
            this.buttonSubmit.TabIndex = 26;
            this.buttonSubmit.Text = "dodaj";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // available
            // 
            this.available.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.available.Location = new System.Drawing.Point(333, 215);
            this.available.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.available.Name = "available";
            this.available.Size = new System.Drawing.Size(251, 22);
            this.available.TabIndex = 28;
            // 
            // ManagerBusStopAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.available);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.district);
            this.Controls.Add(this.stopName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelBusStopName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManagerBusStopAdd";
            this.Text = "Zarządzanie Flotą - Przystanki";
            this.Controls.SetChildIndex(this.labelBusStopName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.stopName, 0);
            this.Controls.SetChildIndex(this.district, 0);
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.buttonSubmit, 0);
            this.Controls.SetChildIndex(this.available, 0);
            ((System.ComponentModel.ISupportInitialize)(this.available)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox district;
        private System.Windows.Forms.TextBox stopName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBusStopName;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.NumericUpDown available;
    }
}