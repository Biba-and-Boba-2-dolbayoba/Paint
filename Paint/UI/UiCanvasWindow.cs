using Paint.Figures;
using Paint.States;
using System.ComponentModel;

namespace Paint;

[Serializable()]
public partial class UiCanvasWindow : Form {
    private Point StartPoint { get; set; }

    private Point EndPoint { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string? CanvasName { get; set; } = null;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsSelectionMode { get; set; } = false;

    private bool IsDrawing { get; set; } = false;

    private bool IsCanvasEmpty { get; set; } = true;

    private List<Point> Points { get; set; } = [];

    private List<Figure> Figures { get; set; } = [];

    private Size CanvasSize { get; set; }

    private Figure? SelectedFigure { get; set; } = null;

    private Point DragStartPoint { get; set; } = new();

    private bool IsDragging { get; set; } = false;

    private BufferedGraphics? GraphicsBuffer { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IState State { get; set; } = new SelectState();

    public UiCanvasWindow() {
        this.InitializeComponent();
        this.AutoScroll = false;
    }

    private void UpdateGraphicsBuffer(Rectangle bufferArea) {
        BufferedGraphicsContext bufferedContext = BufferedGraphicsManager.Current;
        this.GraphicsBuffer = bufferedContext.Allocate(this.CreateGraphics(), bufferArea);
    }

    private void MouseDownHandler(object sender, MouseEventArgs e) {
        this.Points = [];

        if (e.Button == MouseButtons.Left && !this.IsDrawing) {
            this.StartPoint = new Point(e.X, e.Y);
            this.EndPoint = new Point(e.X, e.Y);

            this.Points.Add(this.StartPoint);
            this.Points.Add(this.EndPoint);

            this.IsDrawing = true;
        }

        //if (this.State is SelectState state) {
        //    state.MouseDownHandler(sender, e);
        //}

        if (this.State is DrawState) {
            return;
        }

        if (this.State is EditState) {
            return;
        }
    }

    private void MouseMoveHandler(object sender, MouseEventArgs e) {
        if (this.IsDrawing && this.MdiParent is UiMainWindow parent && this.GraphicsBuffer is not null) {
            this.DoubleBuffered = true;
            var bufferZone = new Rectangle(0, 0, this.CanvasSize.Width, this.CanvasSize.Height);

            Graphics graphics = this.GraphicsBuffer.Graphics;

            var bg_color = new SolidBrush(Color.White);
            graphics.FillRectangle(bg_color, bufferZone);
            foreach (Figure f in this.Figures) {
                f.Draw(graphics);
            }

            var no_curve = new Point[1];
            var no_font = new Font("", 1);
            string no_text = "";
            if (parent.FigureType == 1) {
                this.EndPoint = new Point(e.X, e.Y);
                var r = new Rect(this.StartPoint, this.EndPoint, Color.Black, Color.White, 1, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    r.Dash(graphics);
                    this.GraphicsBuffer.Render(this.CreateGraphics());
                }

                parent.UpdatePointerInfo(this.StartPoint, this.EndPoint);
                r.Hide(graphics);
            }

            if (parent.FigureType == 2) {
                this.EndPoint = new Point(e.X, e.Y);
                var r = new Ellipse(this.StartPoint, this.EndPoint, Color.Black, Color.White, 1, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    r.Dash(graphics);
                    this.GraphicsBuffer.Render(this.CreateGraphics());
                }

                r = new Ellipse(this.StartPoint, this.EndPoint, Color.White, Color.White, 1, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    r.Hide(graphics);
                }
            }

            if (parent.FigureType == 3) {
                this.EndPoint = new Point(e.X, e.Y);
                var r = new Line(this.StartPoint, this.EndPoint, Color.Black, Color.White, 1, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    r.Dash(graphics);
                    this.GraphicsBuffer.Render(this.CreateGraphics());
                }

                r = new Line(this.StartPoint, this.EndPoint, Color.White, Color.White, 1, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    r.Hide(graphics);
                }
            }

            if (parent.FigureType == 4) {
                var points1 = new Point[this.Points.Count];
                for (int i = 0 ; i < this.Points.Count ; i++) {
                    points1[i] = this.Points[i];
                }

                var CL1 = new CurveLine(this.StartPoint, this.EndPoint, parent.BrushColor, parent.FillingColor, parent.BrushSize, parent.IsFilling, points1, no_font, no_text);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    CL1.Hide(graphics);
                }

                this.EndPoint = new Point(e.X, e.Y);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    this.Points.Add(this.EndPoint);
                }

                var points2 = new Point[this.Points.Count];
                for (int i = 0 ; i < this.Points.Count ; i++) {
                    points2[i] = this.Points[i];
                }

                var CL2 = new CurveLine(this.StartPoint, this.EndPoint, parent.BrushColor, parent.FillingColor, parent.BrushSize, parent.IsFilling, points2, no_font, no_text);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    CL2.Dash(graphics);
                    this.GraphicsBuffer.Render(this.CreateGraphics());
                }
            }

            if (parent.FigureType == 5) {
                this.EndPoint = new Point(e.X, e.Y);
                var r = new TxtBox(this.StartPoint, this.EndPoint, Color.Black, Color.White, 1, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    r.Dash(graphics);
                    this.GraphicsBuffer.Render(this.CreateGraphics());
                }

                r = new TxtBox(this.StartPoint, this.EndPoint, Color.White, Color.White, 1, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X < this.CanvasSize.Width && this.EndPoint.Y < this.CanvasSize.Height) {
                    r.Hide(graphics);
                }
            }

            if (this.IsDragging && this.SelectedFigure != null) {
                int dx = e.X - this.DragStartPoint.X;
                int dy = e.Y - this.DragStartPoint.Y;

                if (this.SelectedFigure.CanMove(dx, dy, this.CanvasSize)) {
                    this.SelectedFigure.Move(dx, dy);
                    this.DragStartPoint = new Point(e.X, e.Y);
                }
            }

            this.DoubleBuffered = false;
        }
    }

    private void MouseUpHandler(object sender, MouseEventArgs e) {
        var no_font = new Font("", 1);
        var no_curve = new Point[1];
        string no_text = "";
        if (e.Button == MouseButtons.Left && this.MdiParent is UiMainWindow parent && this.GraphicsBuffer is not null) {
            this.DoubleBuffered = true;
            var bufferZone = new Rectangle(0, 0, this.CanvasSize.Width, this.CanvasSize.Height);

            this.UpdateGraphicsBuffer(bufferZone);

            Graphics graphics = this.GraphicsBuffer.Graphics;

            if (parent.FigureType == 1) {
                var r = new Rect(this.StartPoint, this.EndPoint, parent.BrushColor, parent.FillingColor, parent.BrushSize, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X <= this.CanvasSize.Width && this.EndPoint.Y <= this.CanvasSize.Height) {
                    r.Draw(graphics);
                    this.Figures.Add(r);
                    this.GraphicsBuffer.Render(this.CreateGraphics());
                    this.Invalidate();
                }

                this.IsDrawing = false;
                this.IsCanvasEmpty = false;
            }

            if (parent.FigureType == 2) {
                var r = new Ellipse(this.StartPoint, this.EndPoint, parent.BrushColor, parent.FillingColor, parent.BrushSize, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X <= this.CanvasSize.Width && this.EndPoint.Y <= this.CanvasSize.Height) {
                    r.Draw(graphics);
                    this.Figures.Add(r);
                    this.GraphicsBuffer.Render(this.CreateGraphics());
                    this.Invalidate();
                }

                this.IsDrawing = false;
                this.IsCanvasEmpty = false;
            }

            if (parent.FigureType == 3) {
                var r = new Line(this.StartPoint, this.EndPoint, parent.BrushColor, parent.FillingColor, parent.BrushSize, parent.IsFilling, no_curve, no_font, no_text);
                if (this.EndPoint.X <= this.CanvasSize.Width && this.EndPoint.Y <= this.CanvasSize.Height) {
                    r.Draw(graphics);
                    this.Figures.Add(r);
                    this.GraphicsBuffer.Render(this.CreateGraphics());
                    this.Invalidate();
                }

                this.IsDrawing = false;
                this.IsCanvasEmpty = false;
            }

            if (parent.FigureType == 4) {
                var points2 = new Point[this.Points.Count];
                for (int i = 0 ; i < this.Points.Count ; i++) {
                    points2[i] = this.Points[i];
                }

                var r = new CurveLine(this.StartPoint, this.EndPoint, parent.BrushColor, parent.FillingColor, parent.BrushSize, parent.IsFilling, points2, no_font, no_text);
                if (this.EndPoint.X <= this.CanvasSize.Width && this.EndPoint.Y <= this.CanvasSize.Height) {
                    r.Draw(graphics);
                    this.Figures.Add(r);
                    this.GraphicsBuffer.Render(this.CreateGraphics());
                    this.Invalidate();
                }

                this.IsDrawing = false;
                this.IsCanvasEmpty = false;
                this.Points.Clear();
            }

            if (parent.FigureType == 5) {
                Font font = parent.TextFont;
                if (this.EndPoint.X <= this.CanvasSize.Width && this.EndPoint.Y <= this.CanvasSize.Height) {
                    var MyTextBox = new TextBox();
                    MyTextBox.KeyDown += this.MyTextBox_KeyDown;
                    MyTextBox.Parent = this;
                    MyTextBox.Font = font;
                    MyTextBox.Multiline = true;
                    MyTextBox.ForeColor = parent.BrushColor;
                    MyTextBox.Location = this.StartPoint;
                    MyTextBox.Width = this.EndPoint.X - this.StartPoint.X;
                    MyTextBox.Height = this.EndPoint.Y - this.StartPoint.Y;
                }

                this.IsCanvasEmpty = false;
                this.IsDrawing = false;
            }

            if (e.Button == MouseButtons.Left && this.IsDragging) {
                this.IsDragging = false;
                this.IsDrawing = false;
            }

            this.DoubleBuffered = false;
        }
    }

    private void PaintHandler(object sender, PaintEventArgs e) {
        this.DoubleBuffered = true;
        var background = new Rectangle(0, 0, this.CanvasSize.Width, this.CanvasSize.Height);
        this.UpdateGraphicsBuffer(background);

        if (!this.IsDrawing && this.GraphicsBuffer is not null) {
            var bg_color = new SolidBrush(Color.White);
            this.GraphicsBuffer.Graphics.FillRectangle(bg_color, background);
            foreach (Figure f in this.Figures) {
                f.Draw(this.GraphicsBuffer.Graphics);
            }

            if (this.SelectedFigure != null && this.IsSelectionMode) {
                var pen = new Pen(Color.Blue, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                this.GraphicsBuffer.Graphics.FillRectangle(bg_color, background);
                this.SelectedFigure.Hide(this.GraphicsBuffer.Graphics);
                this.SelectedFigure.DrawSelection(this.GraphicsBuffer.Graphics, pen);
                this.GraphicsBuffer.Render(e.Graphics);
            }

            this.GraphicsBuffer.Render(e.Graphics);
        }

        this.DoubleBuffered = false;
    }

    private void CloseHandler(object sender, FormClosingEventArgs e) {
        if (!this.IsCanvasEmpty) {
            DialogResult res = MessageBox.Show("Вы хотите сохранить изменения в документе?", "Attention", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes) {
                UiMainWindow.SaveFile(this);
            } else if (res == DialogResult.Cancel) {
                e.Cancel = true;
            }
        }
    }

    private void LoadHandler(object sender, EventArgs e) {
        if (this.MdiParent is UiMainWindow parent) {
            this.CanvasSize = new(parent.CanvasWidth, parent.CanvasHeight);
        }

        var background = new Rectangle(0, 0, this.CanvasSize.Width, this.CanvasSize.Height);
        this.Size = new Size(this.CanvasSize.Width, this.CanvasSize.Height);

        this.UpdateGraphicsBuffer(background);

        if (this.GraphicsBuffer is not null) {
            Graphics graphics = this.GraphicsBuffer.Graphics;
            var bg_color = new SolidBrush(Color.White);
            graphics.FillRectangle(bg_color, background);
            this.DoubleBuffered = false;
        }
    }

    private void MyTextBox_KeyDown(object? sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Enter && this.MdiParent is UiMainWindow parent && sender is not null && this.GraphicsBuffer is not null) {
            var MyTextBox = (TextBox)sender;
            MyTextBox.ReadOnly = true;
            MyTextBox.Visible = false;
            var no_curve = new Point[1];
            this.DoubleBuffered = true;
            Graphics graphics = this.GraphicsBuffer.Graphics;
            Font font = parent.TextFont;
            var r = new TxtBox(MyTextBox.Location, MyTextBox.Location, parent.BrushColor, parent.FillingColor, parent.BrushSize, parent.IsFilling, no_curve, font, MyTextBox.Text);
            r.Draw(graphics);
            this.Figures.Add(r);
            this.Invalidate();
            MyTextBox.Dispose();
            this.IsDrawing = false;
            this.GraphicsBuffer.Render(this.CreateGraphics());
            this.DoubleBuffered = false;
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

    private void ResizeHandler(object sender, EventArgs e) {
        var background = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
        var bg_color = new SolidBrush(Color.White);
        this.CanvasSize = this.Size;
        this.UpdateGraphicsBuffer(background);

        if (this.GraphicsBuffer is not null) {
            Graphics graphics = this.GraphicsBuffer.Graphics;
            graphics.FillRectangle(bg_color, background);
        }
    }

    public void PaintBitmap(Graphics g) {
        foreach (Figure f in this.Figures) {
            f.Draw(g);
        }
    }
}
