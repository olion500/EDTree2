using System;
using System.Drawing;
using System.Windows.Forms;

namespace EDTree2
{
    public partial class Form1
    {
        private void CreateListView()
        {
            listView1.BeginUpdate();
            listView1.Clear();
            
            if (CurrentScreen == ChartScreen.Intensity && edt != null)
            {
                // RectPoint rp = edt.GetRectangles(FittingType.Left);
                // ListViewItem item = new ListViewItem($"Green(BaseLine:{edt.Zstep}um)");
                // item.ForeColor = Palette.colorLower;
                // item.SubItems.Add($"{rp.Size}(가로:{rp.Width}, 세로:{rp.Height})");
                // listView1.Items.Add(item);
                //
                // rp = edt.GetRectangles(FittingType.Right);
                // item = new ListViewItem($"Blue(BaseLine:-{edt.Zstep}um)");
                // item.ForeColor = Palette.colorUpper;
                // item.SubItems.Add($"{rp.Size}(가로:{rp.Width}, 세로:{rp.Height})");
                // listView1.Items.Add(item);
                //
                // // rects.
                // if (edt.RectStyle == RectStyle.Average)
                // {
                //     rp = edt.GetRectangles(FittingType.Average);
                //     item = new ListViewItem("Red(Average)");
                //     item.ForeColor = Palette.colorBase;
                //     item.SubItems.Add($"{rp.Size}(가로:{rp.Width}, 세로:{rp.Height})");
                //     listView1.Items.Add(item);
                // }
                // else if (edt.RectStyle == RectStyle.Maximum)
                // {
                //     rp = edt.GetRectangles(FittingType.Max);
                //     item = new ListViewItem("Red(Maximum)");
                //     item.ForeColor = Palette.colorBase;
                //     item.SubItems.Add($"{rp.Size}(가로:{rp.Width}, 세로:{rp.Height})");
                //     listView1.Items.Add(item);
                //
                //     // Common Rect.
                //     rp = edt?.GetRectangles(FittingType.Max).Intersect(edtCmp?.GetRectangles(FittingType.Max));
                //     if (rp != null)
                //     {
                //         item = new ListViewItem("Aqua(Common)");
                //         item.ForeColor = Palette.colorCommonRect;
                //         item.SubItems.Add($"{rp.Size}(가로:{rp.Width}, 세로:{rp.Height}");
                //         listView1.Items.Add(item);
                //     }
                // }
                //
                // // ellipse.
                // var drawingCircle = edt.GetEllipse(edt.EllipseStyle);
                // if (drawingCircle != null)
                // {
                //     item = new ListViewItem($"Brown({edt.EllipseStyle.ToString()})");
                //     item.ForeColor = Palette.colorCircle;
                //     item.SubItems.Add($"{Math.Round(drawingCircle.Size, 3)}(가로:{drawingCircle.Width}, 세로:{drawingCircle.Height})");
                //     listView1.Items.Add(item);
                // }
            }
            listView1.Columns.Add("Rect", 210);
            listView1.Columns.Add("Size", 210);
            listView1.EndUpdate();


            Input input = null;
            Input inputCmp = null;
            if (CurrentScreen == ChartScreen.Intensity)
            {
                if (edt != null)
                    input = edt.Input;
                if (edtCmp != null)
                    inputCmp = edtCmp.Input;
            }
            else if (CurrentScreen == ChartScreen.Defocus || CurrentScreen == ChartScreen.Threshold)
            {
                var acd = (CurrentScreen == ChartScreen.Defocus) ? acdDefocus : acdThreshold;
                if (acd != null)
                    input = acd.Input;
            }
            WriteInputOnListview(listView2, input, new[] {Palette.colorUpper, Palette.colorBase, Palette.colorLower});
            if (CurrentScreen == ChartScreen.Intensity)
                WriteInputOnListview(listView3, inputCmp, new[] {Palette.colorUpper, Palette.colorBase, Palette.colorLower});
            else
            {
                listView3.Clear();
            }
        }

        private void WriteInputOnListview(ListView listView, Input input, Color[] colors)
        {
            listView.BeginUpdate();
            listView.Clear();

            if (input != null)
            {
                // add content on the listview.
                int rows = input.Data[0].Count;
                int cols = input.Header.Length;
                for (int i = 0; i < rows; i++)
                {
                    ListViewItem item = new ListViewItem($"{input.Data[0][i]}");
                    item.UseItemStyleForSubItems = false;
                    for (int j = 1; j < cols; j++)
                    {
                        item.SubItems.Add($"{input.Data[j][i]}").ForeColor = colors[j-1];
                    }

                    listView.Items.Add(item);
                }
            
                // calculate proper column width.
                var colWidth = Math.Max(400 / cols, 60);
                foreach (var col in input.Header)
                {
                    listView.Columns.Add(col, colWidth);
                }
            }
            
            listView.EndUpdate();
        }
    }
}