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
            textPercent.Text = (edt.Percentage * 100).ToString();
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

        private void buttonApply_Click(object sender, EventArgs e)
        {
            ApplyChange(edt);
        }

        private void textZStep_TextChanged(object sender, EventArgs e)
        {
            disableApply();
            
            var isDouble = Double.TryParse(textZStep.Text, out var zstep);
            if (!isDouble)
                MessageBox.Show("숫자만 입력 가능합니다.");
            
            else if (-zstep < edt.Focus.First() || edt.Focus.Last() < zstep)
                MessageBox.Show("입력된 Z Step 값이 Focus 범위보다 넓습니다");

            else
            {
                edt.Zstep = zstep;
                enableApply();
            }
            
        }

        private void textPercent_TextChanged(object sender, EventArgs e)
        {
            disableApply();
            
            var isDouble = Double.TryParse(textPercent.Text, out var p);
            if (!isDouble)
                MessageBox.Show("숫자만 입력 가능합니다.");
            else
            {
                edt.Percentage = p / 100;
                enableApply();
            }
        }

        private void disableApply()
        {
            buttonApply.Enabled = false;
            buttonOk.Enabled = false;
        }

        private void enableApply()
        {
            buttonApply.Enabled = true;
            buttonOk.Enabled = true;
        }
    }
}