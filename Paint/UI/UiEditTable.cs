using Paint.Figures;
using Paint.Interfaces;
using Paint.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Paint.UI;

internal partial class UiEditTable : Form {
    private Size CanvasSize { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int PenSize { get; set; } = 2;
    private Color PenColor { get; set; } = Color.Black;
    private bool IsFilling { get; set; } = false;
    private Color BrushColor { get; set; } = Color.White;
    private Font TextFont { get; set; } = new("Times New Roman", 12.0f);
    private Dictionary<FiguresEnum, Tuple<ToolStripMenuItem>> FigureButton { get; set; }

    private FiguresEnum FigureType { get; set; }

    private TextBox? TextBox { get; set; }
    private TextBoxWrapper? Wrapper { get; set; }

    private static Dictionary<FiguresEnum, Type> WrapperTypes { get; set; } = new() {
        { FiguresEnum.Rectangle, typeof(RectangleWrapper) },
        { FiguresEnum.Ellipse, typeof(EllipseWrapper) },
        { FiguresEnum.StraightLine, typeof(StraightLineWrapper) },
        { FiguresEnum.CurveLine, typeof(CurveLineWrapper) },
        { FiguresEnum.TextBox, typeof(TextBoxWrapper) },
    };

    public UiEditTable() {
        this.InitializeComponent();

        this.FigureButton = new() {
        { FiguresEnum.Rectangle,new(this.RectangleButton) },
        { FiguresEnum.Ellipse, new(this.EllipseButton) },
        { FiguresEnum.StraightLine, new(this.StraightLineButton) },
        { FiguresEnum.CurveLine, new(this.CurveLineButton) }
    };
    }

    private void DeleteButtonClick(object sender, EventArgs e) {

    }
    
    private void RectangleButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent && parent.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState) {
            this.FigureType = FiguresEnum.Rectangle;
        }
    }
    
    private void EllipseButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent && parent.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState) {
            this.FigureType = FiguresEnum.Ellipse;
        }
    }
    
    private void StraightLineClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent && parent.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState) {
            this.FigureType = FiguresEnum.StraightLine;
        }
    }
    
    private void CurveLineClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent && parent.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState) {
            this.FigureType = FiguresEnum.CurveLine;
        }
    }
    
    private void PenSizeClick(object sender, EventArgs e) {
        var penSizeWindow = new UiPenSize(this, this.PenColor);

        if (penSizeWindow.ShowDialog() == DialogResult.OK) {
            if (this.MdiParent is UiCanvasWindow parent && parent.MdiParent is UiMainWindow) {
            }
        }
    }
    
    private void PenColorClick(object sender, EventArgs e) {

        var colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() == DialogResult.OK) {
            this.PenColor = colorDialog.Color;
        }
    }

    private void BrushColorButtonClick(object sender, EventArgs e) {

        var colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() == DialogResult.OK) {
            this.BrushColor = colorDialog.Color;
        }
    }
    
    private void FontButtonClick(object sender, EventArgs e) {

        DialogResult result = this.FontDialog.ShowDialog();
        if (result == DialogResult.OK) {
            this.TextFont = this.FontDialog.Font;
        }
    }

    private void OnTextBoxKeyDown(object? sender, KeyEventArgs e) {
        if (this.MdiParent is UiMainWindow) {
            UiCanvasWindow? canvasWindow = null;
            EditState editState;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is UiCanvasWindow window) {
                    canvasWindow = window;
                }
            }

            if (canvasWindow is not null && canvasWindow.State is EditState state) {
                editState = state;

                if (e.Shift && e.KeyCode == Keys.Enter && this.TextBox is not null && this.Wrapper is not null && canvasWindow is not null) {
                    this.TextBox.ReadOnly = true;
                    this.TextBox.Visible = false;
                    this.Wrapper.Text = this.TextBox.Text;
                    canvasWindow.SelectedFigures = editState.SelectedFigures;
                    canvasWindow.Figures = editState.Figures;
                    this.TextBox.Dispose();
                }
            }
        }
    }

    private void TextBoxButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow) {
            UiCanvasWindow? canvasWindow = null;
            EditState editState;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is UiCanvasWindow window) {
                    canvasWindow = window;
                }
            }

            if (canvasWindow is not null && canvasWindow.State is EditState state) {
                editState = state;

                if (editState.SelectedFigures.Count > 0 && editState.SelectedFigures[0] is TextBoxWrapper textBoxWrapper) {
                    var textBox = new TextBox() {
                        Parent = canvasWindow,
                        Font = this.TextFont,
                        Multiline = true,
                        ForeColor = this.PenColor,
                        Location = textBoxWrapper.TopPoint,
                        Width = textBoxWrapper.BotPoint.X - textBoxWrapper.TopPoint.X,
                        Height = textBoxWrapper.BotPoint.Y - textBoxWrapper.TopPoint.Y,
                        Text = textBoxWrapper.Text,
                    };

                    textBox.KeyDown += this.OnTextBoxKeyDown;

                    this.Wrapper = textBoxWrapper;
                    this.TextBox = textBox;
                }

                canvasWindow.SelectedFigures = editState.SelectedFigures;
                canvasWindow.Figures = editState.Figures;
            }
        }
    }
    
    private void CheckFigureButton(FiguresEnum? figureType) {
        if (figureType is null) {
            foreach (Tuple<ToolStripMenuItem> buttons in this.FigureButton.Values) {

                buttons.Item1.Checked = false;
            }
        } else {

            foreach (KeyValuePair<FiguresEnum, Tuple<ToolStripMenuItem>> pair in this.FigureButton) {
                FiguresEnum figureEnum = pair.Key;
                Tuple<ToolStripMenuItem> buttonPair = pair.Value;

                buttonPair.Item1.Checked = figureEnum == figureType;
            }
        }
    }
    
    private void OkButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow) {
            UiCanvasWindow? canvasWindow = null;
            EditState editState;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is UiCanvasWindow window) {
                    canvasWindow = window;
                }
            }

            if (canvasWindow is not null && canvasWindow.State is EditState state) {
                editState = state;

                if (editState.SelectedFigures.Count > 0) {
                    editState.SelectedFigures[0].PenSize = this.PenSize;
                    editState.SelectedFigures[0].BrushColor = this.BrushColor;
                    editState.SelectedFigures[0].PenColor = this.PenColor;
                    if (editState.SelectedFigures[0] is TextBoxWrapper textBoxWrapper) {
                        textBoxWrapper.TextFont = this.TextFont;
                    }
                }

                canvasWindow.SelectedFigures = editState.SelectedFigures;
                canvasWindow.Figures = editState.Figures;
            }
        }

        this.Close();

    }

    private void SaveButtonClick(object sender, EventArgs e) {

    }

    private void MoveButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow) {
            UiCanvasWindow? canvasWindow = null;
            EditState editState;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is UiCanvasWindow window) {
                    canvasWindow = window;
                }
            }

            if (canvasWindow is not null && canvasWindow.State is EditState state) {
                editState = state;

                if (editState.SelectedFigures.Count > 0) {
                    if (int.TryParse(this.TextX.Text, out int newX) && int.TryParse(this.TextY.Text, out int newY)) {

                        foreach (IDrawable figure in editState.SelectedFigures) {

                            int dx = newX - figure.TopPoint.X;
                            int dy = newY - figure.TopPoint.Y;

                            if (figure.CanMove(dx, dy, editState.CanvasSize)) {
                                figure.Move(dx, dy);
                                figure.UpdateResizePointsDict();
                            }
                        }

                        canvasWindow.SelectedFigures = editState.SelectedFigures;
                        canvasWindow.Figures = editState.Figures;

                    }
                }
            }
        }
    }

    private void UiEditTable_Load(object sender, EventArgs e) {

    }
}
