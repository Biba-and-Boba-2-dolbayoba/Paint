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
    public List<IFigure> Figures { get; set; } = [];
    public List<IFigure> DashFigures { get; set; } = [];

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
        if (this.FigureType == FiguresEnum.Rectangle) {
            this.EndPoint = new Point(e.X, e.Y);

            var rectangle = new RectangleWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.DashFigures.Add(rectangle);
            }
        }

        if (this.FigureType == FiguresEnum.Ellipse) {
            this.EndPoint = new Point(e.X, e.Y);

            var ellipse = new EllipseWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.DashFigures.Add(ellipse);
            }
        }

        if (this.FigureType == FiguresEnum.Line) {
            this.EndPoint = new Point(e.X, e.Y);

            var straighLine = new StraightLineWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.DashFigures.Add(straighLine);
            }
        }

        if (this.FigureType == FiguresEnum.CurveLine) {
            this.EndPoint = new Point(e.X, e.Y);

            var curveLine = new CurveLineWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                Points = this.Points,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                curveLine.Points.Add(this.EndPoint);
                this.DashFigures.Add(curveLine);
            }
        }

        if (this.FigureType == FiguresEnum.TextBox) {
            this.EndPoint = new Point(e.X, e.Y);

            var textBox = new TextBoxWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.DashFigures.Add(textBox);
            }
        }
    }

    public void MouseUpHandler(object sender, MouseEventArgs e) {
        if (this.FigureType == FiguresEnum.Rectangle) {
            this.EndPoint = new Point(e.X, e.Y);

            var rectangle = new RectangleWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.Figures.Add(rectangle);
            }
        }

        if (this.FigureType == FiguresEnum.Ellipse) {
            this.EndPoint = new Point(e.X, e.Y);

            var ellipse = new EllipseWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.Figures.Add(ellipse);
            }
        }

        if (this.FigureType == FiguresEnum.Line) {
            this.EndPoint = new Point(e.X, e.Y);

            var straighLine = new StraightLineWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                this.Figures.Add(straighLine);
            }
        }

        if (this.FigureType == FiguresEnum.CurveLine) {
            this.EndPoint = new Point(e.X, e.Y);

            var curveLine = new CurveLineWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                Points = this.Points,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling
            };

            if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                curveLine.Points.Add(this.EndPoint);
                this.Figures.Add(curveLine);
            }

            this.Points.Clear();
        }

        if (this.FigureType == FiguresEnum.TextBox) {
            this.EndPoint = new Point(e.X, e.Y);

            var textBoxWrapper = new TextBoxWrapper() {
                StartPoint = this.StartPoint,
                EndPoint = this.EndPoint,
                PenSize = this.PenSize,
                PenColor = this.PenColor,
                BrushColor = this.BrushColor,
                IsFilling = this.IsFilling,
                TextFont = this.TextFont
            };

            var textBox = new UiTextBoxPlaceholder() {
                Parent = this.ParentReference,
                Font = this.TextFont,
                Multiline = true,
                ForeColor = this.PenColor,
                Location = this.StartPoint,
                Width = this.EndPoint.X - this.StartPoint.X,
                Height = this.EndPoint.Y - this.StartPoint.Y,
                Wrapper = textBoxWrapper,
                GraphicsBuffer = this.GraphicsBuffer
            };

            textBox.Show();
        }

        this.IsDrawing = false;
    }
}
