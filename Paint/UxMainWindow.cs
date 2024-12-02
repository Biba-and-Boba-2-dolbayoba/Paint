using System.ComponentModel;

namespace Paint;

public partial class UxMainWindow : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int CanvasWidth { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int CanvasHeight { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static Color LineColor { get; private set; } = Color.Black;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static Color BackgroundColor { get; private set; } = Color.White;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int FigureType { get; private set; } = 1;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static Font TextFont { get; private set; } = new("Times New Roman", 12.0f);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static bool IsFilling { get; private set; } = false;

    private bool IsSelectionMode { get; set; } = false;

    public UxMainWindow() {
        this.InitializeComponent();
    }

    public static void SaveFile(UxCanvasWindow canvas) {
        string fileName;
        UxCanvasWindow _canvas = canvas;

        if (_canvas.fileName == null) {
            var saveFileDialog1 = new SaveFileDialog {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Графический редактор (*.png)|*.png|All files(*.*)|*.*",
                FilterIndex = 1
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                fileName = saveFileDialog1.FileName;
                _canvas.fileName = fileName;
                _canvas.flag3 = false;
            }
        } else {
            fileName = _canvas.fileName;
            _canvas.Text = Path.GetFileName(fileName);
            _canvas.flag3 = false;
        }
    }

    private void MouseDownHandler(object sender, MouseEventArgs e) {
        Graphics graphics = this.CreateGraphics();

        if (e.Button == MouseButtons.Left) {
            string s = e.Location.ToString();

            graphics.DrawString(s, new Font("Times New Roman", 8),
            new SolidBrush(Color.Black), new Point(e.X, e.Y));
        }

        if (e.Button == MouseButtons.Right) {
            string s = "Hello";
            graphics.DrawString(s, new Font("Times New Roman", 8),
            new SolidBrush(Color.Black), new Point(e.X, e.Y));
        }

        if (e.Button == MouseButtons.Middle) {
            _ = MessageBox.Show("Вы уверены что хотите удалить текст?", "Удаление");
            graphics.Clear(Color.White);
        }
    }

    private void LoadHandler(object sender, EventArgs e) {
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        this.UpdateStyles();
    }

    private void ResizeBeginHandler(object sender, EventArgs e) {
        this.StatusStrip.Invalidate();
    }

    private void ResizeHandler(object sender, EventArgs e) {
        if (this.TextToolStripMenuItem.Checked) {
            this.PenSize.Width = this.Width / 10;
            this.PenColor.Width = this.Width / 20;
            this.FillingColor.Width = this.Width / 20;
            this.MouseCords.Width = this.Width / 5;
            this.CanvasSize.Width = this.Width / 5;
            this.FontName.Width = this.Width / 5;
            this.FontSize.Width = this.Width / 5;
        } else {
            this.PenSize.Width = this.Width / 10;
            this.PenColor.Width = this.Width / 20;
            this.FillingColor.Width = this.Width / 20;
            this.MouseCords.Width = this.Width / 25 * 10;
            this.CanvasSize.Width = this.Width / 25 * 10;
        }

        Graphics g = this.StatusStrip.CreateGraphics();
        var RectColorPen = new Pen(LineColor, 1);
        Brush brush = new SolidBrush(LineColor);
        var r = new Rectangle(this.Width / 10, 0, this.Width / 20, this.Height);
        g.FillRectangle(brush, r);
        g.DrawRectangle(RectColorPen, r);

        RectColorPen = new Pen(BackgroundColor, 1);
        brush = new SolidBrush(BackgroundColor);
        r = new Rectangle((this.Width / 10) + (this.Width / 20), 0, this.Width / 20, this.Height);
        g.FillRectangle(brush, r);
        g.DrawRectangle(RectColorPen, r);
    }
    private void ResizeEndHandler(object sender, EventArgs e) {
        if (this.TextToolStripMenuItem.Checked == true) {
            this.PenSize.Width = this.Width / 10;
            this.PenColor.Width = this.Width / 20;
            this.FillingColor.Width = this.Width / 20;
            this.MouseCords.Width = this.Width / 5;
            this.CanvasSize.Width = this.Width / 5;
            this.FontName.Width = this.Width / 5;
            this.FontSize.Width = this.Width / 5;
        }

        Graphics g = this.StatusStrip.CreateGraphics();
        var RectColorPen = new Pen(LineColor, 1);
        Brush brush = new SolidBrush(LineColor);
        var r = new Rectangle(this.Width / 10, 0, this.Width / 20, this.Height);
        g.FillRectangle(brush, r);
        g.DrawRectangle(RectColorPen, r);

        RectColorPen = new Pen(BackgroundColor, 1);
        brush = new SolidBrush(BackgroundColor);
        r = new Rectangle((this.Width / 10) + (this.Width / 20), 0, this.Width / 20, this.Height);
        g.FillRectangle(brush, r);
        g.DrawRectangle(RectColorPen, r);
    }

