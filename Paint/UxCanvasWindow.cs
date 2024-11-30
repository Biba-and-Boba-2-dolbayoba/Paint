using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Paint
{
    [Serializable()]
    public partial class UxCanvasWindow : Form
    {
        int x1;
        int y1;
        int x2;
        int y2;
        public static int x_mouse;
        public static int y_mouse;
        public static String TextXY = "Координаты мыши - " + x_mouse + " " + y_mouse;
        public string fileName = null;
        public int flag;
        public bool flag3 = false;
        public bool flagMod = true;
        public List<Figure> array = new List<Figure>();
        public List<Point> points = new List<Point>();
        public Size Sz = new Size(UxMainWindow.setWidth(), UxMainWindow.setHeigh());
        public static int scr_x;
        public static int scr_y;
        public static int windowsizex;
        public static int windowsizey;
        private Figure selectedFigure = null;   // Выбранная фигура
        private Point dragStartPoint;           // Точка начала перетаскивания
        private bool isDragging = false;        // Флаг перетаскивания
        public bool isSelectionMode { get; set; } // Флаг режима выделения

        Font font = UxMainWindow.text_font;
        public string text1 = "";


        public event Action<int, int> CursorMoved;
        public event Action<int, int> FormActivated;

        BufferedGraphicsContext bufferPlace;
        BufferedGraphics buffer;

        public UxCanvasWindow()
        {
            InitializeComponent();

            this.AutoScroll = true;
            this.AutoScrollMinSize = this.Sz;
            this.MouseMove += Form2_MouseMove;
            this.Activated += Form2_Activated;

        }

        public void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            points = new List<Point>();
            scr_x = Math.Abs(this.AutoScrollPosition.X);
            scr_y = Math.Abs(this.AutoScrollPosition.Y);
            if (e.Button == MouseButtons.Left && flag != 5)
            {
                x1 = e.X;
                y1 = e.Y;
                points.Add(new Point(x1 + scr_x, y1 + scr_y));
                x2 = x1 + 1;
                y2 = y1 + 1;
                points.Add(new Point(x2 + scr_x, y2 + scr_y));
                flag = 1;

            }
            else if (e.Button == MouseButtons.Left && flag == 5)
            {
                x1 = e.X;
                y1 = e.Y;
                points.Add(new Point(x1 + scr_x, y1 + scr_y));
                x2 = x1 + 1;
                y2 = y1 + 1;
                points.Add(new Point(x2 + scr_x, y2 + scr_y));
                flag = 1;
            }
            if (isSelectionMode) 
            {
                if (e.Button == MouseButtons.Left)
                {
                    foreach (var figure in array)
                    {
                        // Проверяем, находится ли точка в границах фигуры
                        if (figure.ContainsPoint(new Point(e.X + scr_x, e.Y + scr_y)))
                        {
                            selectedFigure = figure; // Устанавливаем выбранную фигуру
                            dragStartPoint = new Point(e.X, e.Y);
                            isDragging = true;
                            Invalidate(); // Перерисовка для отображения выделения
                            return;
                        }
                    }

                    // Если щелчок был вне фигуры, снимаем выделение
                    selectedFigure = null;
                    isDragging = false;
                    Invalidate();
                }
            }
           
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            CursorMoved?.Invoke(e.Location.X, e.Location.Y);

            if (flag == 1)
            {
                this.DoubleBuffered = true;
                Rectangle bufferZone = new Rectangle(0, 0, Sz.Width, Sz.Height);
                this.buffer = this.bufferPlace.Allocate(this.CreateGraphics(), bufferZone);
                SolidBrush bg_color = new SolidBrush(Color.White);
                buffer.Graphics.FillRectangle(bg_color, bufferZone);
                foreach (Figure f in array)
                {
                    f.Draw(buffer.Graphics);
                }
                Point[] no_curve = new Point[1];
                Font no_font = new Font("", 1);
                string no_text = "";
                if (UxMainWindow.type_figure == 1)
                {
                    Graphics g2 = CreateGraphics();
                    x2 = e.X;
                    y2 = e.Y;
                    Rect r = new Rect(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), Color.Black, Color.White, 1, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        r.Dash(buffer.Graphics);
                        buffer.Render(this.CreateGraphics());
                    }
                    r = new Rect(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), Color.White, Color.White, 1, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        r.Hide(buffer.Graphics);
                    }
                }

                if (UxMainWindow.type_figure == 2)
                {
                    Graphics g2 = CreateGraphics();
                    x2 = e.X;
                    y2 = e.Y;
                    Ellipse r = new Ellipse(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), Color.Black, Color.White, 1, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        r.Dash(buffer.Graphics);
                        buffer.Render(this.CreateGraphics());
                    }
                    r = new Ellipse(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), Color.White, Color.White, 1, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        r.Hide(buffer.Graphics);
                    }
                }

                if (UxMainWindow.type_figure == 3)
                {
                    Graphics g2 = CreateGraphics();
                    x2 = e.X;
                    y2 = e.Y;
                    Line r = new Line(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), Color.Black, Color.White, 1, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        r.Dash(buffer.Graphics);
                        buffer.Render(this.CreateGraphics());
                    }
                    r = new Line(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), Color.White, Color.White, 1, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        r.Hide(buffer.Graphics);
                    }
                }

                if (UxMainWindow.type_figure == 4)
                {


                    Point[] points1 = new Point[this.points.Count()];
                    for (int i = 0; i < this.points.Count(); i++)
                    {
                        points1[i] = points[i];
                    }
                    CurveLine CL1 = new CurveLine(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), UxMainWindow.line_color, UxMainWindow.back_color, UxBrushSize.pix, UxMainWindow.back_TF2, points1, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        CL1.Hide(buffer.Graphics);
                    }
                    x2 = e.X;
                    y2 = e.Y;
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        this.points.Add(new Point(x2 + scr_x, y2 + scr_y));
                    }

                    Point[] points2 = new Point[this.points.Count()];
                    for (int i = 0; i < this.points.Count(); i++)
                    {
                        points2[i] = points[i];
                    }
                    CurveLine CL2 = new CurveLine(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), UxMainWindow.line_color, UxMainWindow.back_color, UxBrushSize.pix, UxMainWindow.back_TF2, points2, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        CL2.Dash(buffer.Graphics);
                        buffer.Render(this.CreateGraphics());
                    }
                }
                if (UxMainWindow.type_figure == 5)
                {
                    Graphics g2 = CreateGraphics();
                    x2 = e.X;
                    y2 = e.Y;
                    TxtBox r = new TxtBox(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), Color.Black, Color.White, 1, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        r.Dash(buffer.Graphics);
                        buffer.Render(this.CreateGraphics());
                    }
                    r = new TxtBox(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), Color.White, Color.White, 1, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) < (Sz.Width + scr_x) && (y2 + scr_y) < (Sz.Height + scr_y))
                    {
                        r.Hide(buffer.Graphics);
                    }
                }
                if (isDragging && selectedFigure != null)
                {
                    int dx = e.X - dragStartPoint.X; // Разница по X
                    int dy = e.Y - dragStartPoint.Y; // Разница по Y

                    // Проверяем, можно ли переместить фигуру без выхода за границы
                    if (selectedFigure.CanMove(dx, dy, Sz))
                    {
                        selectedFigure.Move(dx, dy);
                        dragStartPoint = new Point(e.X, e.Y);

                        // Перерисовка
                        Invalidate();
                    }
                }
                this.DoubleBuffered = false;
                this.buffer.Dispose();
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            Font no_font = new Font("", 1);
            Point[] no_curve = new Point[1];
            string no_text = "";
            if (e.Button == MouseButtons.Left)
            {
                if (UxMainWindow.type_figure == 1)
                {
                    Graphics g = CreateGraphics();
                    Rect r = new Rect(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), UxMainWindow.line_color, UxMainWindow.back_color, UxBrushSize.pix, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) <= (Sz.Width) && (y2 + scr_y) <= (Sz.Height))
                    {
                        r.Draw(g);
                        array.Add(r);
                        this.Invalidate();
                    }
                    flag = 0;
                    flagMod = true;
                }
                if (UxMainWindow.type_figure == 2)
                {
                    Graphics g = CreateGraphics();
                    Ellipse r = new Ellipse(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), UxMainWindow.line_color, UxMainWindow.back_color, UxBrushSize.pix, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) <= (Sz.Width) && (y2 + scr_y) <= (Sz.Height))
                    {
                        r.Draw(g);
                        array.Add(r);
                        this.Invalidate();
                    }
                    flag = 0;
                    flagMod = true;
                }
                if (UxMainWindow.type_figure == 3)
                {
                    Graphics g = CreateGraphics();
                    Line r = new Line(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), UxMainWindow.line_color, UxMainWindow.back_color, UxBrushSize.pix, UxMainWindow.back_TF2, no_curve, no_font, no_text);
                    if ((x2 + scr_x) <= (Sz.Width) && (y2 + scr_y) <= (Sz.Height))
                    {
                        r.Draw(g);
                        array.Add(r);
                        this.Invalidate();
                    }
                    flag = 0;
                    flagMod = true;
                }
                if (UxMainWindow.type_figure == 4)
                {
                    Graphics g = CreateGraphics();
                    Point[] points2 = new Point[this.points.Count()];
                    for (int i = 0; i < this.points.Count(); i++)
                    {
                        points2[i] = points[i];
                    }
                    CurveLine r = new CurveLine(new Point(x1 + scr_x, y1 + scr_y), new Point(x2 + scr_x, y2 + scr_y), UxMainWindow.line_color, UxMainWindow.back_color, UxBrushSize.pix, UxMainWindow.back_TF2, points2, no_font, no_text);
                    if ((x2 + scr_x) <= (Sz.Width) && (y2 + scr_y) <= (Sz.Height))
                    {
                        r.Draw(g);
                        array.Add(r);
                        this.Invalidate();
                    }
                    flag = 0;
                    flagMod = true;
                    points.Clear();
                }
                if (UxMainWindow.type_figure == 5)
                {
                    Font font = UxMainWindow.text_font;
                    if ((x2 + scr_x) <= (Sz.Width) && (y2 + scr_y) <= (Sz.Height))
                    {
                        TextBox MyTextBox = new TextBox();
                        MyTextBox.KeyDown += MyTextBox_KeyDown;
                        MyTextBox.Parent = this;
                        MyTextBox.Font = font;
                        MyTextBox.Multiline = true;
                        MyTextBox.ForeColor = UxMainWindow.line_color;
                        MyTextBox.Location = new Point(x1 + scr_x, y1 + scr_y);
                        MyTextBox.Width = x2 - x1;
                        MyTextBox.Height = y2 - y1;
                    }
                    flag = 0;
                }
                if (e.Button == MouseButtons.Left && isDragging)
                {
                    isDragging = false; // Завершаем перетаскивание
                    flag = 0;
                }


            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            Rectangle buffer_ground = new Rectangle(0, 0, Sz.Width, Sz.Height);
            this.buffer = bufferPlace.Allocate(this.CreateGraphics(), buffer_ground);
            scr_x = Math.Abs(this.AutoScrollPosition.X);
            scr_y = Math.Abs(this.AutoScrollPosition.Y);
            if (flag == 0)
            {
                Rectangle background = new Rectangle(0, 0, Sz.Width, Sz.Height);
                SolidBrush bg_color = new SolidBrush(Color.White);
                buffer.Graphics.FillRectangle(bg_color, background);
                foreach (Figure f in array)
                {
                    f.Draw(buffer.Graphics);
                }
            }
            this.DoubleBuffered = false;
            buffer.Render(this.CreateGraphics());
            buffer.Dispose();

            if (selectedFigure != null && isSelectionMode)
            {
                // Рисуем пунктирный контур вокруг выбранной фигуры
                var graphics = e.Graphics;
                var pen = new Pen(Color.Blue, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                selectedFigure.DrawSelection(graphics, pen); // Метод для рисования выделения
            }
        }

        private void Close(object sender, FormClosingEventArgs e)
        {

            if (flagMod)
            {
                DialogResult res = MessageBox.Show("Вы хотите сохранить изменения в документе?", "Attention", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    UxMainWindow.saveFile(this);
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            scr_x = this.AutoScrollPosition.X;
            scr_y = this.AutoScrollPosition.Y;

            Rectangle buffer_ground = new Rectangle(0, 0, Sz.Width, Sz.Height);
            this.Size = new Size(Sz.Width, Sz.Height);
            this.bufferPlace = BufferedGraphicsManager.Current;
            bufferPlace.MaximumBuffer = new Size(SystemInformation.PrimaryMonitorMaximizedWindowSize.Width, SystemInformation.PrimaryMonitorMaximizedWindowSize.Height);

            this.buffer = bufferPlace.Allocate(this.CreateGraphics(), buffer_ground);
            Rectangle background = new Rectangle(0, 0, Sz.Width, Sz.Height);
            SolidBrush bg_color = new SolidBrush(Color.White);
            buffer.Graphics.FillRectangle(bg_color, background);
            this.DoubleBuffered = false;
            buffer.Render(this.CreateGraphics());
            buffer.Dispose();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            windowsizex = Sz.Width;
            windowsizey = Sz.Height;
            FormActivated?.Invoke(Sz.Width, Sz.Height);
        }

        public void MyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox MyTextBox = (TextBox)sender;
                MyTextBox.ReadOnly = true;
                MyTextBox.Visible = false;
                Point[] no_curve = new Point[1];
                Graphics g = CreateGraphics();
                this.text1 = MyTextBox.Text;
                Font font = UxMainWindow.text_font;
                TxtBox r = new TxtBox(MyTextBox.Location, MyTextBox.Location + MyTextBox.Size, UxMainWindow.line_color, UxMainWindow.back_color, UxBrushSize.pix, UxMainWindow.back_TF2, no_curve, font, text1);
                r.Draw(g);
                array.Add(r);
                this.Invalidate();
                MyTextBox.Dispose();
                flag = 0;
                flagMod = true;
            }
        }
        private void DeleteSelectedFigure()
        {
            if (selectedFigure != null)
            {
                array.Remove(selectedFigure); // Удаляем выбранную фигуру
                selectedFigure = null;        // Сбрасываем выделение
                Invalidate();                 // Перерисовка
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete)
            {
                DeleteSelectedFigure();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}