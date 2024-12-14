using Paint.depricated.Figures;
using Paint.depricated.Interfaces;
using Paint.States.depricated;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Paint.UI;

internal partial class EditForm : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int PenSize { get; set; } = 2;
    private Color PenColor { get; set; } = Color.Black;
    private Color BrushColor { get; set; } = Color.White;
    private Font TextFont { get; set; } = new("Times New Roman", 12.0f);
    private Dictionary<FigureTypes, Tuple<ToolStripMenuItem>> FigureButton { get; set; }

    private FigureTypes? FigureType { get; set; } = null;

    private static Dictionary<FigureTypes, Type> WrapperTypes { get; set; } = new() {
        { FigureTypes.Rectangle, typeof(RectangleWrapper) },
        { FigureTypes.Ellipse, typeof(EllipseWrapper) },
        { FigureTypes.StraightLine, typeof(StraightLineWrapper) },
        { FigureTypes.CurveLine, typeof(CurveLineWrapper) },
        { FigureTypes.TextBox, typeof(TextBoxWrapper) },
    };

    private TextBoxWrapper? Wrapper { get; set; }
    private TextBox? TextBox { get; set; }

    public EditForm() {
        this.InitializeComponent();

        this.FigureButton = new() {
        { FigureTypes.Rectangle,new(this.RectangleButton) },
        { FigureTypes.Ellipse, new(this.EllipseButton) },
        { FigureTypes.StraightLine, new(this.StraightLineButton) },

    };
    }

    private void DeleteButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is MainForm) {
            CanvasForm? canvasWindow = null;
            EditState editState;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is CanvasForm window) {
                    canvasWindow = window;
                }
            }

            if (canvasWindow is not null && canvasWindow.State is EditState state) {
                editState = state;

                if (editState.SelectedFigures.Count > 0) {

                    foreach (IDrawable figure in editState.SelectedFigures) {
                        _ = editState.Figures.Remove(figure);
                    }

                    editState.SelectedFigures.Clear();

                    canvasWindow.SelectedFigures = editState.SelectedFigures;
                    canvasWindow.Figures = editState.Figures;
                }
            }
        }
    }

    private void RectangleButtonClick(object sender, EventArgs e) {
        this.FigureType = FigureTypes.Rectangle;
    }

    private void EllipseButtonClick(object sender, EventArgs e) {
        this.FigureType = FigureTypes.Ellipse;
    }

    private void StraightLineClick(object sender, EventArgs e) {
        this.FigureType = FigureTypes.StraightLine;
    }

    private void CurveLineClick(object sender, EventArgs e) {
        this.FigureType = FigureTypes.CurveLine;
    }

    private void PenSizeClick(object sender, EventArgs e) {
        var penSizeWindow = new PenSizeForm(this, this.PenColor);

        if (penSizeWindow.ShowDialog() == DialogResult.OK) {
            if (this.MdiParent is CanvasForm parent && parent.MdiParent is MainForm) {
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
        if (this.MdiParent is MainForm) {
            CanvasForm? canvasWindow = null;
            EditState editState;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is CanvasForm window) {
                    canvasWindow = window;
                }
            }

            if (canvasWindow is not null && canvasWindow.State is EditState state) {
                editState = state;
                if (e.Shift && e.KeyCode == Keys.Enter && this.TextBox is not null && this.Wrapper is not null) {
                    this.TextBox.ReadOnly = true;
                    this.TextBox.Visible = false;
                    this.Wrapper.Text = this.TextBox.Text;
                    this.TextBox.Dispose();
                }

                canvasWindow.SelectedFigures = editState.SelectedFigures;
                canvasWindow.Figures = editState.Figures;
            }
        }
    }

    private void TextBoxButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is MainForm) {
            CanvasForm? canvasWindow = null;
            EditState editState;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is CanvasForm window) {
                    canvasWindow = window;
                }
            }

            if (canvasWindow is not null && canvasWindow.State is EditState state) {
                editState = state;
                if (editState.SelectedFigures[0] is TextBoxWrapper textBoxWrapper) {
                    textBoxWrapper.TextFont = this.TextFont;
                    var textBox = new TextBox() {
                        Parent = canvasWindow,
                        Font = textBoxWrapper.TextFont,
                        Multiline = true,
                        ForeColor = textBoxWrapper.PenColor,
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

    private void OkButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is MainForm) {
            CanvasForm? canvasWindow = null;
            EditState editState;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is CanvasForm window) {
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
        if (this.MdiParent is MainForm) {
            CanvasForm? canvasWindow = null;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is CanvasForm window) {
                    canvasWindow = window;
                }
            }

            if (canvasWindow is not null && canvasWindow.State is EditState editState && this.FigureType is not null) {
                var figureType = (FigureTypes)this.FigureType;
                var wrapper = (IDrawable?)Activator.CreateInstance(WrapperTypes[figureType]);

                if (wrapper is not null) {
                    wrapper.PenSize = this.PenSize;
                    wrapper.PenColor = this.PenColor;
                    wrapper.BrushColor = this.BrushColor;
                    wrapper.TopPoint = new Point(100, 100);
                    wrapper.BotPoint = new Point(400, 400);
                    wrapper.IsFilling = false;
                    wrapper.FigureType = figureType;

                    if (wrapper is StraightLineWrapper straightLineWrapper) {
                        straightLineWrapper.StartPoint = new Point(wrapper.TopPoint.X, wrapper.TopPoint.Y);
                        straightLineWrapper.EndPoint = new Point(wrapper.TopPoint.X, wrapper.TopPoint.Y);
                    }

                    editState.Figures.Add(wrapper);
                }

                canvasWindow.SelectedFigures = editState.SelectedFigures;
                canvasWindow.Figures = editState.Figures;
            }
        }
    }

    private void MoveButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is MainForm) {
            CanvasForm? canvasWindow = null;
            EditState editState;
            foreach (Form child in this.MdiParent.MdiChildren) {
                if (child is CanvasForm window) {
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
