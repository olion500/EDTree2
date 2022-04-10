using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EDTree2.form.option;

namespace EDTree2
{
    
    /// <summary>
    /// Which screen will be shown in the display.
    /// </summary>
    internal enum ChartScreen
    {
        Intensity, Defocus, Threshold
    }
    public partial class MainForm : Form
    {
        // initial file path to import. 
        private string filename_intensity = "input_intensity.txt";
        private string filename_intensity_cmp = "input_intensity2.txt";
        private string filename_defocus = "input_defocus.txt";
        private string filename_threshold = "input_threshold.txt";

        // data object to draw chart and listview.
        private EDTree edt, edtCmp;
        private AerialCD acdDefocus;
        private AerialCD acdThreshold;

        // option that the user changes.
        private EdtreeOption edtreeOption;

        private ChartScreen CurrentScreen;
        
        public MainForm()
        {
            // init screen.
            CurrentScreen = ChartScreen.Intensity;

            edtreeOption = new EdtreeOption();
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAndDraw();
            
            // add post paint event that draw rectangles and ellipses..
            mainChart.PostPaint += MainChartOnPostPaint;
        }
        
        private void LoadAndDraw()
        {
            LoadData();
            DrawScreen();
        }

        /// <summary>
        /// Load Data from files. When it failed, the object will be set null.
        /// </summary>
        private void LoadData()
        {
            try
            {
                var intensityInput = InputParser.Parse(filename_intensity);
                InputParser.IntensityValidate(intensityInput);
                edt = new EDTree(intensityInput)
                    .SetOption(edtreeOption)
                    .Calculate();
            }
            catch
            {
                edt = null;
            }
            
            try
            {
                var intensityInput = InputParser.Parse(filename_intensity_cmp);
                InputParser.IntensityValidate(intensityInput);
                edtCmp = new EDTree(intensityInput)
                    .SetOption(edtreeOption)
                    .Calculate();
            }
            catch
            {
                edtCmp = null;
            }


            try
            {
                var defocusInput = InputParser.Parse(filename_defocus);
                InputParser.AerialValidate(defocusInput);
                acdDefocus = new AerialCD(defocusInput);
                acdDefocus.Calculate();
            }
            catch
            {
                acdDefocus = null;
            }

            try
            {
                var thresholdInput = InputParser.Parse(filename_threshold);
                InputParser.AerialValidate(thresholdInput);
                acdThreshold = new AerialCD(thresholdInput);
                acdThreshold.Calculate();
            }
            catch
            {
                acdThreshold = null;
            }

        }

        /// <summary>
        /// Draw chart and listview based on the data.
        /// </summary>
        private void DrawScreen()
        {
            // Create Chart.
            CreateChart();

            // Create Data grid.
            CreateListView();

            // Show load file name in status bar.
            var fileNotFoundMsg = "Not found input file";
            switch (CurrentScreen)
            {
                case ChartScreen.Intensity:
                    statusBar1.Text = (edt == null) ? fileNotFoundMsg : "load file : " + filename_intensity;
                    break;
                case ChartScreen.Defocus:
                    statusBar1.Text = (acdDefocus == null) ? fileNotFoundMsg : "load file : " + filename_defocus;
                    break;
                case ChartScreen.Threshold:
                    statusBar1.Text = (acdThreshold == null) ? fileNotFoundMsg : "load file : " + filename_threshold;
                    break;
            }
        }
        
        private void buttonSetting_Click(object sender, EventArgs e)
        {
            // Rect style is multi-selectable, when compared data is not provided.
            var chartSettingsForm = new ChartSettingsForm(edtreeOption, (edtCmp == null));
            chartSettingsForm.Show();
            chartSettingsForm.ApplyChange += ApplyChange;
        }

        private void ApplyChange(EdtreeOption changed)
        {
            edtreeOption = changed;
            edt
                .SetOption(edtreeOption)
                .Calculate();
            
            ShowAlert();
            
            // Create Chart.
            CreateChart();

            // Create Data grid.
            CreateListView();
        }

        /// <summary>
        /// Show Alert when something is wrong.
        /// </summary>
        private void ShowAlert()
        {
            // show alert when one of selected rect cannot be calculated.
            foreach (var rectStyle in edtreeOption.RectStyles)
            {
                if (rectStyle == RectStyle.None) continue;

                var rect = edt?.GetRectangles(rectStyle);
                if (rect == null)
                {
                    MessageBox.Show("Error! 데이터 조건이 만족하지 않습니다");
                    break;
                }
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (!ShouldScreenChanged(ChartScreen.Intensity)) return;
            CurrentScreen = ChartScreen.Intensity;
            DrawScreen();
        }

        private void buttonDefocus_Click(object sender, EventArgs e)
        {
            if (!ShouldScreenChanged(ChartScreen.Defocus)) return;
            CurrentScreen = ChartScreen.Defocus;
            DrawScreen();
        }

        private void buttonThreshold_Click(object sender, EventArgs e)
        {
            if (!ShouldScreenChanged(ChartScreen.Threshold)) return;
            CurrentScreen = ChartScreen.Threshold;
            DrawScreen();
        }

        private bool ShouldScreenChanged(ChartScreen changeScreen)
        {
            return (CurrentScreen != changeScreen);
        }

        /// <summary>
        /// Perform csv export when the user click the export button.
        /// </summary>
        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "csv (*.csv)|*.csv|txt (*txt)|*.txt|All files (*.*)|*.*";
            if (saveDlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            FileStream fs = new FileStream(saveDlg.FileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            if (CurrentScreen == ChartScreen.Intensity && edt != null)
            {
                // write columns.
                string line = string.Join(",", edt.Header);
                sw.WriteLine(line);

                // write data.
                foreach (var x in edt.GetXPoints(0.1))
                {
                    var arr = new[]
                    {
                        x,
                        edt.LowerLine.Evaluate(x),
                        edt.BaseLine.Evaluate(x),
                        edt.UpperLine.Evaluate(x)
                    }.Select(v => Math.Round(v, 3));
                    line = String.Join(",", arr);
                    sw.WriteLine(line);
                }
            }
            else if (CurrentScreen == ChartScreen.Defocus || CurrentScreen == ChartScreen.Threshold)
            {
                var acd = (CurrentScreen == ChartScreen.Defocus) ? acdDefocus : acdThreshold;
                if (acd != null)
                {
                    // write columns.
                    string line = string.Join(",", acd.Input.Header);
                    sw.WriteLine(line);

                    // write data.
                    var step = (CurrentScreen == ChartScreen.Defocus) ? 0.1 : 0.001;
                    foreach (var x in acd.GetXPoints(step))
                    {
                        var y =
                            acd.Lines
                                .Select(f => f.Evaluate(x))
                                .ToList();
                        y.Insert(0, x);

                        var arr = y.Select(v => Math.Round(v, 3));
                        line = String.Join(",", arr);
                        sw.WriteLine(line);
                    }
                }
            }

            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// Perform txt import when the user click the import button.
        /// </summary>
        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt",
            };
            if (openDlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            var filename = openDlg.FileName;
            switch (CurrentScreen)
            {
                case ChartScreen.Intensity:
                    filename_intensity = filename;
                    break;
                case ChartScreen.Defocus:
                    filename_defocus = filename;
                    break;
                case ChartScreen.Threshold:
                    filename_threshold = filename;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            LoadAndDraw();
        }
    }
}