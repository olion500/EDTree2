using System;
using System.Linq;
using System.Windows.Forms;

namespace EDTree2
{
    public partial class ChartSettingsForm : Form
    {
        private EDTree edt;
        public ApplyChangeDelegate ApplyChange { get; set; }

        public ChartSettingsForm(EDTree edTree)
        {
            edt = edTree;
            ApplyChange = null;
            InitializeComponent();
            InitializeValues();
        }

        private void InitializeValues()
        {
            textZStep.Text = edt.Zstep.ToString();
            ChooseRadioRectStyle(edt.RectStyle);
            ChooseFunctionRank(edt.Order);
            ChooseRadioCircleStyle(edt.EllipseStyle);
            ChooseCheckEquation(edt.IsShowEquation);
            ChooseRadioLog(edt.IsLogY);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplyChange(edt);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void buttonReset_Click(object sender, EventArgs e)
        {
            edt.ResetOptions();
            InitializeValues();
            ApplyChange(edt);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            ApplyChange(edt);
        }

        private void textZStep_TextChanged(object sender, EventArgs e)
        {
            DisableApply();
            
            var isDouble = Double.TryParse(textZStep.Text, out var zstep);
            if (!isDouble)
                MessageBox.Show("숫자만 입력 가능합니다.");
            
            else if (zstep < 0)
                MessageBox.Show("0보다 큰 값만 입력 가능합니다.");
            
            else if (-zstep < edt.X.Min() || edt.X.Max() < zstep)
                MessageBox.Show("입력된 Z Step 값이 Focus 범위보다 넓습니다");

            else
            {
                edt.Zstep = zstep;
                EnableApply();
            }
            
        }

        private void DisableApply()
        {
            buttonApply.Enabled = false;
            buttonOk.Enabled = false;
        }

        private void EnableApply()
        {
            buttonApply.Enabled = true;
            buttonOk.Enabled = true;
        }

        private void ChooseRadioRectStyle(RectStyle rs)
        {
            if (rs == RectStyle.BaseLine)
            {
                radioRectStyleBase.Checked = true;
            } else if (rs == RectStyle.Average)
            {
                radioRectStyleAverage.Checked = true;
            } else if (rs == RectStyle.Maximum)
            {
                radioRectStyleMax.Checked = true;
            }
        }
        private void radioRectStyleBase_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRectStyleBase.Checked)
                edt.RectStyle = RectStyle.BaseLine;
        }

        private void radioRectStyleAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRectStyleAverage.Checked)
                edt.RectStyle = RectStyle.Average;
        }

        private void radioRectStyleMax_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRectStyleMax.Checked)
                edt.RectStyle = RectStyle.Maximum;
        }

        private void ChooseFunctionRank(int order)
        {
            if (order == 2)
                radioFunQuadratic.Checked = true;
            else if (order == 3)
                radioFunCubic.Checked = true;
        }

        private void radioFunQuadratic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFunQuadratic.Checked)
                edt.Order = 2;
        }

        private void radioFunCubic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFunCubic.Checked)
                edt.Order = 3;
        }

        private void ChooseRadioCircleStyle(EllipseStyle style)
        {
            switch (style)
            {
                case EllipseStyle.None:
                    radioCircleNone.Checked = true;
                    break;
                case EllipseStyle.Left:
                    radioCircleLeft.Checked = true;
                    break;
                case EllipseStyle.Right:
                    radioCircleRight.Checked = true;
                    break;
                case EllipseStyle.Average:
                    radioCircleAverage.Checked = true;
                    break;
                case EllipseStyle.Max:
                    radioCircleMax.Checked = true;
                    break;
            }
        }
        
        private void radioCircleNone_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCircleNone.Checked)
                edt.EllipseStyle = EllipseStyle.None;
        }

        private void radioCircleLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCircleLeft.Checked)
                edt.EllipseStyle = EllipseStyle.Left;
            
        }

        private void radioCircleRight_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCircleRight.Checked)
                edt.EllipseStyle = EllipseStyle.Right;
            
        }

        private void radioCircleAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCircleAverage.Checked)
                edt.EllipseStyle = EllipseStyle.Average;
            
        }

        private void radioCircleMax_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCircleMax.Checked)
                edt.EllipseStyle = EllipseStyle.Max;
            
        }

        private void ChooseCheckEquation(bool isShowEquation)
        {
            checkBoxEquation.Checked = isShowEquation;
        }
        
        private void checkBoxEquation_CheckedChanged(object sender, EventArgs e)
        {
            edt.IsShowEquation = checkBoxEquation.Checked;
        }

        private void ChooseRadioLog(bool isLog)
        {
            if (isLog)
                radioLog.Checked = true;
            else
            {
                radioIntensity.Checked = true;
            }
        }
        private void radioIntensity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioIntensity.Checked)
                edt.IsLogY = false;
        }

        private void radioLog_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLog.Checked)
                edt.IsLogY = true;
        }
    }
}