    private void NewFileToolStripMenuItemClick(object sender, EventArgs e) {
        if (CanvasWidth > 0 && CanvasHeight > 0) {
            var CanvasWindow = new UxCanvasWindow {
                MdiParent = this,
                Text = "Рисунок " + this.MdiChildren.Length.ToString()
            };
            CanvasWindow.CursorMoved += this.CanvasWindowCursorMove;
            CanvasWindow.FormActivated += this.CanvasWindowFormActivated;
            CanvasWindow.Show();
        } else {
            var sizeDialog = new UxCreateCanvas();
            _ = sizeDialog.ShowDialog(this);
            CanvasWidth = int.Parse(UxCreateCanvas.CanvasWidth);
            CanvasHeight = int.Parse(UxCreateCanvas.CanvasHeight);

            if (CanvasWidth > 0 && this.Height > 0) {
                var CanvasWindow = new UxCanvasWindow {
                    MdiParent = this,
                    Text = "Рисунок " + this.MdiChildren.Length.ToString()
                };
                CanvasWindow.CursorMoved += this.CanvasWindowCursorMove;
                CanvasWindow.FormActivated += this.CanvasWindowFormActivated;
                CanvasWindow.Show();
            }
        }
    }

    private void CanvasWindowCursorMove(int x, int y) {
        if (x <= CanvasWidth && y <= CanvasHeight) {
            this.MouseCords.Text = $"Положение курсора X: {x}, Y: {y}";
        } else if (x > CanvasWidth && y <= CanvasHeight) {
            this.MouseCords.Text = $"Положение курсора X: {CanvasWidth}, Y: {y}";
        } else if (x <= CanvasWidth && y > CanvasHeight) {
            this.MouseCords.Text = $"Положение курсора X: {x}, Y: {CanvasHeight}";
        } else if (x > CanvasWidth && y > CanvasHeight) {
            this.MouseCords.Text = $"Положение курсора X: {CanvasWidth}, Y: {CanvasHeight}";
        }
    }

    private void CanvasWindowFormActivated(int x, int y) {
        this.CanvasSize.Text = $"Размер окна X: {x}, Y: {y}";
    }

    private void SaveFileToolStripMenuItemClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            SaveFile(activeForm);
        }
    }

    public void SaveFileAsToolStripMenuItemClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            UxCanvasWindow canvas = activeForm;
            canvas.fileName = null;
            SaveFile(canvas);
        }
    }

    private void OpenFileToolStripMenuItemClick(object sender, EventArgs e) {
        //string fileName;

        //OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
        //openFileDialog1.Filter = "Графический редактор (*.png)|*.png|All files(*.*)|*.*";
        //openFileDialog1.FilterIndex = 1;
        //if (openFileDialog1.ShowDialog() == DialogResult.OK) {
        //    try {

        //        fileName = openFileDialog1.FileName;
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        Stream stream2 = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        //        List<Figure> array = (List<Figure>)formatter.Deserialize(stream2);
        //        Size siz = (Size)formatter.Deserialize(stream2);
        //        var f2 = new UxCanvasWindow();
        //        f2.MdiParent = this;
        //        f2.fileName = fileName;
        //        f2.Text = openFileDialog1.SafeFileName;
        //        f2.Sz = siz;
        //        foreach (Figure f in array) {
        //            f2.array.Add(f);
        //        }
        //        f2.CursorMoved += Form2_CursorMoved;
        //        f2.FormActivated += Form2_FormActivated;
        //        f2.Show();
        //        stream2.Close();

        //    } catch (Exception ex) {
        //        MessageBox.Show("Error. " + ex.Message);
        //    }
        //}
    }

    private bool IsWindowOpen() {
        return (this.ActiveMdiChild as UxCanvasWindow) != null;
    }

    private void FileToolStripMenuItemClick(object sender, EventArgs e) {
        this.SaveFileToolStripMenuItem.Enabled = this.IsWindowOpen();
        this.SaveFileAsToolStripMenuItem.Enabled = this.IsWindowOpen();
    }

    private void PenSizeToolStripMenuItemClick(object sender, EventArgs e) {
        var BrushSize = new UxBrushSize {
            Text = "Изменение размера кисти",
            MdiParent = this
        };
        BrushSize.FormClosing += this.BrushSizeFormClosing;
        BrushSize.Show();
    }

    private void BrushSizeFormClosing(object? sender, FormClosingEventArgs e) {
        this.StatusStrip.Invalidate();
        this.PenSize.Text = "Размер пера - " + UxBrushSize.BrushSize;
    }

    private void CanvasSizeToolStripMenuItemClick(object sender, EventArgs e) {
        var sizeDialog = new UxCreateCanvas();
        _ = sizeDialog.ShowDialog(this);
        CanvasWidth = int.Parse(UxCreateCanvas.CanvasWidth);
        CanvasHeight = int.Parse(UxCreateCanvas.CanvasHeight);
    }

    private void FillingToolStripMenuItemClick(object sender, EventArgs e) {
        IsFilling = this.FillingToolStripMenuItem.Checked == true;
    }

    private void RectangleToolStripMenuItemClick(object sender, EventArgs e) {
        FigureType = 1;
        this.RectangleToolStripMenuItem.Checked = true;
        this.EllipseToolStripMenuItem.Checked = false;
        this.StraightLineToolStripMenuItem.Checked = false;
        this.CurveLineToolStripMenuItem.Checked = false;
        this.TextToolStripMenuItem.Checked = false;
        this.SelectionToolStripMenuItem.Checked = false;

        this.RectangleButton.Checked = true;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = false;
        this.SelectionButton.Checked = false;

        this.IsSelectionMode = false;
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void EllipseToolStripMenuItemClick(object sender, EventArgs e) {
        FigureType = 2;
        this.RectangleToolStripMenuItem.Checked = false;
        this.EllipseToolStripMenuItem.Checked = true;
        this.StraightLineToolStripMenuItem.Checked = false;
        this.CurveLineToolStripMenuItem.Checked = false;
        this.TextToolStripMenuItem.Checked = false;
        this.SelectionToolStripMenuItem.Checked = false;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = true;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = false;
        this.SelectionButton.Checked = false;

        this.IsSelectionMode = false;
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void StraightLineToolStripMenuItemClick(object sender, EventArgs e) {
        FigureType = 3;
        this.RectangleToolStripMenuItem.Checked = false;
        this.EllipseToolStripMenuItem.Checked = false;
        this.StraightLineToolStripMenuItem.Checked = true;
        this.CurveLineToolStripMenuItem.Checked = false;
        this.TextToolStripMenuItem.Checked = false;
        this.SelectionToolStripMenuItem.Checked = false;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = true;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = false;
        this.SelectionButton.Checked = false;

        this.IsSelectionMode = false;
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void CurveLineToolStripMenuItemClick(object sender, EventArgs e) {
        FigureType = 4;
        this.RectangleToolStripMenuItem.Checked = false;
        this.EllipseToolStripMenuItem.Checked = false;
        this.StraightLineToolStripMenuItem.Checked = false;
        this.CurveLineToolStripMenuItem.Checked = true;
        this.TextToolStripMenuItem.Checked = false;
        this.SelectionToolStripMenuItem.Checked = false;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = true;
        this.TextButton.Checked = false;
        this.SelectionButton.Checked = false;

        this.IsSelectionMode = false;
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void FillingColorToolStripMenuItemClick(object sender, EventArgs e) {
        this.StatusStrip.Invalidate();
        var colorDialog1 = new ColorDialog();
        BackgroundColor = colorDialog1.Color;

        Graphics g = this.StatusStrip.CreateGraphics();
        var RectColorPen = new Pen(BackgroundColor, 1);
        Brush brush = new SolidBrush(BackgroundColor);
        var r = new Rectangle((this.Width / 10) + (this.Width / 20), 0, this.Width / 20, this.Height);
        g.FillRectangle(brush, r);
        g.DrawRectangle(RectColorPen, r);
    }

    private void PenColorToolStripMenuItemClick(object sender, EventArgs e) {
        this.StatusStrip.Invalidate();
        var colorDialog2 = new ColorDialog();
        LineColor = colorDialog2.Color;

        Graphics g = this.StatusStrip.CreateGraphics();
        Brush brush = new SolidBrush(LineColor);
        var RectColorPen = new Pen(LineColor, 1);
        var r = new Rectangle(this.Width / 10, 0, this.Width / 20, this.Height);
        g.FillRectangle(brush, r);
        g.DrawRectangle(RectColorPen, r);
    }






    private void NewFileButtonClick(object sender, EventArgs e) {
        this.NewFileToolStripMenuItemClick(sender, e);
    }

    private void SaveFileButtonClick(object sender, EventArgs e) {
        this.SaveFileToolStripMenuItemClick(sender, e);
    }

    private void OpenFileButtonClick(object sender, EventArgs e) {
        this.OpenFileToolStripMenuItemClick(sender, e);
    }

    private void PenSizeButtonClick(object sender, EventArgs e) {
        this.PenSizeToolStripMenuItemClick(sender, e);
    }

    private void PenColorButtonClick(object sender, EventArgs e) {
        this.PenColorToolStripMenuItemClick(sender, e);
    }

    private void FillingColorButtonClick(object sender, EventArgs e) {
        this.FillingColorToolStripMenuItemClick(sender, e);
    }

    private void CanvasSizeButtonClick(object sender, EventArgs e) {
        this.CanvasSizeToolStripMenuItemClick(sender, e);
    }

    private void RectangleButtonClick(object sender, EventArgs e) {
        this.RectangleToolStripMenuItemClick(sender, e);
        if (this.RectangleToolStripMenuItem.Checked == true) {
            this.RectangleButton.Checked = true;
            this.EllipseButton.Checked = false;
            this.StraightLineButton.Checked = false;
            this.CurveLineButton.Checked = false;
            this.TextButton.Checked = false;
            this.SelectionButton.Checked = false;

            this.IsSelectionMode = false;
            if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
                activeForm.IsSelectionMode = this.IsSelectionMode;
            }
        }
    }

    private void EllipseButtonClick(object sender, EventArgs e) {
        this.EllipseToolStripMenuItemClick(sender, e);
        if (this.EllipseToolStripMenuItem.Checked == true) {
            this.RectangleButton.Checked = false;
            this.EllipseButton.Checked = true;
            this.StraightLineButton.Checked = false;
            this.CurveLineButton.Checked = false;
            this.TextButton.Checked = false;
            this.SelectionButton.Checked = false;

            this.IsSelectionMode = false;
            if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
                activeForm.IsSelectionMode = this.IsSelectionMode;
            }
        }
    }

    private void StraightLineButtonClick(object sender, EventArgs e) {
        this.StraightLineToolStripMenuItemClick(sender, e);
        if (this.StraightLineToolStripMenuItem.Checked == true) {
            this.RectangleButton.Checked = false;
            this.EllipseButton.Checked = false;
            this.StraightLineButton.Checked = true;
            this.CurveLineButton.Checked = false;
            this.TextButton.Checked = false;
            this.SelectionButton.Checked = false;

            this.IsSelectionMode = false;
            if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
                activeForm.IsSelectionMode = this.IsSelectionMode;
            }
        }
    }

    private void CurveLineButtonClick(object sender, EventArgs e) {
        this.CurveLineToolStripMenuItemClick(sender, e);
        if (this.CurveLineToolStripMenuItem.Checked == true) {
            this.RectangleButton.Checked = false;
            this.EllipseButton.Checked = false;
            this.StraightLineButton.Checked = false;
            this.CurveLineButton.Checked = true;
            this.TextButton.Checked = false;
            this.SelectionButton.Checked = false;

            this.IsSelectionMode = false;
            if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
                activeForm.IsSelectionMode = this.IsSelectionMode;
            }
        }
    }

    private void TextButtonClick(object sender, EventArgs e) {
        this.TextToolStripMenuItemClick(sender, e);
        if (this.TextToolStripMenuItem.Checked == true) {
            this.RectangleButton.Checked = false;
            this.EllipseButton.Checked = false;
            this.StraightLineButton.Checked = false;
            this.CurveLineButton.Checked = false;
            this.TextButton.Checked = true;
            this.SelectionButton.Checked = false;

            this.IsSelectionMode = false;
            if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
                activeForm.IsSelectionMode = this.IsSelectionMode;
            }
        }
    }

    private void TextToolStripMenuItemClick(object sender, EventArgs e) {
        FigureType = 5;
        this.RectangleToolStripMenuItem.Checked = false;
        this.EllipseToolStripMenuItem.Checked = false;
        this.StraightLineToolStripMenuItem.Checked = false;
        this.CurveLineToolStripMenuItem.Checked = false;
        this.TextToolStripMenuItem.Checked = true;

        this.StatusStrip.Invalidate();
        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = true;
        this.FontName.Text = Convert.ToString(TextFont.Name);
        this.FontSize.Text = Convert.ToString(TextFont.Size);
        this.PenSize.Width = this.Width / 10;
        this.PenColor.Width = this.Width / 20;
        this.FillingColor.Width = this.Width / 20;
        this.MouseCords.Width = this.Width / 5;
        this.CanvasSize.Width = this.Width / 5;
        this.FontName.Width = this.Width / 5;
        this.FontSize.Width = this.Width / 5;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = true;
        this.SelectionButton.Checked = false;
    }

    private void FontToolStripMenuItemClick(object sender, EventArgs e) {
        this.StatusStrip.Invalidate();
        _ = this.FontDialog.ShowDialog();
        if (this.FontDialog.Font != TextFont) {
            TextFont = this.FontDialog.Font;
            this.FontName.Text = Convert.ToString(TextFont.Name);
            this.FontSize.Text = Convert.ToString(TextFont.Size);
        }
    }

    private void FontButtonClick(object sender, EventArgs e) {
        this.FontToolStripMenuItemClick(sender, e);
    }

    private void SelectionToolStripMenuItemClick(object sender, EventArgs e) {
        this.SelectionModeSetter();
    }

    private void SelectionModeSetter() {
        FigureType = 6;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = false;
        this.SelectionButton.Checked = true;

        this.RectangleToolStripMenuItem.Checked = false;
        this.EllipseToolStripMenuItem.Checked = false;
        this.StraightLineToolStripMenuItem.Checked = false;
        this.CurveLineToolStripMenuItem.Checked = false;
        this.TextToolStripMenuItem.Checked = false;
        this.SelectionToolStripMenuItem.Checked = true;

        this.IsSelectionMode = true;
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void SelectionButtonClick(object sender, EventArgs e) {
        this.SelectionModeSetter();
    }
}
