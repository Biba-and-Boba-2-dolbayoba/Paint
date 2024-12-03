using Paint.Figures;
using System.ComponentModel;

namespace Paint;

[Serializable()]
public partial class UxCanvasWindow : Form {
    private int x1;
    private int y1;
    private int x2;
    private int y2;
    public string? fileName = null;
    public int flag;
    public bool flag3 = false;
    private bool IsCanvasEmpty { get; set; } = true;
    private List<Figure> Figures { get; set; } = [];
    public List<Point> points = [];
    public Size Sz = new(UxMainWindow.CanvasWidth, UxMainWindow.CanvasHeight);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int ScrollX { get; private set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int ScrollY { get; private set; }

    private Figure? selectedFigure = null;
    private Point dragStartPoint;
    private bool isDragging = false;

    private bool IsSelectionMode { get; set; }

    public string text1 = "";

    public UxCanvasWindow() {
        this.InitializeComponent();
    }

    public void MouseDownHandler(object sender, MouseEventArgs e) {
        this.points = [];
        ScrollX = Math.Abs(this.AutoScrollPosition.X);
        ScrollY = Math.Abs(this.AutoScrollPosition.Y);
        if (e.Button == MouseButtons.Left && this.flag != 5) {
            this.x1 = e.X;
            this.y1 = e.Y;
            this.points.Add(new Point(this.x1 + ScrollX, this.y1 + ScrollY));
            this.x2 = this.x1 + 1;
            this.y2 = this.y1 + 1;
            this.points.Add(new Point(this.x2 + ScrollX, this.y2 + ScrollY));
            this.flag = 1;

        }

        if (this.IsSelectionMode) {
            if (e.Button == MouseButtons.Left) {
                foreach (Figure figure in this.Figures) {
                    // Проверяем, находится ли точка в границах фигуры
                    if (figure.ContainsPoint(new Point(e.X + ScrollX, e.Y + ScrollY))) {
                        this.selectedFigure = figure; // Устанавливаем выбранную фигуру
                        this.dragStartPoint = new Point(e.X, e.Y);
                        this.isDragging = true;
                        this.Invalidate(); // Перерисовка для отображения выделения
                        return;
                    }
                }

                // Если щелчок был вне фигуры, снимаем выделение
                this.selectedFigure = null;
                this.isDragging = false;
                this.Invalidate();
            }
        }
    }

    private void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (this.flag == 1) {
            this.DoubleBuffered = true;
            var bufferZone = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);

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
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    r.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }

