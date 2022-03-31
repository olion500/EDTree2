using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EDTree2.form.option;

namespace EDTree2
{
    public partial class ChartSettingsForm : Form
    {
        private EdtreeOption _option;
        public ApplyChangeDelegate ApplyChange { get; set; }

        public ChartSettingsForm(EdtreeOption option)
        {
            _option = option;
            ApplyChange = null;
            InitializeComponent();
            InitializeValues();
        }

        private void InitializeValues()
        {
            textZstepMin.Text = _option.ZstepMin.ToString();
            textZstepMax.Text = _option.ZstepMax.ToString();
            textCircleMinX.Text = _option.EllipseMinX.ToString();
            textCircleMaxX.Text = _option.EllipseMaxX.ToString();
            ChooseCheckRectStyle(_option.RectStyles);
            ChooseFunctionRank(_option.Order);
            ChooseRadioCircleStyle(_option.EllipseStyle);
            ChooseCheckEquation(_option.IsShowEquation);
            ChooseRadioLog(_option.IsLogY);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplyChange(_option);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void buttonReset_Click(object sender, EventArgs e)
        {
            _option.ResetValues();
            InitializeValues();
            ApplyChange(_option);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            ApplyChange(_option);
        }

        private void textZstepMin_TextChanged(object sender, EventArgs e)
        {
            DisableApply();

            if (!CheckMinMaxTextBoxes(textZstepMin, textZstepMax)) return;
            
            double.TryParse(textZstepMin.Text, out var minVal);
            _option.ZstepMin = minVal;
            EnableApply();
        }
        
        private void textZstepMax_TextChanged(object sender, EventArgs e)
        {
            DisableApply();

            if (!CheckMinMaxTextBoxes(textZstepMin, textZstepMax)) return;
            
            double.TryParse(textZstepMax.Text, out var maxVal);
            _option.ZstepMax = maxVal;
            EnableApply();
        }

        /// <summary>
        /// Show error when the user input wrong value in textboxes.
        /// If something goes wrong, it returns false.
        /// </summary>
        private bool CheckMinMaxTextBoxes(TextBox tbMin, TextBox tbMax)
        {
            var isDoubleMin = double.TryParse(tbMin.Text, out var zstepMinValue);
            var isDoubleMax = double.TryParse(tbMax.Text, out var zstepMaxValue);
            if (!string.IsNullOrEmpty(tbMin.Text) && !isDoubleMin)
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                textZstepMin.Clear();
                return false;
            }

            if (!string.IsNullOrEmpty(tbMax.Text) && !isDoubleMax)
            {
                MessageBox.Show("숫자만 입력 가능합니다.");
                textZstepMax.Clear();
                return false;
            }
            
            if (zstepMinValue > zstepMaxValue)
            {
                MessageBox.Show("최소값이 최대값보다 작아야합니다.");
                return false;
            }

            return true;
        }
        

        /// <summary>
        /// Disable apply button when the user writes wrong values.
        /// </summary>
        private void DisableApply()
        {
            buttonApply.Enabled = false;
            buttonOk.Enabled = false;
        }

        /// <summary>
        /// Enable apply button when the user writes wrong values.
        /// </summary>
        private void EnableApply()
        {
            buttonApply.Enabled = true;
            buttonOk.Enabled = true;
        }

        private void ChooseCheckRectStyle(List<RectStyle> rectStyles)
        {
            foreach (var rs in rectStyles)
            {
                switch (rs)
                {
                    case RectStyle.None:
                        UncheckAllRectOptions();
                        rectNone.Checked = true;
                        break;
                    case RectStyle.Left:
                        rectLeft.Checked = true;
                        break;
                    case RectStyle.Right:
                        rectRight.Checked = true;
                        break;
                    case RectStyle.Avg:
                        rectAvg.Checked = true;
                        break;
                    case RectStyle.Max:
                        rectMax.Checked = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void UncheckAllRectOptions(bool withoutNone=false)
        {
            if (!withoutNone)
                rectNone.Checked = false;
            rectLeft.Checked = false;
            rectRight.Checked = false;
            rectAvg.Checked = false;
            rectMax.Checked = false;
        }
        
        private void rectNone_CheckedChanged(object sender, EventArgs e)
        {
            if (rectNone.Checked)
            {
                _option.AddRectStyle(RectStyle.None);
                UncheckAllRectOptions(withoutNone: true);
            }
            else
            {
                _option.RemoveRectStyle(RectStyle.None);
            }
            
        }

        private void rectLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (rectLeft.Checked)
            {
                _option.AddRectStyle(RectStyle.Left);
                rectNone.Checked = false;
            }
            else
            {
                _option.RemoveRectStyle(RectStyle.Left);
            }
                
        }

        private void rectRight_CheckedChanged(object sender, EventArgs e)
        {
            if (rectRight.Checked)
            {
                _option.AddRectStyle(RectStyle.Right);
                rectNone.Checked = false;
            }
            else
            {
                _option.RemoveRectStyle(RectStyle.Right);
            }
        }

        private void rectAvg_CheckedChanged(object sender, EventArgs e)
        {
            if (rectAvg.Checked)
            {
                _option.AddRectStyle(RectStyle.Avg);
                rectNone.Checked = false;
            }
            else
            {
                _option.RemoveRectStyle(RectStyle.Avg);
            }
        }

        private void rectMax_CheckedChanged(object sender, EventArgs e)
        {
            if (rectMax.Checked)
            {
                _option.AddRectStyle(RectStyle.Max);
                rectNone.Checked = false;
            }
            else
            {
                _option.RemoveRectStyle(RectStyle.Max);
            }
                
        }
        
        private void textCircleMinX_TextChanged(object sender, EventArgs e)
        {
            DisableApply();

            if (!CheckMinMaxTextBoxes(textCircleMinX, textCircleMaxX)) return;
            
            double.TryParse(textCircleMinX.Text, out var minVal);
            _option.EllipseMinX = minVal;
            EnableApply();
        }

        private void textCircleMaxX_TextChanged(object sender, EventArgs e)
        {
            DisableApply();

            if (!CheckMinMaxTextBoxes(textCircleMinX, textCircleMaxX)) return;
            
            double.TryParse(textCircleMaxX.Text, out var maxVal);
            _option.EllipseMaxX = maxVal;
            EnableApply();
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
                _option.Order = 2;
        }

        private void radioFunCubic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFunCubic.Checked)
                _option.Order = 3;
        }

        private void ChooseRadioCircleStyle(EllipseStyle style)
        {
            switch (style)
            {
                case EllipseStyle.None:
                    radioCircleNone.Checked = true;
                    break;
                case EllipseStyle.Max:
                    radioCircleMax.Checked = true;
                    break;
            }
        }
        
        private void radioCircleNone_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCircleNone.Checked)
                _option.EllipseStyle = EllipseStyle.None;
        }

        private void radioCircleMax_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCircleMax.Checked)
                _option.EllipseStyle = EllipseStyle.Max;
            
        }

        private void ChooseCheckEquation(bool isShowEquation)
        {
            checkBoxEquation.Checked = isShowEquation;
        }
        
        private void checkBoxEquation_CheckedChanged(object sender, EventArgs e)
        {
            _option.IsShowEquation = checkBoxEquation.Checked;
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
                _option.IsLogY = false;
        }

        private void radioLog_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLog.Checked)
                _option.IsLogY = true;
        }
    }
}