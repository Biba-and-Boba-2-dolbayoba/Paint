using Paint.Figures;
using System.ComponentModel;

namespace Paint;

[Serializable()]
public partial class UxCanvasWindow : Form {
    private int x1;
    private int y1;
    private int x2;
    private int y2;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string? CanvasName { get; set; } = null;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int ScrollX { get; private set; } = new();

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int ScrollY { get; private set; } = new();

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsSelectionMode { get; set; } = false;

    private bool IsDrawing { get; set; } = false;

    private bool IsCanvasEmpty { get; set; } = true;

    private List<Point> Points { get; set; } = [];

    private List<Figure> Figures { get; set; } = [];

    private Size CanvasSize { get; set; } = new(UxMainWindow.CanvasWidth, UxMainWindow.CanvasHeight);

    private Figure? SelectedFigure { get; set; } = null;

    private Point DragStartPoint { get; set; } = new();

    private bool IsDragging { get; set; } = false;

    public UxCanvasWindow() {
        this.InitializeComponent();
    }

    private void MouseDownHandler(object sender, MouseEventArgs e) {
        this.Points = [];
        ScrollX = Math.Abs(this.AutoScrollPosition.X);
        ScrollY = Math.Abs(this.AutoScrollPosition.Y);
        if (e.Button == MouseButtons.Left && !this.IsDrawing) {
            this.x1 = e.X;
            this.y1 = e.Y;
            this.Points.Add(new Point(this.x1 + ScrollX, this.y1 + ScrollY));
            this.x2 = this.x1 + 1;
            this.y2 = this.y1 + 1;
            this.Points.Add(new Point(this.x2 + ScrollX, this.y2 + ScrollY));
            this.IsDrawing = true;
        }

        if (this.IsSelectionMode) {
            if (e.Button == MouseButtons.Left) {
                foreach (Figure figure in this.Figures) {
                    if (figure.ContainsPoint(new Point(e.X + ScrollX, e.Y + ScrollY))) {
                        this.SelectedFigure = figure;
                        this.DragStartPoint = new Point(e.X, e.Y);
                        this.IsDragging = true;
                        this.Invalidate();
                        return;
                    }
                }

                this.SelectedFigure = null;
                this.IsDragging = false;
                this.Invalidate();
            }
        }
    }

    private void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (this.IsDrawing) {
            this.DoubleBuffered = true;
            var bufferZone = new Rectangle(0, 0, this.CanvasSize.Width, this.CanvasSize.Height);

            BufferedGraphicsContext bufferPlace = new();
            BufferedGraphics buffer = bufferPlace.Allocate(this.CreateGraphics(), bufferZone);

            var bg_color = new SolidBrush(Color.White);
            buffer.Graphics.FillRectangle(bg_color, bufferZone);
            foreach (Figure f in this.Figures) {
                f.Draw(buffer.Graphics);
            }

            var no_curve = new Point[1];
            var no_font = new Font("", 1);
            string no_text = "";
            if (UxMainWindow.FigureType == 1) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new Rect(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    r.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }

                r = new Rect(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    r.Hide(buffer.Graphics);
                }
            }

            if (UxMainWindow.FigureType == 2) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new Ellipse(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    r.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }

