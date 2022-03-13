using System.ComponentModel;

namespace EDTree2
{
    partial class ChartSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textPercent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textZStep = new System.Windows.Forms.TextBox();
            this.groupValueType = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupRectStyle = new System.Windows.Forms.GroupBox();
            this.radioRectStyleMax = new System.Windows.Forms.RadioButton();
            this.radioRectStyleAverage = new System.Windows.Forms.RadioButton();
            this.radioRectStyleBase = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupValueType.SuspendLayout();
            this.groupRectStyle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textPercent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textZStep);
            this.groupBox1.Controls.Add(this.groupValueType);
            this.groupBox1.Controls.Add(this.groupRectStyle);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 205);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // textPercent
            // 
            this.textPercent.Location = new System.Drawing.Point(122, 109);
            this.textPercent.Name = "textPercent";
            this.textPercent.Size = new System.Drawing.Size(100, 20);
            this.textPercent.TabIndex = 5;
            this.textPercent.TextChanged += new System.EventHandler(this.textPercent_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(18, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Percentage(%)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rect Z Step";
            // 
            // textZStep
            // 
            this.textZStep.Location = new System.Drawing.Point(122, 78);
            this.textZStep.Name = "textZStep";
            this.textZStep.Size = new System.Drawing.Size(100, 20);
            this.textZStep.TabIndex = 2;
            this.textZStep.TextChanged += new System.EventHandler(this.textZStep_TextChanged);
            // 
            // groupValueType
            // 
            this.groupValueType.Controls.Add(this.radioButton5);
            this.groupValueType.Controls.Add(this.radioButton4);
            this.groupValueType.Location = new System.Drawing.Point(6, 145);
            this.groupValueType.Name = "groupValueType";
            this.groupValueType.Size = new System.Drawing.Size(318, 54);
            this.groupValueType.TabIndex = 1;
            this.groupValueType.TabStop = false;
            this.groupValueType.Text = "Y Value Type";
            // 
            // radioButton5
            // 
            this.radioButton5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton5.Location = new System.Drawing.Point(195, 19);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(104, 24);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Log(1/Intensity)";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton4.Location = new System.Drawing.Point(6, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(104, 24);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Intensity";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupRectStyle
            // 
            this.groupRectStyle.Controls.Add(this.radioRectStyleMax);
            this.groupRectStyle.Controls.Add(this.radioRectStyleAverage);
            this.groupRectStyle.Controls.Add(this.radioRectStyleBase);
            this.groupRectStyle.Location = new System.Drawing.Point(6, 9);
            this.groupRectStyle.Name = "groupRectStyle";
            this.groupRectStyle.Size = new System.Drawing.Size(318, 59);
            this.groupRectStyle.TabIndex = 0;
            this.groupRectStyle.TabStop = false;
            this.groupRectStyle.Text = "Rect Style";
            // 
            // radioRectStyleMax
            // 
            this.radioRectStyleMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioRectStyleMax.Location = new System.Drawing.Point(208, 19);
            this.radioRectStyleMax.Name = "radioRectStyleMax";
            this.radioRectStyleMax.Size = new System.Drawing.Size(104, 24);
            this.radioRectStyleMax.TabIndex = 2;
            this.radioRectStyleMax.TabStop = true;
            this.radioRectStyleMax.Text = "Maximum";
            this.radioRectStyleMax.UseVisualStyleBackColor = true;
            this.radioRectStyleMax.CheckedChanged += new System.EventHandler(this.radioRectStyleMax_CheckedChanged);
            // 
            // radioRectStyleAverage
            // 
            this.radioRectStyleAverage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioRectStyleAverage.Location = new System.Drawing.Point(116, 19);
            this.radioRectStyleAverage.Name = "radioRectStyleAverage";
            this.radioRectStyleAverage.Size = new System.Drawing.Size(104, 24);
            this.radioRectStyleAverage.TabIndex = 1;
            this.radioRectStyleAverage.TabStop = true;
            this.radioRectStyleAverage.Text = "Average";
            this.radioRectStyleAverage.UseVisualStyleBackColor = true;
            this.radioRectStyleAverage.CheckedChanged += new System.EventHandler(this.radioRectStyleAverage_CheckedChanged);
            // 
            // radioRectStyleBase
            // 
            this.radioRectStyleBase.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioRectStyleBase.Location = new System.Drawing.Point(6, 19);
            this.radioRectStyleBase.Name = "radioRectStyleBase";
            this.radioRectStyleBase.Size = new System.Drawing.Size(104, 24);
            this.radioRectStyleBase.TabIndex = 0;
            this.radioRectStyleBase.TabStop = true;
            this.radioRectStyleBase.Text = "BaseLine";
            this.radioRectStyleBase.UseVisualStyleBackColor = true;
            this.radioRectStyleBase.CheckedChanged += new System.EventHandler(this.radioRectStyleBase_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 211);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonReset);
            this.panel1.Controls.Add(this.buttonApply);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(339, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(82, 205);
            this.panel1.TabIndex = 3;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(3, 145);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 25);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "as Default";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(3, 176);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(3, 32);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(3, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // ChartSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartSettingsForm";
            this.Text = "FmAnalysis_EDTreeData";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupValueType.ResumeLayout(false);
            this.groupRectStyle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonReset;

        private System.Windows.Forms.Button buttonOk;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.TextBox textPercent;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox textZStep;

        private System.Windows.Forms.RadioButton radioRectStyleAverage;
        private System.Windows.Forms.RadioButton radioRectStyleMax;
        private System.Windows.Forms.GroupBox groupValueType;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;

        private System.Windows.Forms.GroupBox groupRectStyle;
        private System.Windows.Forms.RadioButton radioRectStyleBase;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}