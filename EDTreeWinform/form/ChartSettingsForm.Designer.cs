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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textZstepMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textZstepMin = new System.Windows.Forms.TextBox();
            this.checkBoxEquation = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textCircleMaxX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCircleMinX = new System.Windows.Forms.TextBox();
            this.radioCircleMax = new System.Windows.Forms.RadioButton();
            this.radioCircleNone = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioFunCubic = new System.Windows.Forms.RadioButton();
            this.radioFunQuadratic = new System.Windows.Forms.RadioButton();
            this.groupValueType = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textMaxY = new System.Windows.Forms.TextBox();
            this.textMinY = new System.Windows.Forms.TextBox();
            this.checkBoxCustomScale = new System.Windows.Forms.CheckBox();
            this.radioLog = new System.Windows.Forms.RadioButton();
            this.radioIntensity = new System.Windows.Forms.RadioButton();
            this.groupRectStyle = new System.Windows.Forms.GroupBox();
            this.rectMax = new System.Windows.Forms.CheckBox();
            this.rectAvg = new System.Windows.Forms.CheckBox();
            this.rectRight = new System.Windows.Forms.CheckBox();
            this.rectLeft = new System.Windows.Forms.CheckBox();
            this.rectNone = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.checkBoxEquation);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupValueType);
            this.groupBox1.Controls.Add(this.groupRectStyle);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 420);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textZstepMax);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textZstepMin);
            this.groupBox4.Location = new System.Drawing.Point(9, 206);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 44);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rect Z step";
            // 
            // textZstepMax
            // 
            this.textZstepMax.Location = new System.Drawing.Point(241, 17);
            this.textZstepMax.Name = "textZstepMax";
            this.textZstepMax.Size = new System.Drawing.Size(89, 21);
            this.textZstepMax.TabIndex = 5;
            this.textZstepMax.TextChanged += new System.EventHandler(this.textZstepMax_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(189, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Max";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Min";
            // 
            // textZstepMin
            // 
            this.textZstepMin.Location = new System.Drawing.Point(56, 15);
            this.textZstepMin.Name = "textZstepMin";
            this.textZstepMin.Size = new System.Drawing.Size(89, 21);
            this.textZstepMin.TabIndex = 2;
            this.textZstepMin.TextChanged += new System.EventHandler(this.textZstepMin_TextChanged);
            // 
            // checkBoxEquation
            // 
            this.checkBoxEquation.Location = new System.Drawing.Point(9, 265);
            this.checkBoxEquation.Name = "checkBoxEquation";
            this.checkBoxEquation.Size = new System.Drawing.Size(140, 24);
            this.checkBoxEquation.TabIndex = 7;
            this.checkBoxEquation.Text = "Show Equation";
            this.checkBoxEquation.UseVisualStyleBackColor = true;
            this.checkBoxEquation.CheckedChanged += new System.EventHandler(this.checkBoxEquation_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textCircleMaxX);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textCircleMinX);
            this.groupBox3.Controls.Add(this.radioCircleMax);
            this.groupBox3.Controls.Add(this.radioCircleNone);
            this.groupBox3.Location = new System.Drawing.Point(7, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 98);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Circle Style";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(191, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Max X";
            // 
            // textCircleMaxX
            // 
            this.textCircleMaxX.Location = new System.Drawing.Point(243, 59);
            this.textCircleMaxX.Name = "textCircleMaxX";
            this.textCircleMaxX.Size = new System.Drawing.Size(89, 21);
            this.textCircleMaxX.TabIndex = 9;
            this.textCircleMaxX.TextChanged += new System.EventHandler(this.textCircleMaxX_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Min X";
            // 
            // textCircleMinX
            // 
            this.textCircleMinX.Location = new System.Drawing.Point(58, 59);
            this.textCircleMinX.Name = "textCircleMinX";
            this.textCircleMinX.Size = new System.Drawing.Size(89, 21);
            this.textCircleMinX.TabIndex = 8;
            this.textCircleMinX.TextChanged += new System.EventHandler(this.textCircleMinX_TextChanged);
            // 
            // radioCircleMax
            // 
            this.radioCircleMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioCircleMax.Location = new System.Drawing.Point(243, 20);
            this.radioCircleMax.Name = "radioCircleMax";
            this.radioCircleMax.Size = new System.Drawing.Size(65, 22);
            this.radioCircleMax.TabIndex = 4;
            this.radioCircleMax.TabStop = true;
            this.radioCircleMax.Text = "Max";
            this.radioCircleMax.UseVisualStyleBackColor = true;
            this.radioCircleMax.CheckedChanged += new System.EventHandler(this.radioCircleMax_CheckedChanged);
            // 
            // radioCircleNone
            // 
            this.radioCircleNone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioCircleNone.Location = new System.Drawing.Point(7, 20);
            this.radioCircleNone.Name = "radioCircleNone";
            this.radioCircleNone.Size = new System.Drawing.Size(77, 22);
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
            this.groupBox2.Location = new System.Drawing.Point(7, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 40);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Function Rank";
            // 
            // radioFunCubic
            // 
            this.radioFunCubic.Location = new System.Drawing.Point(227, 12);
            this.radioFunCubic.Name = "radioFunCubic";
            this.radioFunCubic.Size = new System.Drawing.Size(121, 22);
            this.radioFunCubic.TabIndex = 1;
            this.radioFunCubic.TabStop = true;
            this.radioFunCubic.Text = "Cubic";
            this.radioFunCubic.UseVisualStyleBackColor = true;
            this.radioFunCubic.CheckedChanged += new System.EventHandler(this.radioFunCubic_CheckedChanged);
            // 
            // radioFunQuadratic
            // 
            this.radioFunQuadratic.Location = new System.Drawing.Point(7, 12);
            this.radioFunQuadratic.Name = "radioFunQuadratic";
            this.radioFunQuadratic.Size = new System.Drawing.Size(121, 22);
            this.radioFunQuadratic.TabIndex = 0;
            this.radioFunQuadratic.TabStop = true;
            this.radioFunQuadratic.Text = "Quadratic";
            this.radioFunQuadratic.UseVisualStyleBackColor = true;
            this.radioFunQuadratic.CheckedChanged += new System.EventHandler(this.radioFunQuadratic_CheckedChanged);
            // 
            // groupValueType
            // 
            this.groupValueType.Controls.Add(this.label6);
            this.groupValueType.Controls.Add(this.label5);
            this.groupValueType.Controls.Add(this.textMaxY);
            this.groupValueType.Controls.Add(this.textMinY);
            this.groupValueType.Controls.Add(this.checkBoxCustomScale);
            this.groupValueType.Controls.Add(this.radioLog);
            this.groupValueType.Controls.Add(this.radioIntensity);
            this.groupValueType.Location = new System.Drawing.Point(6, 306);
            this.groupValueType.Name = "groupValueType";
            this.groupValueType.Size = new System.Drawing.Size(371, 111);
            this.groupValueType.TabIndex = 1;
            this.groupValueType.TabStop = false;
            this.groupValueType.Text = "Y Value Type";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(9, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Min";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(192, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Max";
            // 
            // textMaxY
            // 
            this.textMaxY.Location = new System.Drawing.Point(244, 78);
            this.textMaxY.Name = "textMaxY";
            this.textMaxY.Size = new System.Drawing.Size(89, 21);
            this.textMaxY.TabIndex = 10;
            this.textMaxY.TextChanged += new System.EventHandler(this.textMaxY_TextChanged);
            // 
            // textMinY
            // 
            this.textMinY.Location = new System.Drawing.Point(59, 78);
            this.textMinY.Name = "textMinY";
            this.textMinY.Size = new System.Drawing.Size(89, 21);
            this.textMinY.TabIndex = 6;
            this.textMinY.TextChanged += new System.EventHandler(this.textMinY_TextChanged);
            // 
            // checkBoxCustomScale
            // 
            this.checkBoxCustomScale.Location = new System.Drawing.Point(115, 48);
            this.checkBoxCustomScale.Name = "checkBoxCustomScale";
            this.checkBoxCustomScale.Size = new System.Drawing.Size(112, 24);
            this.checkBoxCustomScale.TabIndex = 9;
            this.checkBoxCustomScale.Text = "Custom Scale";
            this.checkBoxCustomScale.UseVisualStyleBackColor = true;
            this.checkBoxCustomScale.CheckedChanged += new System.EventHandler(this.checkBoxCustomScale_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(9, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Min";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(192, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Max";
            // 
            // textMaxY
            // 
            this.textMaxY.Location = new System.Drawing.Point(244, 78);
            this.textMaxY.Name = "textMaxY";
            this.textMaxY.Size = new System.Drawing.Size(89, 21);
            this.textMaxY.TabIndex = 10;
            this.textMaxY.TextChanged += new System.EventHandler(this.textMaxY_TextChanged);
            // 
            // textMinY
            // 
            this.textMinY.Location = new System.Drawing.Point(59, 78);
            this.textMinY.Name = "textMinY";
            this.textMinY.Size = new System.Drawing.Size(89, 21);
            this.textMinY.TabIndex = 6;
            this.textMinY.TextChanged += new System.EventHandler(this.textMinY_TextChanged);
            // 
            // checkBoxCustomScale
            // 
            this.checkBoxCustomScale.Location = new System.Drawing.Point(115, 48);
            this.checkBoxCustomScale.Name = "checkBoxCustomScale";
            this.checkBoxCustomScale.Size = new System.Drawing.Size(112, 24);
            this.checkBoxCustomScale.TabIndex = 9;
            this.checkBoxCustomScale.Text = "Custom Scale";
            this.checkBoxCustomScale.UseVisualStyleBackColor = true;
            this.checkBoxCustomScale.CheckedChanged += new System.EventHandler(this.checkBoxCustomScale_CheckedChanged);
            // 
            // radioLog
            // 
            this.radioLog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioLog.Location = new System.Drawing.Point(228, 20);
            this.radioLog.Name = "radioLog";
            this.radioLog.Size = new System.Drawing.Size(121, 22);
            this.radioLog.TabIndex = 4;
            this.radioLog.TabStop = true;
            this.radioLog.Text = "Log(1/Intensity)";
            this.radioLog.UseVisualStyleBackColor = true;
            this.radioLog.CheckedChanged += new System.EventHandler(this.radioLog_CheckedChanged);
            // 
            // radioIntensity
            // 
            this.radioIntensity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioIntensity.Location = new System.Drawing.Point(6, 20);
            this.radioIntensity.Name = "radioIntensity";
            this.radioIntensity.Size = new System.Drawing.Size(121, 22);
            this.radioIntensity.TabIndex = 3;
            this.radioIntensity.TabStop = true;
            this.radioIntensity.Text = "Intensity";
            this.radioIntensity.UseVisualStyleBackColor = true;
            this.radioIntensity.CheckedChanged += new System.EventHandler(this.radioIntensity_CheckedChanged);
            // 
            // groupRectStyle
            // 
            this.groupRectStyle.Controls.Add(this.rectMax);
            this.groupRectStyle.Controls.Add(this.rectAvg);
            this.groupRectStyle.Controls.Add(this.rectRight);
            this.groupRectStyle.Controls.Add(this.rectLeft);
            this.groupRectStyle.Controls.Add(this.rectNone);
            this.groupRectStyle.Location = new System.Drawing.Point(7, 8);
            this.groupRectStyle.Name = "groupRectStyle";
            this.groupRectStyle.Size = new System.Drawing.Size(371, 42);
            this.groupRectStyle.TabIndex = 0;
            this.groupRectStyle.TabStop = false;
            this.groupRectStyle.Text = "Rect Style";
            // 
            // rectMax
            // 
            this.rectMax.Location = new System.Drawing.Point(272, 12);
            this.rectMax.Name = "rectMax";
            this.rectMax.Size = new System.Drawing.Size(60, 24);
            this.rectMax.TabIndex = 11;
            this.rectMax.Text = "Max";
            this.rectMax.UseVisualStyleBackColor = true;
            this.rectMax.Click += new System.EventHandler(this.rectMax_CheckedChanged);
            // 
            // rectAvg
            // 
            this.rectAvg.Location = new System.Drawing.Point(204, 12);
            this.rectAvg.Name = "rectAvg";
            this.rectAvg.Size = new System.Drawing.Size(60, 24);
            this.rectAvg.TabIndex = 10;
            this.rectAvg.Text = "Avg";
            this.rectAvg.UseVisualStyleBackColor = true;
            this.rectAvg.Click += new System.EventHandler(this.rectAvg_CheckedChanged);
            // 
            // rectRight
            // 
            this.rectRight.Location = new System.Drawing.Point(138, 12);
            this.rectRight.Name = "rectRight";
            this.rectRight.Size = new System.Drawing.Size(60, 24);
            this.rectRight.TabIndex = 9;
            this.rectRight.Text = "Right";
            this.rectRight.UseVisualStyleBackColor = true;
            this.rectRight.Click += new System.EventHandler(this.rectRight_CheckedChanged);
            // 
            // rectLeft
            // 
            this.rectLeft.Location = new System.Drawing.Point(72, 12);
            this.rectLeft.Name = "rectLeft";
            this.rectLeft.Size = new System.Drawing.Size(60, 24);
            this.rectLeft.TabIndex = 8;
            this.rectLeft.Text = "Left";
            this.rectLeft.UseVisualStyleBackColor = true;
            this.rectLeft.Click += new System.EventHandler(this.rectLeft_CheckedChanged);
            // 
            // rectNone
            // 
            this.rectNone.Location = new System.Drawing.Point(6, 12);
            this.rectNone.Name = "rectNone";
            this.rectNone.Size = new System.Drawing.Size(60, 24);
            this.rectNone.TabIndex = 7;
            this.rectNone.Text = "None";
            this.rectNone.UseVisualStyleBackColor = true;
            this.rectNone.Click += new System.EventHandler(this.rectNone_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(495, 428);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonReset);
            this.panel1.Controls.Add(this.buttonApply);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(395, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 422);
            this.panel1.TabIndex = 3;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(3, 367);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(87, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "as Default";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(3, 396);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(87, 21);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(3, 30);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 21);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(3, 3);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(87, 21);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // ChartSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 428);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartSettingsForm";
            this.Text = "FmAnalysis_EDTreeData";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupValueType.ResumeLayout(false);
            this.groupValueType.PerformLayout();
            this.groupRectStyle.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox checkBoxCustomScale;
        private System.Windows.Forms.TextBox textMinY;
        private System.Windows.Forms.TextBox textMaxY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textZstepMax;

        private System.Windows.Forms.TextBox textCircleMinX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCircleMaxX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox rectNone;
        private System.Windows.Forms.CheckBox rectLeft;
        private System.Windows.Forms.CheckBox rectRight;
        private System.Windows.Forms.CheckBox rectAvg;
        private System.Windows.Forms.CheckBox rectMax;

        private System.Windows.Forms.CheckBox checkBoxEquation;

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioCircleNone;
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

        private System.Windows.Forms.TextBox textZstepMin;

        private System.Windows.Forms.GroupBox groupValueType;
        private System.Windows.Forms.RadioButton radioIntensity;
        private System.Windows.Forms.RadioButton radioLog;

        private System.Windows.Forms.GroupBox groupRectStyle;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        #endregion
    }
}