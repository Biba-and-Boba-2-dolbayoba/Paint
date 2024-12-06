using Paint.Figures;
using Paint.Serialization;
using Paint.States;
using System.ComponentModel;

namespace Paint;

[Serializable()]
internal partial class UiCanvasWindow : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string? CanvasName { get; set; } = null;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IState State { get; set; } = new SelectState();

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public List<IFigure> Figures { get; set; } = [];

    private Tuple<IFigure?, IFigure?> DashFigures { get; set; } = new(null, null);
    private List<IFigure> SelectedFigures { get; set; } = [];
    private BufferedGraphics? GraphicsBuffer { get; set; }

    public UiCanvasWindow() {
        this.InitializeComponent();
        this.SetDoubleBuffering(true);

        var background = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
        var backgroundColor = new SolidBrush(Color.White);

        if (this.GraphicsBuffer is not null) {
            Graphics graphics = this.GraphicsBuffer.Graphics;
            graphics.FillRectangle(backgroundColor, background);
        }
    }

    private void UpdateGraphicsBuffer(Rectangle bufferArea) {
        BufferedGraphicsContext bufferedContext = BufferedGraphicsManager.Current;
        this.GraphicsBuffer = bufferedContext.Allocate(this.CreateGraphics(), bufferArea);

        if (this.State is DrawState state) {
            state.GraphicsBuffer = this.GraphicsBuffer;
        }
    }

    private void SetDoubleBuffering(bool isEnable) {
        this.SetStyle(
            ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, isEnable
        );

        this.UpdateStyles();
    }

    private void DeleteSelectedFigures() {
        if (this.SelectedFigures.Count > 0) {
            foreach (IFigure figure in this.SelectedFigures) {
                _ = this.Figures.Remove(figure);
            }

            this.SelectedFigures.Clear();
        }
    }

    private void DrawFigures(BufferedGraphics graphicsBuffer) {
        Graphics graphics = graphicsBuffer.Graphics;

        if (this.State is DrawState) {
            this.DashFigures.Item1?.Hide(graphics);
            this.DashFigures.Item2?.DrawDash(graphics);

            foreach (IFigure figure in this.Figures) {
                figure.Draw(graphics);
            }
        }

        if (this.State is SelectState) {
            if (this.SelectedFigures.Count > 0) {
                foreach (IFigure figure in this.Figures) {
                    if (this.SelectedFigures.Contains(figure)) {
                        figure.DrawSelection(graphics);
                    } else {
                        figure.Draw(graphics);
                    }
                }
            }
        }

        if (this.State is EditState) {

        }

        graphicsBuffer.Render();
    }

    private void Render() {
        var background = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
        var backgroundColor = new SolidBrush(Color.White);
        this.UpdateGraphicsBuffer(background);

        if (this.GraphicsBuffer is not null) {
            Graphics graphics = this.GraphicsBuffer.Graphics;
            graphics.FillRectangle(backgroundColor, background);
            this.DrawFigures(this.GraphicsBuffer);
        }
    }

    private void OnMouseDown(object sender, MouseEventArgs e) {
        if (this.State is SelectState selection) {
            selection.MouseDownHandler(sender, e);

            this.Figures = selection.Figures;
            this.SelectedFigures = selection.SelectedFigures;
        }

        if (this.State is DrawState drawing) {
            drawing.MouseDownHandler(sender, e);

            this.Figures = drawing.Figures;
            this.DashFigures = drawing.DashFigures;
        }

        if (this.State is EditState) {
            return;
        }

        this.Render();
    }

    private void OnMouseMove(object sender, MouseEventArgs e) {
        if (this.MdiParent is UiMainWindow parent) {
            parent.UpdatePointerInfo(new Point(e.X, e.Y));
        }

        if (this.State is SelectState selection) {
            selection.MouseMoveHandler(sender, e);

            this.SelectedFigures = selection.SelectedFigures;
            this.Figures = selection.Figures;
        }

        if (this.State is DrawState drawing) {
            drawing.MouseMoveHandler(sender, e);

            this.Figures = drawing.Figures;
            this.DashFigures = drawing.DashFigures;
        }

        if (this.State is EditState) {
            return;
        }

        this.Render();
    }

    private void OnMouseUp(object sender, MouseEventArgs e) {
        if (this.State is SelectState selection) {
            selection.MouseUpHandler(sender, e);

            this.Figures = selection.Figures;
            this.SelectedFigures = selection.SelectedFigures;
        }

        if (this.State is DrawState drawing) {
            drawing.MouseUpHandler(sender, e);

            this.Figures = drawing.Figures;
            this.DashFigures = drawing.DashFigures;
        }

        if (this.State is EditState) {
            return;
        }

        this.Render();
    }

    private void OnLoad(object sender, EventArgs e) {
        this.OnResize(sender, e);
    }

    private void OnClose(object sender, FormClosingEventArgs e) {
        if (this.Figures.Count > 0) {
            DialogResult response = MessageBox.Show("Вы хотите сохранить изменения в документе?", "Attention", MessageBoxButtons.YesNoCancel);

            if (response == DialogResult.Yes) {
                HashableCanvas.SaveFile(this.Size, this.Name, this.Figures);
            } else if (response == DialogResult.Cancel) {
                e.Cancel = true;
            }
        }
    }

    private void OnResize(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent) {
            parent.UpdateCanvasInfo(this.Size);
        }

        this.Render();
    }

    private void OnKeyDown(object sender, KeyEventArgs e) {
        if (this.State is SelectState && e.KeyData == Keys.Delete) {
            this.DeleteSelectedFigures();
        }
    }
}
