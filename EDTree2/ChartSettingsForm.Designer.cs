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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioCircleMax = new System.Windows.Forms.RadioButton();
            this.radioCircleAverage = new System.Windows.Forms.RadioButton();
            this.radioCircleRight = new System.Windows.Forms.RadioButton();
            this.radioCircleLeft = new System.Windows.Forms.RadioButton();
            this.radioCircleNone = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioFunCubic = new System.Windows.Forms.RadioButton();
            this.radioFunQuadratic = new System.Windows.Forms.RadioButton();
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
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupValueType.SuspendLayout();
            this.groupRectStyle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textZStep);
            this.groupBox1.Controls.Add(this.groupValueType);
            this.groupBox1.Controls.Add(this.groupRectStyle);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 287);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioCircleMax);
            this.groupBox3.Controls.Add(this.radioCircleAverage);
            this.groupBox3.Controls.Add(this.radioCircleRight);
            this.groupBox3.Controls.Add(this.radioCircleLeft);
            this.groupBox3.Controls.Add(this.radioCircleNone);
            this.groupBox3.Location = new System.Drawing.Point(6, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 46);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Circle Style";
            // 
            // radioCircleMax
            // 
            this.radioCircleMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioCircleMax.Location = new System.Drawing.Point(256, 16);
            this.radioCircleMax.Name = "radioCircleMax";
            this.radioCircleMax.Size = new System.Drawing.Size(56, 24);
            this.radioCircleMax.TabIndex = 4;
            this.radioCircleMax.TabStop = true;
            this.radioCircleMax.Text = "Max";
            this.radioCircleMax.UseVisualStyleBackColor = true;
            this.radioCircleMax.CheckedChanged += new System.EventHandler(this.radioCircleMax_CheckedChanged);
            // 
            // radioCircleAverage
            // 
            this.radioCircleAverage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioCircleAverage.Location = new System.Drawing.Point(178, 16);
            this.radioCircleAverage.Name = "radioCircleAverage";
            this.radioCircleAverage.Size = new System.Drawing.Size(72, 24);
            this.radioCircleAverage.TabIndex = 3;
            this.radioCircleAverage.TabStop = true;
            this.radioCircleAverage.Text = "Average";
            this.radioCircleAverage.UseVisualStyleBackColor = true;
            this.radioCircleAverage.CheckedChanged += new System.EventHandler(this.radioCircleAverage_CheckedChanged);
            // 
            // radioCircleRight
            // 
            this.radioCircleRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioCircleRight.Location = new System.Drawing.Point(116, 16);
            this.radioCircleRight.Name = "radioCircleRight";
            this.radioCircleRight.Size = new System.Drawing.Size(56, 24);
            this.radioCircleRight.TabIndex = 2;
            this.radioCircleRight.TabStop = true;
            this.radioCircleRight.Text = "Right";
            this.radioCircleRight.UseVisualStyleBackColor = true;
            this.radioCircleRight.CheckedChanged += new System.EventHandler(this.radioCircleRight_CheckedChanged);
            // 
            // radioCircleLeft
            // 
            this.radioCircleLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioCircleLeft.Location = new System.Drawing.Point(69, 16);
            this.radioCircleLeft.Name = "radioCircleLeft";
            this.radioCircleLeft.Size = new System.Drawing.Size(60, 24);
            this.radioCircleLeft.TabIndex = 1;
            this.radioCircleLeft.TabStop = true;
            this.radioCircleLeft.Text = "Left";
            this.radioCircleLeft.UseVisualStyleBackColor = true;
            this.radioCircleLeft.CheckedChanged += new System.EventHandler(this.radioCircleLeft_CheckedChanged);
            // 
            // radioCircleNone
            // 
            this.radioCircleNone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioCircleNone.Location = new System.Drawing.Point(6, 16);
            this.radioCircleNone.Name = "radioCircleNone";
            this.radioCircleNone.Size = new System.Drawing.Size(66, 24);
            this.radioCircleNone.TabIndex = 0;
            this.radioCircleNone.TabStop = true;
            this.radioCircleNone.Text = "None";
            this.radioCircleNone.UseVisualStyleBackColor = true;
            this.radioCircleNone.CheckedChanged += new System.EventHandler(this.radioCircleNone_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioFunCubic);
            this.groupBox2.Controls.Add(this.radioFunQuadratic);
            this.groupBox2.Location = new System.Drawing.Point(6, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 43);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Function Rank";
            // 
            // radioFunCubic
            // 
            this.radioFunCubic.Location = new System.Drawing.Point(195, 13);
            this.radioFunCubic.Name = "radioFunCubic";
            this.radioFunCubic.Size = new System.Drawing.Size(104, 24);
            this.radioFunCubic.TabIndex = 1;
            this.radioFunCubic.TabStop = true;
            this.radioFunCubic.Text = "Cubic";
            this.radioFunCubic.UseVisualStyleBackColor = true;
            this.radioFunCubic.CheckedChanged += new System.EventHandler(this.radioFunCubic_CheckedChanged);
            // 
            // radioFunQuadratic
            // 
            this.radioFunQuadratic.Location = new System.Drawing.Point(6, 13);
            this.radioFunQuadratic.Name = "radioFunQuadratic";
            this.radioFunQuadratic.Size = new System.Drawing.Size(104, 24);
            this.radioFunQuadratic.TabIndex = 0;
            this.radioFunQuadratic.TabStop = true;
            this.radioFunQuadratic.Text = "Quadratic";
            this.radioFunQuadratic.UseVisualStyleBackColor = true;
            this.radioFunQuadratic.CheckedChanged += new System.EventHandler(this.radioFunQuadratic_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(15, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rect Z Step";
            // 
            // textZStep
            // 
            this.textZStep.Location = new System.Drawing.Point(122, 182);
            this.textZStep.Name = "textZStep";
            this.textZStep.Size = new System.Drawing.Size(100, 20);
            this.textZStep.TabIndex = 2;
            this.textZStep.TextChanged += new System.EventHandler(this.textZStep_TextChanged);
            // 
            // groupValueType
            // 
            this.groupValueType.Controls.Add(this.radioButton5);
            this.groupValueType.Controls.Add(this.radioButton4);
            this.groupValueType.Location = new System.Drawing.Point(6, 227);
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
            this.groupRectStyle.Size = new System.Drawing.Size(318, 46);
            this.groupRectStyle.TabIndex = 0;
            this.groupRectStyle.TabStop = false;
            this.groupRectStyle.Text = "Rect Style";
            // 
            // radioRectStyleMax
            // 
            this.radioRectStyleMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioRectStyleMax.Location = new System.Drawing.Point(208, 12);
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
            this.radioRectStyleAverage.Location = new System.Drawing.Point(116, 12);
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
            this.radioRectStyleBase.Location = new System.Drawing.Point(6, 12);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 293);
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
            this.panel1.Size = new System.Drawing.Size(82, 287);
            this.panel1.TabIndex = 3;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(3, 224);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 25);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "as Default";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(3, 255);
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
            this.ClientSize = new System.Drawing.Size(424, 293);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartSettingsForm";
            this.Text = "FmAnalysis_EDTreeData";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupValueType.ResumeLayout(false);
            this.groupRectStyle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioCircleRight;
        private System.Windows.Forms.RadioButton radioCircleLeft;
        private System.Windows.Forms.RadioButton radioCircleNone;
        private System.Windows.Forms.RadioButton radioCircleAverage;
        private System.Windows.Forms.RadioButton radioCircleMax;

        private System.Windows.Forms.RadioButton radioFunQuadratic;
        private System.Windows.Forms.RadioButton radioFunCubic;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonReset;

        private System.Windows.Forms.Button buttonOk;

        private System.Windows.Forms.Panel panel1;

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