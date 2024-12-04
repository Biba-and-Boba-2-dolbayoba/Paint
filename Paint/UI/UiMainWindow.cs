using Paint.Figures;
using System.ComponentModel;
using System.Text.Json;

namespace Paint;

public partial class UiMainWindow : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CanvasWidth { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CanvasHeight { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Font TextFont { get; private set; } = new("Times New Roman", 12.0f);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int BrushSize { get; private set; } = 2;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color BrushColor { get; private set; } = Color.Black;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color FillingColor { get; private set; } = Color.White;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsFilling { get; private set; } = false;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int FigureType { get; private set; } = 1;

    private bool IsSelectionMode { get; set; } = false;

    public UiMainWindow() {
        this.InitializeComponent();
    }

    public void UpdatePointerInfo(Point p1, Point p2) {
        this.PointerInfo.Text = $"p1: {p1.X}, {p1.Y}; p2: {p2.X}, {p2.Y}";
    }
    class FigureJson {
        public string fontName { get; set; }
        public float fontSize { get; set; }
        public string LineColor { get; set; }
        public string BackColor { get; set; }
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public string Text { get; set; }
        public bool BackTF { get; set; }
        public Point[] MasPoints { get; set; }

        public void Serialize(List<Figure> figures) {
            foreach (Figure figure in figures) {
                this.fontName = figure.font.Name;
                this.fontSize = figure.font.Size;
                this.LineColor = Convert.ToHexString(
                    [figure.line_color.A, figure.line_color.R, figure.line_color.G, figure.line_color.B]

                );
                this.BackColor = Convert.ToHexString(
                    [figure.back_color.A, figure.back_color.R, figure.back_color.G, figure.back_color.B]
                    );
                this.Point1 = figure.point1;
                this.Point2 = figure.point2;
                this.Text = figure.text;
                this.BackTF = figure.back_TF;
                this.MasPoints = figure.mas_points;

            }
        }

        //public Figure Decode() {
        //    Figure figure = new Rect {
        //        font = new Font(this.fontName, this.fontSize),
        //        line_color = Color.FromArgb(Convert.ToInt32(this.LineColor)),
        //        back_color = Color.FromArgb(Convert.ToInt32(this.BackColor)),
        //        point1 = Point1,
        //        point2 = Point2,
        //        text = Text,
        //        back_TF = BackTF,
        //        mas_points = MasPoints.ToArray()
        //    };
        //    return figure ;
        }
    }
    public class CanvasData {
        public Size CanvasSize { get; set; }
        public List<FigureJson> Figures { get; set; }

        public CanvasData(Size size, List<Figure> figures) {
            CanvasSize = size;
            Figures = figures;
        }
    }
    
