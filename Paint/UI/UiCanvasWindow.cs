using Paint.Figures;
using Paint.States;
using System.ComponentModel;

namespace Paint;

[Serializable()]
public partial class UiCanvasWindow : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string? CanvasName { get; set; } = null;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IState State { get; set; } = new SelectState();

    private List<IFigure> Figures { get; set; } = [];
    private IFigure? SelectedFigure { get; set; } = null;
    private List<IFigure> SelectedFigures { get; set; } = [];
    private BufferedGraphics? GraphicsBuffer { get; set; }

    public UiCanvasWindow() {
        this.InitializeComponent();

        var background = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
        this.SetDoubleBuffering(true);
        this.UpdateGraphicsBuffer(background);
    }

    private void UpdateGraphicsBuffer(Rectangle bufferArea) {
        BufferedGraphicsContext bufferedContext = BufferedGraphicsManager.Current;
        this.GraphicsBuffer = bufferedContext.Allocate(this.CreateGraphics(), bufferArea);
    }

    private void SetDoubleBuffering(bool isEnable) {
        this.SetStyle(
            ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, isEnable
        );

        this.UpdateStyles();
    }

    private void MouseDownHandler(object sender, MouseEventArgs e) {
        if (this.State is SelectState selection) {
            selection.MouseDownHandler(sender, e);

            this.SelectedFigure = selection.SelectedFigure;
            this.SelectedFigures = selection.SelectedFigures;
        }

        if (this.State is DrawState drawing) {
            drawing.MouseDownHandler(sender, e);
        }

        if (this.State is EditState) {
            return;
        }
    }

    private void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (this.State is SelectState selection) {
            selection.MouseMoveHandler(sender, e);

            this.SelectedFigure = selection.SelectedFigure;
            this.SelectedFigures = selection.SelectedFigures;
            this.Figures = selection.Figures;
        }

        if (this.State is DrawState drawing) {
            drawing.MouseMoveHandler(sender, e);

            this.Figures = drawing.Figures;
        }

        if (this.State is EditState) {
            return;
        }
    }

    private void MouseUpHandler(object sender, MouseEventArgs e) {
        if (this.State is SelectState selection) {
            selection.MouseUpHandler(sender, e);

            this.SelectedFigure = selection.SelectedFigure;
            this.SelectedFigures = selection.SelectedFigures;
        }

        if (this.State is DrawState drawing) {
            drawing.MouseUpHandler(sender, e);

        }

        if (this.State is EditState) {
            return;
        }
    }

    private void LoadHandler(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent) {
            this.Size = new(parent.CanvasWidth, parent.CanvasHeight);
        }
    }

    private void CloseHandler(object sender, FormClosingEventArgs e) {
        if (this.Figures.Count > 0) {
            DialogResult response = MessageBox.Show("Вы хотите сохранить изменения в документе?", "Attention", MessageBoxButtons.YesNoCancel);

            if (response == DialogResult.Yes) {
                UiMainWindow.SaveFile(this);
            } else if (response == DialogResult.Cancel) {
                e.Cancel = true;
            }
        }
    }

    private void PaintHandler(object sender, PaintEventArgs e) {
        var background = new Rectangle(0, 0, this.Size.Width, this.Size.Height);

        if (this.GraphicsBuffer is not null) {
            Graphics graphics = this.GraphicsBuffer.Graphics;

            if (this.State is DrawState) {
                var backgroundColor = new SolidBrush(Color.White);
                graphics.FillRectangle(backgroundColor, background);

                foreach (IFigure figure in this.Figures) {
                    figure.Draw(graphics);
                }
            }

            if (this.State is SelectState) {
                var backgroundColor = new SolidBrush(Color.White);
                graphics.FillRectangle(backgroundColor, background);

                if (this.SelectedFigure is not null) {
                    foreach (IFigure figure in this.Figures) {
                        if (figure == this.SelectedFigure || this.SelectedFigures.Contains(figure)) {
                            figure.DrawSelection(graphics);
                        } else {
                            figure.Draw(graphics);
                        }
                    }
                }
            }

            if (this.State is EditState) {

            }

            this.GraphicsBuffer.Render(e.Graphics);
        } else {
            this.UpdateGraphicsBuffer(background);
        }
    }

    private void ResizeHandler(object sender, EventArgs e) {
        var background = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
        var backgroundColor = new SolidBrush(Color.White);
        this.UpdateGraphicsBuffer(background);

        if (this.MdiParent is UiMainWindow parent) {
            parent.UpdateCanvasInfo(this.Size);
        }

        if (this.GraphicsBuffer is not null) {
            Graphics graphics = this.GraphicsBuffer.Graphics;
            graphics.FillRectangle(backgroundColor, background);
        }
    }

    private void DeleteSelectedFigure() {
        if (this.SelectedFigure != null) {
            _ = this.Figures.Remove(this.SelectedFigure); // Удаляем выбранную фигуру
            this.SelectedFigure = null;        // Сбрасываем выделение
            this.Invalidate();                 // Перерисовка
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
        if (keyData == Keys.Delete) {
            this.DeleteSelectedFigure();
            return true;
        }

        return base.ProcessCmdKey(ref msg, keyData);
    }
}
