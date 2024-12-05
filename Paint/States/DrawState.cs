using Paint.Figures;
using Paint.UI;

namespace Paint.States;

public class DrawState : IState, IDrawing {
    public bool IsDrawing { get; set; } = false;

    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
    public List<Point> Points { get; set; } = [];

    public Size CanvasSize { get; set; }

    public int PenSize { get; set; }
    public Color PenColor { get; set; }
    public Color BrushColor { get; set; }
    public bool IsFilling { get; set; }

    public string Text { get; set; } = "";
    public Font TextFont { get; set; } = new Font("Times New Roman", 12.0f);

    public FiguresEnum FigureType { get; set; } = FiguresEnum.Rectangle;
    public Tuple<IFigure?, IFigure?> DashFigures { get; set; } = new(null, null);
    public List<IFigure> Figures { get; set; } = [];

    public UiCanvasWindow? ParentReference { get; set; }
    public BufferedGraphics? GraphicsBuffer { get; set; }

    public void MouseDownHandler(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && !this.IsDrawing) {
            this.Points.Clear();

            this.StartPoint = new Point(e.X, e.Y);
            this.EndPoint = new Point(e.X + 1, e.Y + 1);

            this.Points.Add(this.StartPoint);
            this.Points.Add(this.EndPoint);

            this.IsDrawing = true;
        }
    }

    public void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left && this.IsDrawing) {
            if (this.FigureType == FiguresEnum.Rectangle) {
                this.EndPoint = new Point(e.X, e.Y);

                var wrapper = new RectangleWrapper() {
                    StartPoint = this.StartPoint,
                    EndPoint = this.EndPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    this.DashFigures = new(null, wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.Ellipse) {
                this.EndPoint = new Point(e.X, e.Y);

                var wrapper = new EllipseWrapper() {
                    StartPoint = this.StartPoint,
                    EndPoint = this.EndPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    this.DashFigures = new(this.DashFigures.Item2, wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.Line) {
                this.EndPoint = new Point(e.X, e.Y);

                var wrapper = new StraightLineWrapper() {
                    StartPoint = this.StartPoint,
                    EndPoint = this.EndPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    this.DashFigures = new(this.DashFigures.Item2, wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.CurveLine) {
                this.EndPoint = new Point(e.X, e.Y);

                this.Points.Add(this.EndPoint);

                var wrapper = new CurveLineWrapper() {
                    StartPoint = this.StartPoint,
                    EndPoint = this.EndPoint,
                    Points = this.Points,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    wrapper.Points.Add(this.EndPoint);
                    this.DashFigures = new(this.DashFigures.Item2, wrapper);
                }
            }

            if (this.FigureType == FiguresEnum.TextBox) {
                this.EndPoint = new Point(e.X, e.Y);

                var wrapper = new TextBoxWrapper() {
                    StartPoint = this.StartPoint,
                    EndPoint = this.EndPoint,
                    PenSize = this.PenSize,
                    PenColor = this.PenColor,
                    BrushColor = this.BrushColor,
                    IsFilling = this.IsFilling
                };

                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    this.DashFigures = new(this.DashFigures.Item2, wrapper);
                }
            }
        }
    }

    public void MouseUpHandler(object sender, MouseEventArgs e) {
        if (this.FigureType == FiguresEnum.Rectangle) {
            this.EndPoint = new Point(e.X, e.Y);

            var wrapper = new RectangleWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.Figures.Add(wrapper);
            }
        }

        if (this.FigureType == FiguresEnum.Ellipse) {
            this.EndPoint = new Point(e.X, e.Y);

            var wrapper = new EllipseWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.Figures.Add(wrapper);
            }
        }

        if (this.FigureType == FiguresEnum.Line) {
            this.EndPoint = new Point(e.X, e.Y);

            var wrapper = new StraightLineWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.Figures.Add(wrapper);
            }
        }

        if (this.FigureType == FiguresEnum.CurveLine) {
            this.EndPoint = new Point(e.X, e.Y);

            var wrapper = new CurveLineWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                Points = this.Points,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                wrapper.Points.Add(this.EndPoint);
                this.Figures.Add(wrapper);
            }

            this.Points.Clear();
        }

        if (this.FigureType == FiguresEnum.TextBox) {
            this.EndPoint = new Point(e.X, e.Y);

            var wrapperWrapper = new TextBoxWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling,
                TextFont = this.TextFont
            };

            var wrapper = new UiTextBoxPlaceholder() {
                Parent = this.ParentReference,
                Font = this.TextFont,
                Multiline = true,
                ForeColor = this.PenColor,
                Location = this.StartPoint,
                Width = this.EndPoint.X - this.StartPoint.X,
                Height = this.EndPoint.Y - this.StartPoint.Y,
                Wrapper = wrapperWrapper,
                GraphicsBuffer = this.GraphicsBuffer
            };

            wrapper.Show();
        }

        this.IsDrawing = false;
    }
}