                r = new Ellipse(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    r.Hide(buffer.Graphics);
                }
            }

            if (UxMainWindow.FigureType == 3) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new Line(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    r.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }

                r = new Line(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    r.Hide(buffer.Graphics);
                }
            }

            if (UxMainWindow.FigureType == 4) {

                var points1 = new Point[this.Points.Count];
                for (int i = 0 ; i < this.Points.Count ; i++) {
                    points1[i] = this.Points[i];
                }

                var CL1 = new CurveLine(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, points1, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    CL1.Hide(buffer.Graphics);
                }

                this.x2 = e.X;
                this.y2 = e.Y;
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    this.Points.Add(new Point(this.x2 + ScrollX, this.y2 + ScrollY));
                }

                var points2 = new Point[this.Points.Count];
                for (int i = 0 ; i < this.Points.Count ; i++) {
                    points2[i] = this.Points[i];
                }

                var CL2 = new CurveLine(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, points2, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    CL2.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }
            }

            if (UxMainWindow.FigureType == 5) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new TxtBox(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    r.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }

                r = new TxtBox(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.CanvasSize.Width + ScrollX) && (this.y2 + ScrollY) < (this.CanvasSize.Height + ScrollY)) {
                    r.Hide(buffer.Graphics);
                }
            }

            if (this.IsDragging && this.SelectedFigure != null) {
                int dx = e.X - this.DragStartPoint.X;
                int dy = e.Y - this.DragStartPoint.Y;

                if (this.SelectedFigure.CanMove(dx, dy, this.CanvasSize)) {
                    this.SelectedFigure.Move(dx, dy);
                    this.DragStartPoint = new Point(e.X, e.Y);
                    this.Invalidate();
                }
            }

            this.DoubleBuffered = false;
            buffer.Dispose();
        }
    }

    private void MouseUpHandler(object sender, MouseEventArgs e) {
        var no_font = new Font("", 1);
        var no_curve = new Point[1];
        string no_text = "";
        if (e.Button == MouseButtons.Left) {
            if (UxMainWindow.FigureType == 1) {
                Graphics g = this.CreateGraphics();
                var r = new Rect(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) <= this.CanvasSize.Width && (this.y2 + ScrollY) <= this.CanvasSize.Height) {
                    r.Draw(g);
                    this.Figures.Add(r);
                    this.Invalidate();
                }

                this.IsDrawing = false;
                this.IsCanvasEmpty = false;
            }

            if (UxMainWindow.FigureType == 2) {
                Graphics g = this.CreateGraphics();
                var r = new Ellipse(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) <= this.CanvasSize.Width && (this.y2 + ScrollY) <= this.CanvasSize.Height) {
                    r.Draw(g);
                    this.Figures.Add(r);
                    this.Invalidate();
                }

                this.IsDrawing = false;
                this.IsCanvasEmpty = false;
            }

            if (UxMainWindow.FigureType == 3) {
                Graphics g = this.CreateGraphics();
                var r = new Line(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) <= this.CanvasSize.Width && (this.y2 + ScrollY) <= this.CanvasSize.Height) {
                    r.Draw(g);
                    this.Figures.Add(r);
                    this.Invalidate();
                }

                this.IsDrawing = false;
                this.IsCanvasEmpty = false;
            }

            if (UxMainWindow.FigureType == 4) {
                Graphics g = this.CreateGraphics();
                var points2 = new Point[this.Points.Count];
                for (int i = 0 ; i < this.Points.Count ; i++) {
                    points2[i] = this.Points[i];
                }

                var r = new CurveLine(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, points2, no_font, no_text);
                if ((this.x2 + ScrollX) <= this.CanvasSize.Width && (this.y2 + ScrollY) <= this.CanvasSize.Height) {
                    r.Draw(g);
                    this.Figures.Add(r);
                    this.Invalidate();
                }

                this.IsDrawing = false;
                this.IsCanvasEmpty = false;
                this.Points.Clear();
            }

            if (UxMainWindow.FigureType == 5) {
                Font font = UxMainWindow.TextFont;
                if ((this.x2 + ScrollX) <= this.CanvasSize.Width && (this.y2 + ScrollY) <= this.CanvasSize.Height) {
                    var MyTextBox = new TextBox();
                    MyTextBox.KeyDown += this.MyTextBox_KeyDown;
                    MyTextBox.Parent = this;
                    MyTextBox.Font = font;
                    MyTextBox.Multiline = true;
                    MyTextBox.ForeColor = UxMainWindow.LineColor;
                    MyTextBox.Location = new Point(this.x1 + ScrollX, this.y1 + ScrollY);
                    MyTextBox.Width = this.x2 - this.x1;
                    MyTextBox.Height = this.y2 - this.y1;
                }

                this.IsCanvasEmpty = false;
                this.IsDrawing = false;
            }

            if (e.Button == MouseButtons.Left && this.IsDragging) {
                this.IsDragging = false;
                this.IsDrawing = false;
            }
        }
    }

    private void PaintHandler(object sender, PaintEventArgs e) {
        this.DoubleBuffered = true;
        var buffer_ground = new Rectangle(0, 0, this.CanvasSize.Width, this.CanvasSize.Height);

        BufferedGraphicsContext bufferPlace = new();
        BufferedGraphics buffer = bufferPlace.Allocate(this.CreateGraphics(), buffer_ground);

        ScrollX = Math.Abs(this.AutoScrollPosition.X);
        ScrollY = Math.Abs(this.AutoScrollPosition.Y);
        if (!this.IsDrawing) {
            var background = new Rectangle(0, 0, this.CanvasSize.Width, this.CanvasSize.Height);
            var bg_color = new SolidBrush(Color.White);
            buffer.Graphics.FillRectangle(bg_color, background);
            foreach (Figure f in this.Figures) {
                f.Draw(buffer.Graphics);
            }
        }

        this.DoubleBuffered = false;
        buffer.Render(this.CreateGraphics());
        buffer.Dispose();

        if (this.SelectedFigure != null && this.IsSelectionMode) {
            Graphics graphics = e.Graphics;
            var pen = new Pen(Color.Blue, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            this.SelectedFigure.DrawSelection(graphics, pen);
        }
    }

    private void CloseHandler(object sender, FormClosingEventArgs e) {

        if (!this.IsCanvasEmpty) {
            DialogResult res = MessageBox.Show("Вы хотите сохранить изменения в документе?", "Attention", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes) {
                UxMainWindow.SaveFile(this);
            } else if (res == DialogResult.Cancel) {
                e.Cancel = true;
            }
        }
    }

    private void LoadHandler(object sender, EventArgs e) {
        ScrollX = this.AutoScrollPosition.X;
        ScrollY = this.AutoScrollPosition.Y;

        var buffer_ground = new Rectangle(0, 0, this.CanvasSize.Width, this.CanvasSize.Height);
        this.Size = new Size(this.CanvasSize.Width, this.CanvasSize.Height);

        BufferedGraphicsContext bufferPlace = BufferedGraphicsManager.Current;
        bufferPlace.MaximumBuffer = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height);
        BufferedGraphics buffer = bufferPlace.Allocate(this.CreateGraphics(), buffer_ground);

        var background = new Rectangle(0, 0, this.CanvasSize.Width, this.CanvasSize.Height);
        var bg_color = new SolidBrush(Color.White);
        buffer.Graphics.FillRectangle(bg_color, background);
        DoubleBuffered = false;
        buffer.Render(this.CreateGraphics());
        buffer.Dispose();
    }

    private void MyTextBox_KeyDown(object? sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Enter && sender is not null) {
            var MyTextBox = (TextBox)sender;
            MyTextBox.ReadOnly = true;
            MyTextBox.Visible = false;
            var no_curve = new Point[1];
            Graphics g = this.CreateGraphics();
            Font font = UxMainWindow.TextFont;
            var r = new TxtBox(MyTextBox.Location, MyTextBox.Location + MyTextBox.Size, UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, no_curve, font, MyTextBox.Text);
            r.Draw(g);
            this.Figures.Add(r);
            this.Invalidate();
            MyTextBox.Dispose();
            this.IsDrawing = false;
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
