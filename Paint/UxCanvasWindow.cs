using System.ComponentModel;

namespace Paint;

[Serializable()]
public partial class UxCanvasWindow : Form {
    private int x1;
    private int y1;
    private int x2;
    private int y2;
    public static int x_mouse;
    public static int y_mouse;
    public static string TextXY = "Координаты мыши - " + x_mouse + " " + y_mouse;
    public string? fileName = null;
    public int flag;
    public bool flag3 = false;
    public bool flagMod = true;
    public List<Figure> array = [];
    public List<Point> points = [];
    public Size Sz = new(UxMainWindow.CanvasWidth, UxMainWindow.CanvasHeight);
    public static int scr_x;
    public static int scr_y;
    public static int windowsizex;
    public static int windowsizey;
    private Figure? selectedFigure = null;
    private Point dragStartPoint;
    private bool isDragging = false;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool isSelectionMode { get; set; }

    private Font font = UxMainWindow.TextFont;
    public string text1 = "";

    public event Action<int, int> CursorMoved;
    public event Action<int, int> FormActivated;

    private BufferedGraphicsContext bufferPlace;
    private BufferedGraphics buffer;

    public UxCanvasWindow() {
        this.InitializeComponent();

        this.AutoScroll = true;
        this.AutoScrollMinSize = this.Sz;
        this.MouseMove += this.Form2_MouseMove;
        this.Activated += this.Form2_Activated;

    }

