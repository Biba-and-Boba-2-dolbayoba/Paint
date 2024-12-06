using Paint.Interfaces;
using Paint.Serialization;
using Paint.States;
using System.Windows.Forms;

namespace Paint;

internal partial class UiMainWindow : Form {
    private Size CanvasSize { get; set; }
    private int PenSize { get; set; } = 2;
    private Color PenColor { get; set; } = Color.Black;
    private bool IsFilling { get; set; } = false;
    private Color BrushColor { get; set; } = Color.White;
    private Font TextFont { get; set; } = new("Times New Roman", 12.0f);
    private Dictionary<FiguresEnum, Tuple<ToolStripButton, ToolStripMenuItem>> Buttons { get; set; }

    private class ToolStripRenderer : ToolStripProfessionalRenderer {
        public ToolStripRenderer() : base() {
            this.RoundedEdges = false;
        }
    }

    public UiMainWindow() {
        this.InitializeComponent();

        this.ToolStrip.Renderer = new ToolStripRenderer();

        this.Buttons = new() {
            {FiguresEnum.Rectangle, new(this.RectangleButton, this.RectangleToolButton)},
            {FiguresEnum.Ellipse, new(this.EllipseButton, this.EllipseToolButton)},
            {FiguresEnum.StraightLine, new(this.StraightLineButton, this.StraightLineToolButton)},
            {FiguresEnum.CurveLine, new(this.CurveLineButton, this.CurveLineToolButton)},
            {FiguresEnum.TextBox, new(this.TextButton, this.TextToolButton)},
        };
    }

    public void UpdatePointerInfo(Point point) {
        this.PointerInfo.Text = $"{point.X}, {point.Y} px";
    }

    public void UpdateCanvasInfo(Size canvasSize) {
        this.CanvasInfo.Text = $"{canvasSize.Width} x {canvasSize.Height}";

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is ICanvasSizeDepends state) {
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
        this.UpdateFontInfo(this.TextFont);
        this.UpdatePenInfo(this.PenColor, this.PenSize);
        this.UpdateBrushInfo(this.BrushColor);
    }

    private void NewFileButtonClick(object sender, EventArgs e) {
        var sizeDialog = new UiCreateCanvas();
        _ = sizeDialog.ShowDialog(this);

        this.CanvasSize = sizeDialog.CanvasSize;
        this.CanvasPlaceholder.Size = this.CanvasSize;

        this.DrawingToolButtonClick(sender, e);

        var state = new DrawState() {
            CanvasSize = this.CanvasSize,
            PenColor = this.PenColor,
            PenSize = this.PenSize,
            BrushColor = this.BrushColor,
            TextFont = this.TextFont,
            FigureType = FiguresEnum.Rectangle,
        };

        this.UpdateCanvasInfo(this.CanvasSize);

        if (this.CanvasSize.Width > 0 && this.CanvasSize.Height > 0) {
            var canvasWindow = new UiCanvasWindow {
                MdiParent = this,
                Bounds = this.CanvasPlaceholder.Bounds,
                Text = "Рисунок " + this.MdiChildren.Length.ToString(),
                State = state,
                Size = this.CanvasSize
            };

            canvasWindow.Show();
        }
    }

    private void SaveFileButtonClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            HashableCanvas.SaveFile(activeForm.Size, activeForm.Figures);
        }
    }

    private void SaveFileAsButtonClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            HashableCanvas.SaveFile(activeForm.Size, activeForm.Figures);
        }
    }

    private void OpenFileButtonClick(object sender, EventArgs e) {
        HashableCanvas? canvas = HashableCanvas.OpenFile();

        if (canvas is null) return;

        this.CanvasSize = canvas.CanvasSize;
        this.CanvasPlaceholder.Size = this.CanvasSize;

        this.DrawingToolButtonClick(sender, e);

        var state = new DrawState() {
            CanvasSize = this.CanvasSize,
            PenColor = this.PenColor,
            PenSize = this.PenSize,
            BrushColor = this.BrushColor,
            TextFont = this.TextFont,
            FigureType = FiguresEnum.Rectangle,
        };

        this.UpdateCanvasInfo(this.CanvasSize);

        if (this.CanvasSize.Width > 0 && this.CanvasSize.Height > 0) {
            var canvasWindow = new UiCanvasWindow {
                MdiParent = this,
                Bounds = this.CanvasPlaceholder.Bounds,
                Text = "Рисунок " + this.MdiChildren.Length.ToString(),
                State = state,
                Size = this.CanvasSize
            };

            canvasWindow.Show();
        }
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
        this.CheckFigureButton(FiguresEnum.Rectangle);

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.Rectangle;
        }
    }

    private void EllipseButtonClick(object sender, EventArgs e) {
        this.CheckFigureButton(FiguresEnum.Ellipse);

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.Ellipse;
        }
    }

    private void StraightLineButtonClick(object sender, EventArgs e) {
        this.CheckFigureButton(FiguresEnum.StraightLine);

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.StraightLine;
        }
    }

    private void CurveLineButtonClick(object sender, EventArgs e) {
        this.CheckFigureButton(FiguresEnum.CurveLine);

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.FigureType = FiguresEnum.CurveLine;
        }
    }

    private void TextButtonClick(object sender, EventArgs e) {
        this.CheckFigureButton(FiguresEnum.TextBox);

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
        this.CheckFigureButton(FiguresEnum.Rectangle);

        this.SelectionButton.Checked = false;
        this.SelectionToolButton.Checked = false;
        this.DrawingToolButton.Checked = true;

        if (this.ActiveMdiChild is UiCanvasWindow child) {
            var state = new DrawState() {
                PenColor = this.PenColor,
                PenSize = this.PenSize,
                BrushColor = this.BrushColor,
                TextFont = this.TextFont,
                FigureType = FiguresEnum.Rectangle,
                Figures = child.Figures,
            };

            child.State = state;
        }
    }
}
