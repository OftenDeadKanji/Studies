namespace ZarzadzanieFlota
{
    partial class ManagerBusStopsManage
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
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.district = new System.Windows.Forms.TextBox();
            this.stopName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBusStopName = new System.Windows.Forms.Label();
            this.numericAvailable = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.Location = new System.Drawing.Point(499, 323);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(92, 32);
            this.buttonSubmit.TabIndex = 15;
            this.buttonSubmit.Text = "zapisz";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(9, 323);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(92, 32);
            this.buttonReturn.TabIndex = 14;
            this.buttonReturn.Text = "powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // district
            // 
            this.district.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.district.Location = new System.Drawing.Point(250, 144);
            this.district.Name = "district";
            this.district.Size = new System.Drawing.Size(189, 20);
            this.district.TabIndex = 21;
            this.district.Text = "<dzielnica>";
            // 
            // stopName
            // 
            this.stopName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stopName.Location = new System.Drawing.Point(250, 107);
            this.stopName.Name = "stopName";
            this.stopName.Size = new System.Drawing.Size(189, 20);
            this.stopName.TabIndex = 20;
            this.stopName.Text = "<nazwa>";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Dostępne stanowiska";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Dzielnica";
            // 
            // labelBusStopName
            // 
            this.labelBusStopName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBusStopName.AutoSize = true;
            this.labelBusStopName.Location = new System.Drawing.Point(205, 110);
            this.labelBusStopName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBusStopName.Name = "labelBusStopName";
            this.labelBusStopName.Size = new System.Drawing.Size(40, 13);
            this.labelBusStopName.TabIndex = 17;
            this.labelBusStopName.Text = "Nazwa";
            // 
            // numericAvailable
            // 
            this.numericAvailable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericAvailable.Location = new System.Drawing.Point(251, 177);
            this.numericAvailable.Name = "numericAvailable";
            this.numericAvailable.Size = new System.Drawing.Size(188, 20);
            this.numericAvailable.TabIndex = 22;
            // 
            // ManagerBusStopsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.numericAvailable);
            this.Controls.Add(this.district);
            this.Controls.Add(this.stopName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelBusStopName);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonReturn);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "ManagerBusStopsManage";
            this.Text = "Zarządzanie Flotą - Przystanki";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.buttonSubmit, 0);
            this.Controls.SetChildIndex(this.labelBusStopName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.stopName, 0);
            this.Controls.SetChildIndex(this.district, 0);
            this.Controls.SetChildIndex(this.numericAvailable, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericAvailable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.TextBox district;
        private System.Windows.Forms.TextBox stopName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBusStopName;
        private System.Windows.Forms.NumericUpDown numericAvailable;
    }
}