    public static void SaveFile(UiCanvasWindow canvas) {
        try {
            
            var canvasData = new CanvasData(
                canvas.CanvasSize,  
                canvas.Figures 
            );

            string json = JsonSerializer.Serialize(canvasData, new JsonSerializerOptions { WriteIndented = true });

            
            using (var saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    File.WriteAllText(saveFileDialog.FileName, json);
                    MessageBox.Show("Файл сохранен!");
                }
            }
        } catch (Exception ex) {
            MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
        }
    }

    private UiCanvasWindow OpenFile() {
        string fileName;
        var _canvas = new UiCanvasWindow {
            MdiParent = this,
        };

        var openFileDialog = new OpenFileDialog {
            InitialDirectory = Environment.CurrentDirectory,
            Filter = "Графический редактор (*.png)|*.png|All files(*.*)|*.*",
            FilterIndex = 1
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK) {
            try {
                fileName = openFileDialog.FileName;
                _canvas.CanvasName = fileName;
                _canvas.Text = Path.GetFileName(fileName);

                using var bitmap = new Bitmap(fileName);
                _canvas.Width = bitmap.Width;
                _canvas.Height = bitmap.Height;

                _canvas.BackgroundImage = bitmap;
                _canvas.BackgroundImageLayout = ImageLayout.Stretch;

            } catch (Exception ex) {
                _ = MessageBox.Show("Error opening file: " + ex.Message);
            }
        }

        return _canvas;
    }

    private bool IsWindowOpen() {
        return (this.ActiveMdiChild as UiCanvasWindow) != null;
    }

    private void UpdateFontInfo(Font font) {
        this.FontInfo.Text = $"{font.Name}, {font.SizeInPoints} pt";
    }

    public void UpdateBrushInfo(Color color, int size) {
        this.BrushColor = color;
        this.BrushSize = size;

        string hexColor = Convert.ToHexString(
            [color.A, color.R, color.G, color.B]
        );

        if (color.IsNamedColor) {
            this.BrushInfo.Text = $"{color.Name} ({hexColor}), {size} px";
        }

        this.BrushInfo.Text = $"{hexColor}, {size} px";
    }

    private void UpdateFillingInfo(Color color) {
        string hexColor = Convert.ToHexString(
            [color.A, color.R, color.G, color.B]
        );

        if (color.IsNamedColor) {
            this.FillingInfo.Text = $"{color.Name} ({hexColor})";
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

        this.UpdateFontInfo(this.TextFont);
        this.UpdateBrushInfo(this.BrushColor, this.BrushSize);
        this.UpdateFillingInfo(this.FillingColor);
    }

    private void FileToolButtonClick(object sender, EventArgs e) {
        this.SaveFileToolButton.Enabled = this.IsWindowOpen();
        this.SaveFileAsToolButton.Enabled = this.IsWindowOpen();
    }

    private void NewFileButtonClick(object sender, EventArgs e) {
        var sizeDialog = new UiCreateCanvas();
        _ = sizeDialog.ShowDialog(this);
        this.CanvasWidth = int.Parse(UiCreateCanvas.CanvasWidth);
        this.CanvasHeight = int.Parse(UiCreateCanvas.CanvasHeight);

        if (this.CanvasWidth > 0 && this.Height > 0) {
            var CanvasWindow = new UiCanvasWindow {
                MdiParent = this,
                Text = "Рисунок " + this.MdiChildren.Length.ToString()
            };
            CanvasWindow.Show();
        }
    }

    private void SaveFileButtonClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            SaveFile(activeForm);
        }
    }

    private void SaveFileAsButtonClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            UiCanvasWindow canvas = activeForm;
            canvas.CanvasName = null;
            SaveFile(canvas);
        }
    }

    private void OpenFileButtonClick(object sender, EventArgs e) {

        UiCanvasWindow canvas = this.OpenFile();
        canvas.Show();
    }

    private void CanvasSizeButtonClick(object sender, EventArgs e) {
        var sizeDialog = new UiCreateCanvas();
        _ = sizeDialog.ShowDialog(this);
        this.CanvasWidth = int.Parse(UiCreateCanvas.CanvasWidth);
        this.CanvasHeight = int.Parse(UiCreateCanvas.CanvasHeight);
    }

    private void BrushSizeButtonClick(object sender, EventArgs e) {
        var BrushSizeForm = new UiBrushSize {
            Text = "Изменение размера кисти",
            MdiParent = this
        };
        BrushSizeForm.Show();
    }

    private void BrushColorButtonClick(object sender, EventArgs e) {
        var colorDialog = new ColorDialog();
        _ = colorDialog.ShowDialog();

        this.UpdateBrushInfo(colorDialog.Color, this.BrushSize);
    }

    private void FillingButtonClick(object sender, EventArgs e) {
        if (!this.FillingToolButton.Checked && !this.FillingButton.Checked) {
            this.FillingToolButton.Checked = true;
            this.FillingButton.Checked = true;
            this.IsFilling = true;
        } else {
            this.FillingToolButton.Checked = false;
            this.FillingButton.Checked = false;
            this.IsFilling = false;
        }
    }

    private void FillingColorButtonClick(object sender, EventArgs e) {
        var colorDialog = new ColorDialog();
        _ = colorDialog.ShowDialog();

        this.FillingColor = colorDialog.Color;

        this.UpdateFillingInfo(this.FillingColor);
    }

    private void RectangleButtonClick(object sender, EventArgs e) {
        this.FigureType = 1;

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
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void EllipseButtonClick(object sender, EventArgs e) {
        this.FigureType = 2;

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
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void StraightLineButtonClick(object sender, EventArgs e) {
        this.FigureType = 3;

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
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void CurveLineButtonClick(object sender, EventArgs e) {
        this.FigureType = 4;
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
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void TextButtonClick(object sender, EventArgs e) {
        this.FigureType = 5;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = true;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = true;
        this.SelectionButton.Checked = false;

        this.IsSelectionMode = false;
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }

    private void FontButtonClick(object sender, EventArgs e) {
        _ = this.FontDialog.ShowDialog();

        this.TextFont = this.FontDialog.Font;

        this.UpdateFontInfo(this.TextFont);
    }

    private void SelectionButtonClick(object sender, EventArgs e) {
        this.FigureType = 6;

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
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            activeForm.IsSelectionMode = this.IsSelectionMode;
        }
    }
}
