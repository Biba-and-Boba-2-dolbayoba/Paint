using Paint.Interfaces;
using Paint.Serialization;
using Paint.Serialization.Models;
using Paint.States;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint;

internal partial class UiMainWindow : Form {
    private Size CanvasSize { get; set; }
    private int PenSize { get; set; } = 2;
    private Color PenColor { get; set; } = Color.Black;
    private bool IsFilling { get; set; } = false;
    private Color BrushColor { get; set; } = Color.White;
    private Font TextFont { get; set; } = new("Times New Roman", 12.0f);
    private Dictionary<FiguresEnum, Tuple<ToolStripButton, ToolStripMenuItem>> FigureButtons { get; set; }
    private Dictionary<StatesEnum, Tuple<ToolStripButton, ToolStripMenuItem>> StateButtons { get; set; }
    private bool ShowGrid = false;
    private bool SnapToGrid { get; set; } = false;

    private class ToolStripRenderer : ToolStripProfessionalRenderer {
        public ToolStripRenderer() : base() {
            this.RoundedEdges = false;
        }
    }

    public UiMainWindow() {
        this.InitializeComponent();

        this.ToolStrip.Renderer = new ToolStripRenderer();

        this.FigureButtons = new() {
            {FiguresEnum.Rectangle, new(this.RectangleButton, this.RectangleToolButton)},
            {FiguresEnum.Ellipse, new(this.EllipseButton, this.EllipseToolButton)},
            {FiguresEnum.StraightLine, new(this.StraightLineButton, this.StraightLineToolButton)},
            {FiguresEnum.CurveLine, new(this.CurveLineButton, this.CurveLineToolButton)},
            {FiguresEnum.TextBox, new(this.TextButton, this.TextToolButton)},
        };

        this.StateButtons = new() {
            {StatesEnum.DrawState, new(this.DrawingButton, this.DrawingToolButton)},
            {StatesEnum.SelectState, new(this.SelectionButton, this.SelectionToolButton)},
            {StatesEnum.EditState, new(this.EditButton, this.EditToolButton)},
        };

    }

    public void UpdatePointerInfo(Point point) {
        this.PointerInfo.Text = $"{point.X}, {point.Y} px";
    }

    public void UpdateCanvasInfo(Size canvasSize) {
        this.CanvasSize = new Size(canvasSize.Width, canvasSize.Height);
        this.CanvasInfo.Text = $"{canvasSize.Width} x {canvasSize.Height}";
    }

    public void UpdatePenInfo(Color color, int size) {
        this.PenColor = color;
        this.PenSize = size;

        string hexColor = Convert.ToHexString(
            [color.A, color.R, color.G, color.B]
        );

        if (color.IsNamedColor) {
            this.PenInfo.Text = $"{color.Name} ({hexColor}), {size} px";
        }

        this.PenInfo.Text = $"{hexColor}, {size} px";

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
            this.BrushInfo.Text = $"{color.Name} ({hexColor})";
            return;
        }

