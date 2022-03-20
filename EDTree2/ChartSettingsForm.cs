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
            edt.ResetValues();
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
            
            else if (-zstep < edt.Focus.First() || edt.Focus.Last() < zstep)
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
    }
}