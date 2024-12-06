using Paint.Figures;
using Paint.Serialization;
using Paint.States;

namespace Paint;

internal partial class UiMainWindow : Form {
    private Size CanvasSize { get; set; }
    private int PenSize { get; set; } = 2;
    private Color PenColor { get; set; } = Color.Black;
    private bool IsFilling { get; set; } = false;
    private Color BrushColor { get; set; } = Color.White;
    private Font TextFont { get; set; } = new("Times New Roman", 12.0f);
    private FiguresEnum FigureType { get; set; } = FiguresEnum.Rectangle;
    private Dictionary<FiguresEnum, Tuple<ToolStripButton, ToolStripMenuItem>> Buttons { get; set; }

    public UiMainWindow() {
        this.InitializeComponent();

        this.Buttons = new() {
            {FiguresEnum.Rectangle, new(this.RectangleButton, this.RectangleToolButton)},
            {FiguresEnum.Ellipse, new(this.EllipseButton, this.EllipseToolButton)},
            {FiguresEnum.Line, new(this.StraightLineButton, this.StraightLineToolButton)},
            {FiguresEnum.CurveLine, new(this.CurveLineButton, this.CurveLineToolButton)},
            {FiguresEnum.TextBox, new(this.TextButton, this.TextToolButton)},
        };
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

    private void CheckFigureButton(FiguresEnum figureType) {
        foreach (KeyValuePair<FiguresEnum, Tuple<ToolStripButton, ToolStripMenuItem>> buttons in this.Buttons) {
            if (buttons.Key == figureType) {
                buttons.Value.Item1.Checked = true;
                buttons.Value.Item2.Checked = true;
                continue;
            }

            buttons.Value.Item1.Checked = false;
            buttons.Value.Item2.Checked = false;
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
            HashableCanvas.SaveFile(activeForm.Size, activeForm.Name, activeForm.Figures);
        }
    }

    private void SaveFileAsButtonClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            HashableCanvas.SaveFile(activeForm.Size, null, activeForm.Figures);
        }
    }

    private void OpenFileButtonClick(object sender, EventArgs e) {
        _ = HashableCanvas.OpenFile();
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

    private void FontButtonClick(object sender, EventArgs e) {
        _ = this.FontDialog.ShowDialog();

        this.UpdateFontInfo(this.FontDialog.Font);
    }

    private void BrushColorButtonClick(object sender, EventArgs e) {
        var colorDialog = new ColorDialog();
        _ = colorDialog.ShowDialog();

        this.UpdateBrushInfo(colorDialog.Color);
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

    private void RectangleButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.Rectangle;
        this.CheckFigureButton(this.FigureType);

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.Rectangle;
        }
    }

    private void EllipseButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.Ellipse;
        this.CheckFigureButton(this.FigureType);

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.Ellipse;
        }
    }

    private void StraightLineButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.Line;
        this.CheckFigureButton(this.FigureType);

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.Line;
        }
    }

    private void CurveLineButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.CurveLine;
        this.CheckFigureButton(this.FigureType);

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.CurveLine;
        }
    }

    private void TextButtonClick(object sender, EventArgs e) {
        this.FigureType = FiguresEnum.TextBox;
        this.CheckFigureButton(this.FigureType);

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.TextBox;
        }
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
