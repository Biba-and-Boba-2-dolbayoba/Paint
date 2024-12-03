using System.ComponentModel;

namespace Paint;

public partial class UxMainWindow : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int CanvasWidth { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int CanvasHeight { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int BrushSize { get; private set; } = 12;

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

        if (_canvas.CanvasName == null) {
            var saveFileDialog1 = new SaveFileDialog {
                InitialDirectory = Environment.CurrentDirectory,
                Filter = "Графический редактор (*.png)|*.png|All files(*.*)|*.*",
                FilterIndex = 1
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                fileName = saveFileDialog1.FileName;
                _canvas.CanvasName = fileName;
            }
        } else {
            fileName = _canvas.CanvasName;
            _canvas.Text = Path.GetFileName(fileName);
        }
    }

    private void BrushSizeFormClosing(object? sender, FormClosingEventArgs e) {
        this.StatusStrip.Invalidate();
        BrushSize = Convert.ToInt32(UxBrushSize.BrushSize);
        UpdateBrushInfo();
    }

    private bool IsWindowOpen() {
        return (this.ActiveMdiChild as UxCanvasWindow) != null;
    }

    private void UpdateFontInfo() {
        this.FontInfo.Text = $"{TextFont.Name}, {TextFont.SizeInPoints} pt";
    }
    
    private void UpdateBrushInfo() {
        string hexColor = Convert.ToHexString(
            [LineColor.A, LineColor.R, LineColor.G, LineColor.B]
        );

        if (LineColor.IsNamedColor) {
            this.BrushInfo.Text = $"{LineColor.Name} ({hexColor}), {BrushSize} px";
            return;
        }

        this.BrushInfo.Text = $"{hexColor}, {BrushSize} px";
    }

    private void UpdateFillingInfo() {
        string hexColor = Convert.ToHexString(
            [BackgroundColor.A, BackgroundColor.R, BackgroundColor.G, BackgroundColor.B]
        );

        if (BackgroundColor.IsNamedColor) {
            this.FillingInfo.Text = $"{BackgroundColor.Name} ({hexColor})";
            return;
        }

        this.FillingInfo.Text = $"{hexColor}";
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

        UpdateFontInfo();
        UpdateBrushInfo();
        UpdateFillingInfo();
    }

    private void FileToolButtonClick(object sender, EventArgs e) {
        this.SaveFileToolButton.Enabled = this.IsWindowOpen();
        this.SaveFileAsToolButton.Enabled = this.IsWindowOpen();
    }

    private void NewFileButtonClick(object sender, EventArgs e) {
        if (CanvasWidth > 0 && CanvasHeight > 0) {
            var CanvasWindow = new UxCanvasWindow {
                MdiParent = this,
                Text = "Рисунок " + this.MdiChildren.Length.ToString()
            };
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
                CanvasWindow.Show();
            }
        }
    }

    private void SaveFileButtonClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            SaveFile(activeForm);
        }
    }

    private void SaveFileAsButtonClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            UxCanvasWindow canvas = activeForm;
            canvas.CanvasName = null;
            SaveFile(canvas);
        }
    }

    private void OpenFileButtonClick(object sender, EventArgs e) {
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

    private void CanvasSizeButtonClick(object sender, EventArgs e) {
        var sizeDialog = new UxCreateCanvas();
        _ = sizeDialog.ShowDialog(this);
        CanvasWidth = int.Parse(UxCreateCanvas.CanvasWidth);
        CanvasHeight = int.Parse(UxCreateCanvas.CanvasHeight);
    }

    private void BrushSizeButtonClick(object sender, EventArgs e) {
        var BrushSize = new UxBrushSize {
            Text = "Изменение размера кисти",
            MdiParent = this
        };
        BrushSize.FormClosing += this.BrushSizeFormClosing;
        BrushSize.Show();
    }

    private void BrushColorButtonClick(object sender, EventArgs e) {
        this.StatusStrip.Invalidate();
        var colorDialog = new ColorDialog();
        colorDialog.ShowDialog();
        LineColor = colorDialog.Color;

        UpdateBrushInfo();
    }

    private void FillingButtonClick(object sender, EventArgs e) {
        if (this.FillingToolButton.Checked) {
            this.FillingButton.Checked = true;
        } else {
            this.FillingButton.Checked = false;
        }

        if (this.FillingButton.Checked) {
            this.FillingToolButton.Checked = true;
        } else {
            this.FillingToolButton.Checked = false;
        }

        IsFilling = this.FillingToolButton.Checked == true;
    }

    private void FillingColorButtonClick(object sender, EventArgs e) {
        this.StatusStrip.Invalidate();

        var colorDialog = new ColorDialog();
        colorDialog.ShowDialog();

        BackgroundColor = colorDialog.Color;

        UpdateFillingInfo();
    }

    private void RectangleButtonClick(object sender, EventArgs e) {
        FigureType = 1;

        this.RectangleToolButton.Checked = true;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = false;
        this.SelectionToolButton.Checked = false;

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

    private void EllipseButtonClick(object sender, EventArgs e) {
        FigureType = 2;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = true;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = false;
        this.SelectionToolButton.Checked = false;

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

    private void StraightLineButtonClick(object sender, EventArgs e) {
        FigureType = 3;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = true;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = false;
        this.SelectionToolButton.Checked = false;

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

    private void CurveLineButtonClick(object sender, EventArgs e) {
        FigureType = 4;
        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = true;
        this.TextToolButton.Checked = false;
        this.SelectionToolButton.Checked = false;

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

    private void TextButtonClick(object sender, EventArgs e) {
        FigureType = 5;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = true;

        this.StatusStrip.Invalidate();

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

    private void FontButtonClick(object sender, EventArgs e) {
        this.StatusStrip.Invalidate();

        _ = this.FontDialog.ShowDialog();

        TextFont = this.FontDialog.Font;

        UpdateFontInfo();
    }

    private void SelectionButtonClick(object sender, EventArgs e) {
        FigureType = 6;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = false;
        this.SelectionButton.Checked = true;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = false;
        this.SelectionToolButton.Checked = true;

        this.IsSelectionMode = true;
        if (this.ActiveMdiChild is UxCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }
}
