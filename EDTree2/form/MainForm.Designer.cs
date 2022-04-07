namespace EDTree2
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonThreshold = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonDefocus = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            ((System.ComponentModel.ISupportInitialize) (this.mainChart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            this.mainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainChart.Location = new System.Drawing.Point(3, 3);
            this.mainChart.Name = "mainChart";
            this.tableLayoutPanel1.SetRowSpan(this.mainChart, 3);
            this.mainChart.Size = new System.Drawing.Size(777, 825);
            this.mainChart.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(786, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(516, 178);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.Controls.Add(this.mainChart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.14681F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.71119F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1381, 831);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Location = new System.Drawing.Point(786, 187);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(516, 310);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonImport);
            this.panel1.Controls.Add(this.buttonExport);
            this.panel1.Controls.Add(this.buttonThreshold);
            this.panel1.Controls.Add(this.buttonHome);
            this.panel1.Controls.Add(this.buttonDefocus);
            this.panel1.Controls.Add(this.buttonSetting);
            this.panel1.Location = new System.Drawing.Point(1308, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 3);
            this.panel1.Size = new System.Drawing.Size(68, 802);
            this.panel1.TabIndex = 4;
            // 
            // buttonImport
            // 
            this.buttonImport.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonImport.BackgroundImage")));
            this.buttonImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonImport.Location = new System.Drawing.Point(0, 244);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(68, 54);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonExport.BackgroundImage")));
            this.buttonExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExport.Location = new System.Drawing.Point(0, 304);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(68, 54);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonThreshold
            // 
            this.buttonThreshold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonThreshold.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (129)));
            this.buttonThreshold.Location = new System.Drawing.Point(0, 124);
            this.buttonThreshold.Name = "buttonThreshold";
            this.buttonThreshold.Size = new System.Drawing.Size(68, 54);
            this.buttonThreshold.TabIndex = 6;
            this.buttonThreshold.Text = "TH";
            this.buttonThreshold.UseVisualStyleBackColor = true;
            this.buttonThreshold.Click += new System.EventHandler(this.buttonThreshold_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonHome.BackgroundImage")));
            this.buttonHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHome.Location = new System.Drawing.Point(0, 3);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(68, 54);
            this.buttonHome.TabIndex = 4;
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonDefocus
            // 
            this.buttonDefocus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDefocus.Font = new System.Drawing.Font("Gulim", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (129)));
            this.buttonDefocus.Location = new System.Drawing.Point(0, 63);
            this.buttonDefocus.Name = "buttonDefocus";
            this.buttonDefocus.Size = new System.Drawing.Size(68, 54);
            this.buttonDefocus.TabIndex = 5;
            this.buttonDefocus.Text = "Def";
            this.buttonDefocus.UseVisualStyleBackColor = true;
            this.buttonDefocus.Click += new System.EventHandler(this.buttonDefocus_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("buttonSetting.BackgroundImage")));
            this.buttonSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSetting.Location = new System.Drawing.Point(0, 184);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(68, 54);
            this.buttonSetting.TabIndex = 3;
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // listView3
            // 
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.Location = new System.Drawing.Point(786, 503);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(516, 325);
            this.listView3.TabIndex = 5;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 811);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(1381, 20);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "Not found input files.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1381, 831);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainForm";
            this.Text = "EDTree prerelease 0.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.mainChart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListView listView3;

        private System.Windows.Forms.StatusBar statusBar1;

        private System.Windows.Forms.Button buttonImport;

        private System.Windows.Forms.Button buttonExport;

        private System.Windows.Forms.Button buttonDefocus;

        private System.Windows.Forms.Button buttonThreshold;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonHome;

        private System.Windows.Forms.Button buttonSetting;

        private System.Windows.Forms.ListView listView2;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        private System.Windows.Forms.ListView listView1;

        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;

        #endregion
    }
}