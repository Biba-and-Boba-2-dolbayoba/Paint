using Paint.Figures;
using Paint.States;

namespace Paint;

public partial class UiMainWindow : Form {
    private Size CanvasSize { get; set; }
    private int PenSize { get; set; } = 2;
    private bool IsFilling { get; set; } = false;
    private Color PenColor { get; set; } = Color.Black;
    private Color BrushColor { get; set; } = Color.White;
    private Font TextFont { get; set; } = new("Times New Roman", 12.0f);
    private FiguresEnum FigureType { get; set; } = FiguresEnum.Rectangle;

    public UiMainWindow() {
        this.InitializeComponent();
    }

    //public class FigureJson {
    //    public string? FontName { get; set; }
    //    public float FontSize { get; set; }
    //    public string? LineColor { get; set; }
    //    public string? BackColor { get; set; }
    //    public Point Point1 { get; set; }
    //    public Point Point2 { get; set; }
    //    public string? Text { get; set; }
    //    public bool BackTF { get; set; }
    //    public Point[]? MasPoints { get; set; }

    //    public static List<FigureJson> Serialize(List<IFigure> figures) {
    //        List<FigureJson> figureJsonList = [];
    //        foreach (IFigure figure in figures) {
    //            var figureJson = new FigureJson() {
    //                FontName = figure.TextFont.Name,
    //                FontSize = figure.font.Size,
    //                LineColor = Convert.ToHexString(
    //                    [figure.line_color.A, figure.line_color.R, figure.line_color.G, figure.line_color.B]
    //                ),
    //                BackColor = Convert.ToHexString(
    //                    [figure.back_color.A, figure.back_color.R, figure.back_color.G, figure.back_color.B]
    //                ),
    //                Point1 = figure.point1,
    //                Point2 = figure.point2,
    //                Text = figure.text,
    //                BackTF = figure.back_TF,
    //                MasPoints = figure.mas_points,
    //            };
    //            figureJsonList.Add(figureJson);

    //        }

    //        return figureJsonList;
    //    }

    //    //public Figure Decode() {
    //    //    Figure figure = new Rect {
    //    //        font = new Font(this.fontName, this.fontSize),
    //    //        line_color = Color.FromArgb(Convert.ToInt32(this.LineColor)),
    //    //        back_color = Color.FromArgb(Convert.ToInt32(this.BackColor)),
    //    //        point1 = this.Point1,
    //    //        point2 = this.Point2,
    //    //        text = this.Text,
    //    //        back_TF = this.BackTF,
    //    //        mas_points = this.MasPoints.ToArray()
    //    //    };
    //    //    return figure;
    //    //}
    //}
    //public class CanvasData(Size size, List<Figure> figures) {
    //    public Size CanvasSize { get; set; } = size;
    //    public List<FigureJson> Figures { get; set; } = FigureJson.Serialize(figures);
    //}

