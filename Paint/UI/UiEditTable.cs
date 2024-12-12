using System.Windows.Forms;
using System;
using Paint.Figures;
using Paint.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using Paint.States;
using System.ComponentModel;


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


    private static Dictionary<FiguresEnum, Type> WrapperTypes { get; set; } = new() {
        { FiguresEnum.Rectangle, typeof(RectangleWrapper) },
        { FiguresEnum.Ellipse, typeof(EllipseWrapper) },
        { FiguresEnum.StraightLine, typeof(StraightLineWrapper) },
        { FiguresEnum.CurveLine, typeof(CurveLineWrapper) },
        { FiguresEnum.TextBox, typeof(TextBoxWrapper) },
    };

    public UiEditTable() {
        InitializeComponent();

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
        if (this.MdiParent is UiMainWindow parent && parent.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            this.FigureType = FiguresEnum.Rectangle;
        }
    }
    private void EllipseButtonClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent && parent.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            this.FigureType = FiguresEnum.Ellipse;
        }
    }
    private void StraightLineClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent && parent.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            this.FigureType = FiguresEnum.StraightLine;
        }
    }
    private void CurveLineClick(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent && parent.ActiveMdiChild is UiCanvasWindow children && children.State is DrawState state) {
            this.FigureType = FiguresEnum.CurveLine;
        }
    }
    private void PenSizeClick(object sender, EventArgs e) {
        _ = new UiPenSize(this, this.PenColor);

        //if (penSizeWindow.ShowDialog() == DialogResult.OK) {
        //    if (this.MdiParent is UiCanvasWindow parent && parent.MdiParent is UiMainWindow grandParent) {
        //    }
        //}


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

        var result = this.FontDialog.ShowDialog();
        if (result == DialogResult.OK) {
            this.TextFont = this.FontDialog.Font;
        }
    }
    private void TextBoxButtonClick(object sender, EventArgs e) {

        if (this.MdiParent is UiMainWindow parent && parent.ActiveMdiChild is UiCanvasWindow canvasWindow) {
            if (canvasWindow.SelectedFigures[0] is TextBoxWrapper textBoxWrapper) {

                var textBox = new TextBox() {
                    Parent = canvasWindow,
                    Font = textBoxWrapper.TextFont,
                    Multiline = true,
                    ForeColor = textBoxWrapper.PenColor,
                    Location = new Point(textBoxWrapper.TopPoint.X, textBoxWrapper.TopPoint.Y),
                    Width = textBoxWrapper.BotPoint.X - textBoxWrapper.TopPoint.X,
                    Height = textBoxWrapper.BotPoint.Y - textBoxWrapper.TopPoint.Y,
                    Text = textBoxWrapper.Text,
                };


                textBox.LostFocus += (s, eArgs) => {

                    textBoxWrapper.Text = textBox.Text;


                    textBox.Dispose();
                };


                canvasWindow.Controls.Add(textBox);
                textBox.Focus();
            }
        }
    }
    private void CheckFigureButton(FiguresEnum? figureType) {

        if (figureType is null) {
            foreach (var buttons in this.FigureButton.Values) {

                buttons.Item1.Checked = false;
            }
        } else {

            foreach (var pair in this.FigureButton) {
                var figureEnum = pair.Key;
                var buttonPair = pair.Value;

                if (figureEnum == figureType) {

                    buttonPair.Item1.Checked = true;
                } else {

                    buttonPair.Item1.Checked = false;
                }
            }
        }
    }
    private void OkButtonClick(object sender, EventArgs e) {

        //var wrapper = (IDrawable?)Activator.CreateInstance(WrapperTypes[this.FigureType]);

        //if (wrapper is not null) {
        //    wrapper.PenSize = this.PenSize;
        //    wrapper.PenColor = this.PenColor;
        //    wrapper.BrushColor = this.BrushColor;
        //    wrapper.TopPoint = this.TopPoint;
        //    wrapper.BotPoint = this.BotPoint;
        //    wrapper.IsFilling = this.IsFilling;
        //    wrapper.FigureType = this.FigureType;

        //    if (wrapper is StraightLineWrapper straightLineWrapper) {
        //        straightLineWrapper.StartPoint = new Point(this.TopPoint.X, this.TopPoint.Y);
        //        straightLineWrapper.EndPoint = new Point(this.BotPoint.X, this.BotPoint.Y);
        //    }

        //    if (wrapper is CurveLineWrapper curveLineWrapper) {
        //        this.Points.Add(this.BotPoint);
        //        curveLineWrapper.Points = new List<Point>(this.Points);
        //        this.Points.Clear();
        //    }
        this.Close();
        //}
    }

    private void SaveButtonClick(object sender, EventArgs e) {

    }

    private void MoveButtonClick(object sender, EventArgs e) {

        if (this.MdiParent is UiMainWindow parent) {
            UiCanvasWindow? canvasWindow = null;
            EditState editState;
            foreach (var child in this.MdiParent.MdiChildren) {
                if (child is UiCanvasWindow) {
                    canvasWindow = (UiCanvasWindow)child;
                }
            }
            if (canvasWindow is not null && canvasWindow.State is EditState state) {
                editState = state;
               
                    if (editState.SelectedFigures.Count > 0) {
                   if (int.TryParse(this.TextX.Text, out int newX) && int.TryParse(this.TextY.Text, out int newY)) {
                        
                        foreach (var figure in editState.SelectedFigures) {

                            int dx = newX - figure.TopPoint.X;
                            int dy = newY - figure.TopPoint.Y;


                            if (figure.CanMove(dx, dy, editState.CanvasSize)) {
                                figure.Move(dx, dy);
                                editState.Up
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
