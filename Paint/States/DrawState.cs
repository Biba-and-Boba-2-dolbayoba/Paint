using Paint.Figures;
using Paint.Interfaces;
using Paint.UI;

namespace Paint.States;

internal class DrawState : IState, IDrawing {
    public bool IsDrawing { get; set; } = false;

    public Point TopPoint { get; set; }
    public Point BotPoint { get; set; }
    public List<Point> Points { get; set; } = [];

    public Size CanvasSize { get; set; }

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public string Text { get; set; } = "";
    public Font TextFont { get; set; } = new Font("Times New Roman", 12.0f);

    public FiguresEnum FigureType { get; set; } = FiguresEnum.Rectangle;
    public Tuple<IDrawable?, IDrawable?> DashFigures { get; set; } = new(null, null);
    public List<IDrawable> Figures { get; set; } = [];

    public UiCanvasWindow? ParentReference { get; set; }
    public BufferedGraphics? GraphicsBuffer { get; set; }

    public void MouseDownHandler(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && !this.IsDrawing) {
            this.Points.Clear();

            this.TopPoint = new Point(e.X, e.Y);
            this.BotPoint = new Point(e.X, e.Y);

            this.Points.Add(this.TopPoint);
            this.Points.Add(this.BotPoint);

            this.IsDrawing = true;
        }
    }

    public void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && this.IsDrawing) {
            if (this.FigureType == FiguresEnum.Rectangle) {
                this.BotPoint = new Point(e.X, e.Y);

                var wrapper = new RectangleWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.DashFigures = new(this.DashFigures.Item2, wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.Ellipse) {
                this.BotPoint = new Point(e.X, e.Y);

                var wrapper = new EllipseWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.DashFigures = new(this.DashFigures.Item2, wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.StraightLine) {
                this.BotPoint = new Point(e.X, e.Y);

                var wrapper = new StraightLineWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.DashFigures = new(this.DashFigures.Item2, wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.CurveLine) {
                this.BotPoint = new Point(e.X, e.Y);

                this.Points.Add(this.BotPoint);

                var wrapper = new CurveLineWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    Points = this.Points,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.DashFigures = new(this.DashFigures.Item2, wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.TextBox) {
                this.BotPoint = new Point(e.X, e.Y);

                var wrapper = new TextBoxWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.DashFigures = new(this.DashFigures.Item2, wrapper);
                }
            }
        }
    }

    public void MouseUpHandler(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && this.IsDrawing) {
            if (this.FigureType == FiguresEnum.Rectangle) {
                this.BotPoint = new Point(e.X, e.Y);

                var wrapper = new RectangleWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.Figures.Add(wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.Ellipse) {
                this.BotPoint = new Point(e.X, e.Y);

                var wrapper = new EllipseWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.Figures.Add(wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.StraightLine) {
                this.BotPoint = new Point(e.X, e.Y);

                var wrapper = new StraightLineWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.Figures.Add(wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.CurveLine) {
                this.BotPoint = new Point(e.X, e.Y);
                this.Points.Add(this.BotPoint);

                var wrapper = new CurveLineWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling,
                    Points = this.Points
                };

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.Figures.Add(wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.TextBox) {
                this.BotPoint = new Point(e.X, e.Y);

                var wrapper = new TextBoxWrapper() {
                    TopPoint = this.TopPoint,
                    BotPoint = this.BotPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling,
                    TextFont = this.TextFont
                };

                var placeholder = new UiTextBoxPlaceholder() {
                    Parent = this.ParentReference,
                    Size = new(this.BotPoint.X - this.TopPoint.X, this.BotPoint.Y - this.TopPoint.Y),
                    Font = this.TextFont,
                    Multiline = true,
                    ForeColor = this.PenColor,
                    Location = this.TopPoint,
                    Width = this.BotPoint.X - this.TopPoint.X,
                    Height = this.BotPoint.Y - this.TopPoint.Y,
                    Wrapper = wrapper,
                    GraphicsBuffer = this.GraphicsBuffer
                };

                placeholder.Show();

                if (this.BotPoint.X < this.CanvasSize.Width && this.BotPoint.Y < this.CanvasSize.Height) {
                    this.Figures.Add(wrapper);
                }
            }

            this.DashFigures = new(null, null);
            this.IsDrawing = false;
        }
    }
}