    public void Form2_MouseDown(object sender, MouseEventArgs e) {
        this.points = [];
        scr_x = Math.Abs(this.AutoScrollPosition.X);
        scr_y = Math.Abs(this.AutoScrollPosition.Y);
        if (e.Button == MouseButtons.Left && this.flag != 5) {
            this.x1 = e.X;
            this.y1 = e.Y;
            this.points.Add(new Point(this.x1 + scr_x, this.y1 + scr_y));
            this.x2 = this.x1 + 1;
            this.y2 = this.y1 + 1;
            this.points.Add(new Point(this.x2 + scr_x, this.y2 + scr_y));
            this.flag = 1;

        } else if (e.Button == MouseButtons.Left && this.flag == 5) {
            this.x1 = e.X;
            this.y1 = e.Y;
            this.points.Add(new Point(this.x1 + scr_x, this.y1 + scr_y));
            this.x2 = this.x1 + 1;
            this.y2 = this.y1 + 1;
            this.points.Add(new Point(this.x2 + scr_x, this.y2 + scr_y));
            this.flag = 1;
        }

        if (this.isSelectionMode) {
            if (e.Button == MouseButtons.Left) {
                foreach (Figure figure in this.array) {
                    // Проверяем, находится ли точка в границах фигуры
                    if (figure.ContainsPoint(new Point(e.X + scr_x, e.Y + scr_y))) {
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

    private void Form2_MouseMove(object sender, MouseEventArgs e) {
        CursorMoved?.Invoke(e.Location.X, e.Location.Y);

        if (this.flag == 1) {
            this.DoubleBuffered = true;
            var bufferZone = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);
            this.buffer = this.bufferPlace.Allocate(this.CreateGraphics(), bufferZone);
            var bg_color = new SolidBrush(Color.White);
            this.buffer.Graphics.FillRectangle(bg_color, bufferZone);
            foreach (Figure f in this.array) {
                f.Draw(this.buffer.Graphics);
            }

            var no_curve = new Point[1];
            var no_font = new Font("", 1);
            string no_text = "";
            if (UxMainWindow.FigureType == 1) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new Rect(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    r.Dash(this.buffer.Graphics);
                    this.buffer.Render(this.CreateGraphics());
                }

                r = new Rect(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    r.Hide(this.buffer.Graphics);
                }
            }

            if (UxMainWindow.FigureType == 2) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new Ellipse(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    r.Dash(this.buffer.Graphics);
                    this.buffer.Render(this.CreateGraphics());
                }

                r = new Ellipse(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    r.Hide(this.buffer.Graphics);
                }
            }

            if (UxMainWindow.FigureType == 3) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new Line(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    r.Dash(this.buffer.Graphics);
                    this.buffer.Render(this.CreateGraphics());
                }

                r = new Line(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    r.Hide(this.buffer.Graphics);
                }
            }

            if (UxMainWindow.FigureType == 4) {

                var points1 = new Point[this.points.Count()];
                for (int i = 0 ; i < this.points.Count() ; i++) {
                    points1[i] = this.points[i];
                }

                var CL1 = new CurveLine(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.pix, UxMainWindow.IsFilling, points1, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    CL1.Hide(this.buffer.Graphics);
                }

                this.x2 = e.X;
                this.y2 = e.Y;
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    this.points.Add(new Point(this.x2 + scr_x, this.y2 + scr_y));
                }

                var points2 = new Point[this.points.Count()];
                for (int i = 0 ; i < this.points.Count() ; i++) {
                    points2[i] = this.points[i];
                }

                var CL2 = new CurveLine(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.pix, UxMainWindow.IsFilling, points2, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    CL2.Dash(this.buffer.Graphics);
                    this.buffer.Render(this.CreateGraphics());
                }
            }

            if (UxMainWindow.FigureType == 5) {
                _ = this.CreateGraphics();
                this.x2 = e.X;
                this.y2 = e.Y;
                var r = new TxtBox(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), Color.Black, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    r.Dash(this.buffer.Graphics);
                    this.buffer.Render(this.CreateGraphics());
                }

                r = new TxtBox(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), Color.White, Color.White, 1, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) < (this.Sz.Width + scr_x) && (this.y2 + scr_y) < (this.Sz.Height + scr_y)) {
                    r.Hide(this.buffer.Graphics);
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
            this.buffer.Dispose();
        }
    }

    private void Form2_MouseUp(object sender, MouseEventArgs e) {
        var no_font = new Font("", 1);
        var no_curve = new Point[1];
        string no_text = "";
        if (e.Button == MouseButtons.Left) {
            if (UxMainWindow.FigureType == 1) {
                Graphics g = this.CreateGraphics();
                var r = new Rect(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.pix, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) <= this.Sz.Width && (this.y2 + scr_y) <= this.Sz.Height) {
                    r.Draw(g);
                    this.array.Add(r);
                    this.Invalidate();
                }

                this.flag = 0;
                this.flagMod = true;
            }

            if (UxMainWindow.FigureType == 2) {
                Graphics g = this.CreateGraphics();
                var r = new Ellipse(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.pix, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) <= this.Sz.Width && (this.y2 + scr_y) <= this.Sz.Height) {
                    r.Draw(g);
                    this.array.Add(r);
                    this.Invalidate();
                }

                this.flag = 0;
                this.flagMod = true;
            }

            if (UxMainWindow.FigureType == 3) {
                Graphics g = this.CreateGraphics();
                var r = new Line(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.pix, UxMainWindow.IsFilling, no_curve, no_font, no_text);
                if ((this.x2 + scr_x) <= this.Sz.Width && (this.y2 + scr_y) <= this.Sz.Height) {
                    r.Draw(g);
                    this.array.Add(r);
                    this.Invalidate();
                }

                this.flag = 0;
                this.flagMod = true;
            }

            if (UxMainWindow.FigureType == 4) {
                Graphics g = this.CreateGraphics();
                var points2 = new Point[this.points.Count()];
                for (int i = 0 ; i < this.points.Count() ; i++) {
                    points2[i] = this.points[i];
                }

                var r = new CurveLine(new Point(this.x1 + scr_x, this.y1 + scr_y), new Point(this.x2 + scr_x, this.y2 + scr_y), UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.pix, UxMainWindow.IsFilling, points2, no_font, no_text);
                if ((this.x2 + scr_x) <= this.Sz.Width && (this.y2 + scr_y) <= this.Sz.Height) {
                    r.Draw(g);
                    this.array.Add(r);
                    this.Invalidate();
                }

                this.flag = 0;
                this.flagMod = true;
                this.points.Clear();
            }

            if (UxMainWindow.FigureType == 5) {
                Font font = UxMainWindow.TextFont;
                if ((this.x2 + scr_x) <= this.Sz.Width && (this.y2 + scr_y) <= this.Sz.Height) {
                    var MyTextBox = new TextBox();
                    MyTextBox.KeyDown += this.MyTextBox_KeyDown;
                    MyTextBox.Parent = this;
                    MyTextBox.Font = font;
                    MyTextBox.Multiline = true;
                    MyTextBox.ForeColor = UxMainWindow.LineColor;
                    MyTextBox.Location = new Point(this.x1 + scr_x, this.y1 + scr_y);
                    MyTextBox.Width = this.x2 - this.x1;
                    MyTextBox.Height = this.y2 - this.y1;
                }

                this.flag = 0;
            }

            if (e.Button == MouseButtons.Left && this.isDragging) {
                this.isDragging = false; // Завершаем перетаскивание
                this.flag = 0;
            }
        }
    }

    private void Form2_Paint(object sender, PaintEventArgs e) {
        this.DoubleBuffered = true;
        var buffer_ground = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);
        this.buffer = this.bufferPlace.Allocate(this.CreateGraphics(), buffer_ground);
        scr_x = Math.Abs(this.AutoScrollPosition.X);
        scr_y = Math.Abs(this.AutoScrollPosition.Y);
        if (this.flag == 0) {
            var background = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);
            var bg_color = new SolidBrush(Color.White);
            this.buffer.Graphics.FillRectangle(bg_color, background);
            foreach (Figure f in this.array) {
                f.Draw(this.buffer.Graphics);
            }
        }

        this.DoubleBuffered = false;
        this.buffer.Render(this.CreateGraphics());
        this.buffer.Dispose();

        if (this.selectedFigure != null && this.isSelectionMode) {
            // Рисуем пунктирный контур вокруг выбранной фигуры
            Graphics graphics = e.Graphics;
            var pen = new Pen(Color.Blue, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            this.selectedFigure.DrawSelection(graphics, pen); // Метод для рисования выделения
        }
    }

    private void Close(object sender, FormClosingEventArgs e) {

        if (this.flagMod) {
            DialogResult res = MessageBox.Show("Вы хотите сохранить изменения в документе?", "Attention", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes) {
                UxMainWindow.SaveFile(this);
            } else if (res == DialogResult.Cancel) {
                e.Cancel = true;
            }
        }
    }

    private void Form2_Load(object sender, EventArgs e) {
        scr_x = this.AutoScrollPosition.X;
        scr_y = this.AutoScrollPosition.Y;

        var buffer_ground = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);
        this.Size = new Size(this.Sz.Width, this.Sz.Height);
        this.bufferPlace = BufferedGraphicsManager.Current;
        this.bufferPlace.MaximumBuffer = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height);

        this.buffer = this.bufferPlace.Allocate(this.CreateGraphics(), buffer_ground);
        var background = new Rectangle(0, 0, this.Sz.Width, this.Sz.Height);
        var bg_color = new SolidBrush(Color.White);
        this.buffer.Graphics.FillRectangle(bg_color, background);
        this.DoubleBuffered = false;
        this.buffer.Render(this.CreateGraphics());
        this.buffer.Dispose();
    }

    private void Form2_Activated(object sender, EventArgs e) {
        windowsizex = this.Sz.Width;
        windowsizey = this.Sz.Height;
        FormActivated?.Invoke(this.Sz.Width, this.Sz.Height);
    }

    public void MyTextBox_KeyDown(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Enter) {
            var MyTextBox = (TextBox)sender;
            MyTextBox.ReadOnly = true;
            MyTextBox.Visible = false;
            var no_curve = new Point[1];
            Graphics g = this.CreateGraphics();
            this.text1 = MyTextBox.Text;
            Font font = UxMainWindow.TextFont;
            var r = new TxtBox(MyTextBox.Location, MyTextBox.Location + MyTextBox.Size, UxMainWindow.LineColor, UxMainWindow.BackgroundColor, UxBrushSize.pix, UxMainWindow.IsFilling, no_curve, font, this.text1);
            r.Draw(g);
            this.array.Add(r);
            this.Invalidate();
            MyTextBox.Dispose();
            this.flag = 0;
            this.flagMod = true;
        }
    }
    private void DeleteSelectedFigure() {
        if (this.selectedFigure != null) {
            _ = this.array.Remove(this.selectedFigure); // Удаляем выбранную фигуру
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