namespace ZarzadzanieFlota
{
    partial class ManagerCourseCreate
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
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.addVehicles = new System.Windows.Forms.CheckBox();
            this.addDrivers = new System.Windows.Forms.CheckBox();
            this.buttonGen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(9, 309);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(92, 32);
            this.buttonReturn.TabIndex = 2;
            this.buttonReturn.Text = "powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.ButtonReturn_Click);
            // 
            // startDate
            // 
            this.startDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startDate.CustomFormat = "dd-mm-yyyy";
            this.startDate.Location = new System.Drawing.Point(188, 71);
            this.startDate.Margin = new System.Windows.Forms.Padding(2);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(260, 20);
            this.startDate.TabIndex = 29;
            this.startDate.Value = new System.DateTime(2020, 6, 21, 0, 0, 0, 0);
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // endDate
            // 
            this.endDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.endDate.CustomFormat = "dd-mm-yyyy";
            this.endDate.Location = new System.Drawing.Point(188, 132);
            this.endDate.Margin = new System.Windows.Forms.Padding(2);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(260, 20);
            this.endDate.TabIndex = 30;
            this.endDate.Value = new System.DateTime(2020, 6, 21, 0, 0, 0, 0);
            this.endDate.ValueChanged += new System.EventHandler(this.endDate_ValueChanged);
            // 
            // addVehicles
            // 
            this.addVehicles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addVehicles.AutoSize = true;
            this.addVehicles.Location = new System.Drawing.Point(268, 182);
            this.addVehicles.Name = "addVehicles";
            this.addVehicles.Size = new System.Drawing.Size(101, 17);
            this.addVehicles.TabIndex = 31;
            this.addVehicles.Text = "Dobierz pojazdy";
            this.addVehicles.UseVisualStyleBackColor = true;
            this.addVehicles.CheckedChanged += new System.EventHandler(this.addVehicles_CheckedChanged);
            // 
            // addDrivers
            // 
            this.addDrivers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addDrivers.AutoSize = true;
            this.addDrivers.Location = new System.Drawing.Point(260, 232);
            this.addDrivers.Name = "addDrivers";
            this.addDrivers.Size = new System.Drawing.Size(116, 17);
            this.addDrivers.TabIndex = 32;
            this.addDrivers.Text = "Dobierz kierowców";
            this.addDrivers.UseVisualStyleBackColor = true;
            this.addDrivers.CheckedChanged += new System.EventHandler(this.addDrivers_CheckedChanged);
            // 
            // buttonGen
            // 
            this.buttonGen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGen.Location = new System.Drawing.Point(272, 282);
            this.buttonGen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGen.Name = "buttonGen";
            this.buttonGen.Size = new System.Drawing.Size(92, 32);
            this.buttonGen.TabIndex = 33;
            this.buttonGen.Text = "Generuj";
            this.buttonGen.UseVisualStyleBackColor = true;
            this.buttonGen.Click += new System.EventHandler(this.buttonGen_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Data początkowa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Data końcowa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManagerCourseCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 352);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGen);
            this.Controls.Add(this.addDrivers);
            this.Controls.Add(this.addVehicles);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.buttonReturn);
            this.Name = "ManagerCourseCreate";
            this.Text = "ManagerCourseCreate";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.startDate, 0);
            this.Controls.SetChildIndex(this.endDate, 0);
            this.Controls.SetChildIndex(this.addVehicles, 0);
            this.Controls.SetChildIndex(this.addDrivers, 0);
            this.Controls.SetChildIndex(this.buttonGen, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.CheckBox addVehicles;
        private System.Windows.Forms.CheckBox addDrivers;
        private System.Windows.Forms.Button buttonGen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}