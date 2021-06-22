namespace ZarzadzanieFlota
{
    partial class ManagerMainWindow
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
            this.buttonBusLines = new System.Windows.Forms.Button();
            this.buttonVehicles = new System.Windows.Forms.Button();
            this.buttonBusStops = new System.Windows.Forms.Button();
            this.buttonWorkers = new System.Windows.Forms.Button();
            this.buttonCourses = new System.Windows.Forms.Button();
            this.buttonDrivers = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBusLines
            // 
            this.buttonBusLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBusLines.Location = new System.Drawing.Point(3, 3);
            this.buttonBusLines.Name = "buttonBusLines";
            this.buttonBusLines.Size = new System.Drawing.Size(240, 112);
            this.buttonBusLines.TabIndex = 0;
            this.buttonBusLines.Text = "Linie";
            this.buttonBusLines.UseVisualStyleBackColor = true;
            this.buttonBusLines.Click += new System.EventHandler(this.buttonBusLine_Click);
            // 
            // buttonVehicles
            // 
            this.buttonVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVehicles.Location = new System.Drawing.Point(3, 121);
            this.buttonVehicles.Name = "buttonVehicles";
            this.buttonVehicles.Size = new System.Drawing.Size(240, 112);
            this.buttonVehicles.TabIndex = 1;
            this.buttonVehicles.Text = "Pojazdy";
            this.buttonVehicles.UseVisualStyleBackColor = true;
            this.buttonVehicles.Click += new System.EventHandler(this.buttonVehicles_Click);
            // 
            // buttonBusStops
            // 
            this.buttonBusStops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBusStops.Location = new System.Drawing.Point(3, 239);
            this.buttonBusStops.Name = "buttonBusStops";
            this.buttonBusStops.Size = new System.Drawing.Size(240, 113);
            this.buttonBusStops.TabIndex = 2;
            this.buttonBusStops.Text = "Przystanki";
            this.buttonBusStops.UseVisualStyleBackColor = true;
            this.buttonBusStops.Click += new System.EventHandler(this.buttonBusStops_Click);
            // 
            // buttonWorkers
            // 
            this.buttonWorkers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWorkers.Location = new System.Drawing.Point(249, 3);
            this.buttonWorkers.Name = "buttonWorkers";
            this.buttonWorkers.Size = new System.Drawing.Size(241, 112);
            this.buttonWorkers.TabIndex = 3;
            this.buttonWorkers.Text = "Pracownicy";
            this.buttonWorkers.UseVisualStyleBackColor = true;
            this.buttonWorkers.Click += new System.EventHandler(this.buttonRoutes_Click);
            // 
            // buttonCourses
            // 
            this.buttonCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCourses.Location = new System.Drawing.Point(249, 121);
            this.buttonCourses.Name = "buttonCourses";
            this.buttonCourses.Size = new System.Drawing.Size(241, 112);
            this.buttonCourses.TabIndex = 4;
            this.buttonCourses.Text = "Kursy";
            this.buttonCourses.UseVisualStyleBackColor = true;
            this.buttonCourses.Click += new System.EventHandler(this.buttonCourses_Click);
            // 
            // buttonDrivers
            // 
            this.buttonDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDrivers.Location = new System.Drawing.Point(249, 239);
            this.buttonDrivers.Name = "buttonDrivers";
            this.buttonDrivers.Size = new System.Drawing.Size(241, 113);
            this.buttonDrivers.TabIndex = 5;
            this.buttonDrivers.Text = "Kierowcy";
            this.buttonDrivers.UseVisualStyleBackColor = true;
            this.buttonDrivers.Click += new System.EventHandler(this.buttonDrivers_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReturn.Location = new System.Drawing.Point(12, 398);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(123, 40);
            this.buttonReturn.TabIndex = 7;
            this.buttonReturn.Text = "powrót";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonBusLines, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonBusStops, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonDrivers, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonWorkers, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonVehicles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonCourses, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(176, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(493, 355);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // ManagerMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonReturn);
            this.Name = "ManagerMainWindow";
            this.Text = "Zarządzanie Flotą";
            this.Controls.SetChildIndex(this.buttonReturn, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBusLines;
        private System.Windows.Forms.Button buttonVehicles;
        private System.Windows.Forms.Button buttonBusStops;
        private System.Windows.Forms.Button buttonWorkers;
        private System.Windows.Forms.Button buttonCourses;
        private System.Windows.Forms.Button buttonDrivers;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}