                r = new Rect(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    r.Hide(buffer.Graphics);
                }
            }

            if (UxMainWindow.FigureType == 2) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new Ellipse(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    r.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }

                r = new Ellipse(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    r.Hide(buffer.Graphics);
                }
            }

            if (UxMainWindow.FigureType == 3) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new Line(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    r.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }

                r = new Line(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    r.Hide(buffer.Graphics);
                }
            }

            if (UxMainWindow.FigureType == 4) {

                var points1 = new Point[this.points.Count];
                for (int i = 0 ; i < this.points.Count ; i++) {
                    points1[i] = this.points[i];
                }

                var CL1 = new CurveLine(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, points1, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    CL1.Hide(buffer.Graphics);
                }

                this.x2 = e.X;
                this.y2 = e.Y;
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    this.points.Add(new Point(this.x2 + ScrollX, this.y2 + ScrollY));
                }

                var points2 = new Point[this.points.Count];
                for (int i = 0 ; i < this.points.Count ; i++) {
                    points2[i] = this.points[i];
                }

                var CL2 = new CurveLine(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, points2, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    CL2.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }
            }

            if (UxMainWindow.FigureType == 5) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new TxtBox(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    r.Dash(buffer.Graphics);
                    buffer.Render(this.CreateGraphics());
                }

                r = new TxtBox(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) < (this.Sz.Width + ScrollX) && (this.y2 + ScrollY) < (this.Sz.Height + ScrollY)) {
                    r.Hide(buffer.Graphics);
                }
            }

            if (this.isDragging && this.selectedFigure != null) {
                int dx = e.X - this.dragStartPoint.X; // Разница по X
                int dy = e.Y - this.dragStartPoint.Y; // Разница по Y

                // Проверяем, можно ли переместить фигуру без выхода за границы
                if (this.selectedFigure.CanMove(dx, dy, this.Sz)) {
                    this.selectedFigure.Move(dx, dy);
                    this.dragStartPoint = new Point(e.X, e.Y);

                    // Перерисовка
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
                if ((this.x2 + ScrollX) <= this.Sz.Width && (this.y2 + ScrollY) <= this.Sz.Height) {
                    r.Draw(g);
                    this.Figures.Add(r);
                    this.Invalidate();
                }

                this.flag = 0;
                this.IsCanvasEmpty = false;
            }

            if (UxMainWindow.FigureType == 2) {
                Graphics g = this.CreateGraphics();
                var r = new Ellipse(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) <= this.Sz.Width && (this.y2 + ScrollY) <= this.Sz.Height) {
                    r.Draw(g);
                    this.Figures.Add(r);
                    this.Invalidate();
                }

                this.flag = 0;
                this.IsCanvasEmpty = false;
            }

            if (UxMainWindow.FigureType == 3) {
                Graphics g = this.CreateGraphics();
                var r = new Line(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + ScrollX) <= this.Sz.Width && (this.y2 + ScrollY) <= this.Sz.Height) {
                    r.Draw(g);
                    this.Figures.Add(r);
                    this.Invalidate();
                }

                this.flag = 0;
                this.IsCanvasEmpty = false;
            }

            if (UxMainWindow.FigureType == 4) {
                Graphics g = this.CreateGraphics();
                var points2 = new Point[this.points.Count];
                for (int i = 0 ; i < this.points.Count ; i++) {
                    points2[i] = this.points[i];
                }

                var r = new CurveLine(new Point(this.x1 + ScrollX, this.y1 + ScrollY), new Point(this.x2 + ScrollX, this.y2 + ScrollY), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.BrushSize, UxMainWindow.IsFilling, points2, no_font, no_text);
                if ((this.x2 + ScrollX) <= this.Sz.Width && (this.y2 + ScrollY) <= this.Sz.Height) {
                    r.Draw(g);
                    this.Figures.Add(r);
                    this.Invalidate();
                }

                this.flag = 0;
                this.IsCanvasEmpty = false;
                this.points.Clear();
            }

            if (UxMainWindow.FigureType == 5) {
                Font font = UxMainWindow.TextFont;
                if ((this.x2 + ScrollX) <= this.Sz.Width && (this.y2 + ScrollY) <= this.Sz.Height) {
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
                this.flag = 0;
            }

            if (e.Button == MouseButtons.Left && this.isDragging) {
                this.isDragging = false;
                this.flag = 0;
            }
        }
    }

    private void PaintHandler(object sender, PaintEventArgs e) {
        this.DoubleBuffered = true;
        var buffer_ground = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);

        BufferedGraphicsContext bufferPlace = new();
        BufferedGraphics buffer = bufferPlace.Allocate(this.CreateGraphics(), buffer_ground);

        ScrollX = Math.Abs(this.AutoScrollPosition.X);
        ScrollY = Math.Abs(this.AutoScrollPosition.Y);
        if (this.flag == 0) {
            var background = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);
            var bg_color = new SolidBrush(Color.White);
            buffer.Graphics.FillRectangle(bg_color, background);
            foreach (Figure f in this.Figures) {
                f.Draw(buffer.Graphics);
            }
        }

        this.DoubleBuffered = false;
        buffer.Render(this.CreateGraphics());
        buffer.Dispose();

        if (this.selectedFigure != null && this.IsSelectionMode) {
            // Рисуем пунктирный контур вокруг выбранной фигуры
            Graphics graphics = e.Graphics;
            var pen = new Pen(Color.Blue, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            this.selectedFigure.DrawSelection(graphics, pen); // Метод для рисования выделения
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

        var buffer_ground = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);
        this.Size = new Size(this.Sz.Width, this.Sz.Height);

        BufferedGraphicsContext bufferPlace = BufferedGraphicsManager.Current;
        bufferPlace.MaximumBuffer = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height);
        BufferedGraphics buffer = bufferPlace.Allocate(this.CreateGraphics(), buffer_ground);

        var background = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);
        var bg_color = new SolidBrush(Color.White);
        buffer.Graphics.FillRectangle(bg_color, background);
        DoubleBuffered = false;
        buffer.Render(this.CreateGraphics());
        buffer.Dispose();
    }

    public void MyTextBox_KeyDown(object? sender, KeyEventArgs e) {
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
            this.flag = 0;
        }
    }

    private void DeleteSelectedFigure() {
        if (this.selectedFigure != null) {
            _ = this.Figures.Remove(this.selectedFigure); // Удаляем выбранную фигуру
            this.selectedFigure = null;        // Сбрасываем выделение
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