    public static void SaveFile(UiCanvasWindow canvas) {
        //try {

        //    var canvasData = new CanvasData(
        //        canvas.CanvasSize,
        //        canvas.Figures
        //    );

        //    string json = JsonSerializer.Serialize(canvasData, new JsonSerializerOptions { WriteIndented = true });

        //    using var saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
        //    if (saveFileDialog.ShowDialog() == DialogResult.OK) {
        //        File.WriteAllText(saveFileDialog.FileName, json);
        //        _ = MessageBox.Show("Файл сохранен!");
        //    }
        //} catch (Exception ex) {
        //    _ = MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
        //}
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

                _canvas.BackgroundImage = Image.FromHbitmap(bitmap.GetHbitmap());
            } catch (Exception ex) {
                _ = MessageBox.Show("Error opening file: " + ex.Message);
            }
        }

        return _canvas;
    }

    private bool IsWindowOpen() {
        return (this.ActiveMdiChild as UiCanvasWindow) != null;
    }

    public void UpdatePointerInfo(Point point) {
        this.PointerInfo.Text = $"{point.X}, {point.Y} px";
    }

    public void UpdateCanvasInfo(Size canvasSize) {
        this.CanvasInfo.Text = $"{canvasSize.Width} x {canvasSize.Height}";

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is ICanvasSizeDepended state) {
            state.CanvasSize = canvasSize;
        }
    }

    private void UpdateFontInfo(Font font) {
        this.TextFont = font;

        this.FontInfo.Text = $"{font.Name}, {font.SizeInPoints} pt";

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.TextFont = this.TextFont;
        }
    }

    public void UpdatePenInfo(Color color, int size) {
        this.PenColor = color;
        this.PenSize = size;

        string hexColor = Convert.ToHexString(
            [color.A, color.R, color.G, color.B]
        );

        if (color.IsNamedColor) {
            this.BrushInfo.Text = $"{color.Name} ({hexColor}), {size} px";
        }

        this.BrushInfo.Text = $"{hexColor}, {size} px";

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.PenColor = this.PenColor;
            state.PenSize = this.PenSize;
        }
    }

    private void UpdateBrushInfo(Color color) {
        this.BrushColor = color;

        string hexColor = Convert.ToHexString(
            [color.A, color.R, color.G, color.B]
        );

        if (color.IsNamedColor) {
            this.FillingInfo.Text = $"{color.Name} ({hexColor})";
            return;
        }

        this.FillingInfo.Text = $"{hexColor}";

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.BrushColor = this.BrushColor;
        }
    }

    private void OnLoad(object sender, EventArgs e) {
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        this.UpdateStyles();

        this.UpdateFontInfo(this.TextFont);
        this.UpdatePenInfo(this.PenColor, this.PenSize);
        this.UpdateBrushInfo(this.BrushColor);
    }

    private void FileToolButtonClick(object sender, EventArgs e) {
        this.SaveFileToolButton.Enabled = this.IsWindowOpen();
        this.SaveFileAsToolButton.Enabled = this.IsWindowOpen();
    }

    private void NewFileButtonClick(object sender, EventArgs e) {
        var sizeDialog = new UiCreateCanvas();
        _ = sizeDialog.ShowDialog(this);

        this.CanvasSize = sizeDialog.CanvasSize;

        this.DrawingToolButtonClick(sender, e);

        var state = new DrawState() {
            PenColor = this.PenColor,
            PenSize = this.PenSize,
            BrushColor = this.BrushColor,
            TextFont = this.TextFont,
            FigureType = this.FigureType,
        };

        this.UpdateCanvasInfo(this.CanvasSize);

        if (this.CanvasSize.Width > 0 && this.CanvasSize.Height > 0) {
            var CanvasWindow = new UiCanvasWindow {
                MdiParent = this,
                Text = "Рисунок " + this.MdiChildren.Length.ToString(),
                State = state
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
        this.CanvasSize = sizeDialog.CanvasSize;
    }

    private void PenSizeButtonClick(object sender, EventArgs e) {
        var BrushSizeForm = new UiBrushSize {
            Text = "Изменение размера кисти",
            MdiParent = this,
            PenColor = this.PenColor
        };
        BrushSizeForm.Show();
    }

    private void PenColorButtonClick(object sender, EventArgs e) {
        var colorDialog = new ColorDialog();
        _ = colorDialog.ShowDialog();

        this.UpdatePenInfo(colorDialog.Color, this.PenSize);
    }

    private void FillingButtonClick(object sender, EventArgs e) {
        if (this.IsFilling) {
            this.IsFilling = false;
            this.FillingButton.Checked = false;
            this.FillingToolButton.Checked = false;

            return;
        }

        this.IsFilling = true;
        this.FillingButton.Checked = true;
        this.FillingToolButton.Checked = true;

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.IsFilling = this.IsFilling;
        }
    }

    private void BrushColorButtonClick(object sender, EventArgs e) {
        var colorDialog = new ColorDialog();
        _ = colorDialog.ShowDialog();

        this.UpdateBrushInfo(colorDialog.Color);
    }

    private void RectangleButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.Rectangle;

        this.RectangleToolButton.Checked = true;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = false;

        this.SelectionToolButton.Checked = false;
        this.DrawingToolButton.Checked = false;

        this.RectangleButton.Checked = true;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = false;

        this.SelectionButton.Checked = false;

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.Rectangle;
        }
    }

    private void EllipseButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.Ellipse;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = true;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = false;

        this.SelectionToolButton.Checked = false;
        this.DrawingToolButton.Checked = false;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = true;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = false;

        this.SelectionButton.Checked = false;

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.Ellipse;
        }
    }

    private void StraightLineButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.Line;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = true;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = false;

        this.SelectionToolButton.Checked = false;
        this.DrawingToolButton.Checked = false;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = true;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = false;

        this.SelectionButton.Checked = false;

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.Line;
        }
    }

    private void CurveLineButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.CurveLine;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = true;
        this.TextToolButton.Checked = false;

        this.SelectionToolButton.Checked = false;
        this.DrawingToolButton.Checked = false;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = true;
        this.TextButton.Checked = false;

        this.SelectionButton.Checked = false;

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.CurveLine;
        }
    }

    private void TextButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.TextBox;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = true;

        this.SelectionButton.Checked = false;

        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = true;

        this.SelectionToolButton.Checked = false;
        this.DrawingToolButton.Checked = false;

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.TextBox;
        }
    }

    private void FontButtonClick(object sender, EventArgs e) {
        _ = this.FontDialog.ShowDialog();

        this.UpdateFontInfo(this.FontDialog.Font);
    }

    private void SelectionButtonClick(object sender, EventArgs e) {
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
        this.DrawingToolButton.Checked = false;

        if (this.ActiveMdiChild is UiCanvasWindow children) {
            var state = new SelectState() {
                Figures = children.Figures,
                CanvasSize = this.CanvasSize
            };

            children.State = state;
        }
    }

    private void DrawingToolButtonClick(object sender, EventArgs e) {
        this.RectangleButton.Checked = false;
        this.EllipseButton.Checked = false;
        this.StraightLineButton.Checked = false;
        this.CurveLineButton.Checked = false;
        this.TextButton.Checked = false;

        this.SelectionButton.Checked = false;

        this.RectangleToolButton.Checked = false;
        this.EllipseToolButton.Checked = false;
        this.StraightLineToolButton.Checked = false;
        this.CurveLineToolButton.Checked = false;
        this.TextToolButton.Checked = false;

        this.SelectionToolButton.Checked = false;
        this.DrawingToolButton.Checked = true;

        if (this.ActiveMdiChild is UiCanvasWindow children) {
            var state = new DrawState() {
                PenColor = this.PenColor,
                PenSize = this.PenSize,
                BrushColor = this.BrushColor,
                TextFont = this.TextFont,
                FigureType = this.FigureType,
                Figures = children.Figures,
            };

            children.State = state;
        }
    }
}