        this.BrushInfo.Text = $"{hexColor}";

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.BrushColor = this.BrushColor;
        }
    }

    private void UpdateFontInfo(Font font) {
        this.TextFont = font;

        this.FontInfo.Text = $"{font.Name}, {font.SizeInPoints} pt";

        if (this.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            state.TextFont = this.TextFont;
        }
    }

    private void CheckFigureButton(FiguresEnum? figureType) {
        if (figureType is null) {
            foreach (KeyValuePair<FiguresEnum, Tuple<ToolStripButton, ToolStripMenuItem>> buttons in this.FigureButtons) {
                buttons.Value.Item1.Checked = false;
                buttons.Value.Item2.Checked = false;
            }
        }

        foreach (KeyValuePair<FiguresEnum, Tuple<ToolStripButton, ToolStripMenuItem>> buttons in this.FigureButtons) {
            if (buttons.Key == figureType) {
                buttons.Value.Item1.Checked = true;
                buttons.Value.Item2.Checked = true;
                continue;
            }

            buttons.Value.Item1.Checked = false;
            buttons.Value.Item2.Checked = false;
        }
    }

    private void CheskStateButton(StatesEnum stateType) {
        if (stateType != StatesEnum.DrawState) {
            foreach (KeyValuePair<FiguresEnum, Tuple<ToolStripButton, ToolStripMenuItem>> buttons in this.FigureButtons) {
                buttons.Value.Item1.Enabled = false;
                buttons.Value.Item2.Enabled = false;
            }
        } else {
            foreach (KeyValuePair<FiguresEnum, Tuple<ToolStripButton, ToolStripMenuItem>> buttons in this.FigureButtons) {
                buttons.Value.Item1.Enabled = true;
                buttons.Value.Item2.Enabled = true;
            }
        }

        foreach (KeyValuePair<StatesEnum, Tuple<ToolStripButton, ToolStripMenuItem>> buttons in this.StateButtons) {
            if (buttons.Key == stateType) {
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

    private void NewCanvasButtonClick(object sender, EventArgs e) {
        var canvasSizeWindow = new UiCanvasSize(this);

        if (canvasSizeWindow.ShowDialog() == DialogResult.OK) {
            var state = new DrawState() {
                CanvasSize = this.CanvasSize,
                PenColor = this.PenColor,
                PenSize = this.PenSize,
                BrushColor = this.BrushColor,
                TextFont = this.TextFont,
                FigureType = FiguresEnum.Rectangle,
            };

            if (this.CanvasSize.Width > 0 && this.CanvasSize.Height > 0) {
                var canvasWindow = new UiCanvasWindow() {
                    MdiParent = this,
                    Text = "Рисунок " + this.MdiChildren.Length.ToString(),
                    State = state,
                    Size = this.CanvasSize
                };
                state.ParentReference = canvasWindow;
                canvasWindow.State = state;

                canvasWindow.Show();
            }
        }
    }

    private void SaveCanvasButtonClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UiCanvasWindow activeForm) {
            JsonReader.Save(activeForm.Size, activeForm.Figures);
        }
    }

    private void OpenCanvasButtonClick(object sender, EventArgs e) {
        HashableCanvas? canvas = JsonReader.Open();

        if (canvas is null) {
            return;
        }

        List<IDrawable> figures = JsonReader.ToDrawable(canvas.Figures);

        this.CanvasSize = new Size(canvas.CanvasSize.Item1, canvas.CanvasSize.Item2);
        this.UpdateCanvasInfo(new Size(canvas.CanvasSize.Item1, canvas.CanvasSize.Item2));

        var state = new DrawState() {
            PenColor = this.PenColor,
            PenSize = this.PenSize,
            BrushColor = this.BrushColor,
            TextFont = this.TextFont,
            FigureType = FiguresEnum.Rectangle,
            Figures = figures,
            CanvasSize = this.CanvasSize,
        };

        if (this.CanvasSize.Width > 0 && this.CanvasSize.Height > 0) {
            var canvasWindow = new UiCanvasWindow() {
                MdiParent = this,
                Text = "Рисунок " + this.MdiChildren.Length.ToString(),
                Size = this.CanvasSize,
                State = state,
                Figures = figures,
            };
            state.ParentReference = canvasWindow;
            canvasWindow.State = state;
            canvasWindow.Show();
        }
    }

    private void PenSizeButtonClick(object sender, EventArgs e) {
        var penSizeWindow = new UiPenSize(this, this.PenColor);

        if (penSizeWindow.ShowDialog() == DialogResult.OK) {
            return;
        }
    }

    private void PenColorButtonClick(object sender, EventArgs e) {
        var colorDialog = new ColorDialog();
        _ = colorDialog.ShowDialog();

        this.UpdatePenInfo(colorDialog.Color, this.PenSize);
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

    private void FontButtonClick(object sender, EventArgs e) {
        _ = this.FontDialog.ShowDialog();
        this.FontDialog.Font = this.TextFont;

        this.UpdateFontInfo(this.FontDialog.Font);
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

    private void DrawingButtonClick(object sender, EventArgs e) {
        this.CheckFigureButton(FiguresEnum.Rectangle);
        this.CheskStateButton(StatesEnum.DrawState);

        if (this.ActiveMdiChild is UiCanvasWindow child) {
            var state = new DrawState() {
                PenColor = this.PenColor,
                PenSize = this.PenSize,
                BrushColor = this.BrushColor,
                TextFont = this.TextFont,
                FigureType = FiguresEnum.Rectangle,
                Figures = child.Figures,
                CanvasSize = child.Size,
                ParentReference = child,
            };
            child.SelectedFigures.Clear();
            child.State = state;
        }
    }

    private void SelectionButtonClick(object sender, EventArgs e) {
        this.CheckFigureButton(null);
        this.CheskStateButton(StatesEnum.SelectState);

        if (this.ActiveMdiChild is UiCanvasWindow child) {
            var state = new SelectState() {
                Figures = child.Figures,
                CanvasSize = child.Size,
            };

            child.State = state;
        }
    }

    private void EditButtonClick(object sender, EventArgs e) {

    }


    private void GridToolButtonClick(object sender, EventArgs e) {
        if (this.ActiveMdiChild is UiCanvasWindow activeCanvas) {

            activeCanvas.ToggleGrid();
        }
    }

    private void SnapToGridToolButtonClick(object sender, EventArgs e) {
        this.SnapToGrid = !this.SnapToGrid;

        
        this.SnapToGridButton.Checked = this.SnapToGrid;
        this.SnapToGridToolButton.Checked = this.SnapToGrid;
    }
}
