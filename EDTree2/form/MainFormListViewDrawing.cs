using System;
using System.Linq;
using System.Windows.Forms;

namespace EDTree2
{
    public partial class Form1
    {
        private void CreateListView()
        {
            listView1.BeginUpdate();
            listView1.Clear();
            
            if (CurrentScreen == ChartScreen.Intensity)
            {
                // show edt's rectangle info in the listview1.
                foreach (var rs in edtreeOption.RectStyles)
                {
                    var rect = edt?.GetRectangles(rs);
                    if (rect == null) continue;

                    var color = Palette.FromRectStyle(rs);
                    var item = new ListViewItem($"{color.Name}({rs.GetName()})")
                    {
                        ForeColor = color.Color,
                        SubItems = { $"{rect.Size}(가로:{rect.Width}, 세로:{rect.Height}" }
                    };
                    listView1.Items.Add(item);
                }
                
                // show edtCmp's rectangle info in the listview1.
                foreach (var rs in edtreeOption.RectStyles)
                {
                    var rect = edtCmp?.GetRectangles(rs);
                    if (rect == null) continue;

                    var color = Palette.FromRectStyleCmp(rs);
                    var item = new ListViewItem($"{color.Name}({rs.GetName()})")
                    {
                        ForeColor = color.Color,
                        SubItems = { $"{rect.Size}(가로:{rect.Width}, 세로:{rect.Height}" }
                    };
                    listView1.Items.Add(item);
                }
                
                // Common Rect.
                var rectStyle = edtreeOption.RectStyles.FirstOrDefault();
                var commonRect = edt?.GetRectangles(rectStyle)?.Intersect(edtCmp?.GetRectangles(rectStyle));
                if (commonRect != null)
                {
                    var color = Palette.colorRectCommon;
                    var item = new ListViewItem($"{color.Name}(Intersect)")
                    {
                        ForeColor = color.Color,
                        SubItems = { $"{commonRect.Size}(가로:{commonRect.Width}, 세로:{commonRect.Height}" }
                    };
                    listView1.Items.Add(item);
                }
                
                // ellipse.
                var drawingCircles = new[]
                    {edt?.GetEllipse(edtreeOption.EllipseStyle), edtCmp?.GetEllipse(edtreeOption.EllipseStyle)};
                var circleColors = new[] {Palette.colorEllipse, Palette.colorEllipseTrans};

                for (int i = 0; i < drawingCircles.Length; i++)
                {
                    var ep = drawingCircles[i];
                    var color = circleColors[i];
                    if (ep == null) continue;
                    
                    var item = new ListViewItem($"{color.Name}(Maximum Ellipse)")
                    {
                        ForeColor = color.Color,
                        SubItems = { $"{Math.Round(ep.Size, 3)}(가로:{ep.Width}, 세로:{ep.Height})" }
                    };
                    listView1.Items.Add(item);
                }
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

        private void WriteInputOnListview(ListView listView, Input input, NamedColor[] colors)
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
                        item.SubItems.Add($"{input.Data[j][i]}").ForeColor = colors[j-1].Color;
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