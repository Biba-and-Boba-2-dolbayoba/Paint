namespace Paint;

[Serializable()]
public abstract class Figure {
    public int px = 1;
    public Color line_color;
    public Color back_color;
    public Point point1;
    public Point point2;
    public string text;
    public bool back_TF = UxMainWindow.IsFilling;
    public Point[] mas_points;
    public Font font = new("Times New Roman", 12.0f);

    public string Pen_color = "Color.Black";
    public abstract void Draw(Graphics g);
    public abstract void Hide(Graphics g);
    public abstract void Dash(Graphics g);
    public abstract void DrawSelection(Graphics g, Pen pen);
    public abstract bool ContainsPoint(Point p);
    public Figure(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) {
        this.point1 = point1;
        this.point2 = point2;
        this.line_color = line_color;
        this.back_color = back_color;
        this.px = px;
        this.back_TF = back_TF;
        this.mas_points = mas_points;
        this.font = font;
        this.text = text;
    }
    public virtual bool CanMove(int dx, int dy, Size bounds) {
        return this.point1.X + dx >= 0 && this.point2.X + dx <= bounds.Width &&
               this.point1.Y + dy >= 0 && this.point2.Y + dy <= bounds.Height;
    }

    public virtual void Move(int dx, int dy) {
        this.point1 = new Point(this.point1.X + dx, this.point1.Y + dy);
        this.point2 = new Point(this.point2.X + dx, this.point2.Y + dy);
    }
}

[Serializable()]
public class Rect : Figure {

    public Rect(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : base(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {

    }

    public override void Draw(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.scr_x;
            maxx = this.point1.X - UxCanvasWindow.scr_x;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.scr_y;
            maxy = this.point1.Y - UxCanvasWindow.scr_y;
        }

        var pen = new Pen(this.line_color, this.px);
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        Brush brush = new SolidBrush(this.back_color);
        if (this.back_TF == true) {
            g.FillRectangle(brush, r);
        }

        g.DrawRectangle(pen, r);

    }

    public override void Hide(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.scr_x;
            maxx = this.point1.X - UxCanvasWindow.scr_x;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.scr_y;
            maxy = this.point1.Y - UxCanvasWindow.scr_y;
        }

        var penwhite = new Pen(Color.White, 1);
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        g.DrawRectangle(penwhite, r);
    }

    public override void Dash(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.scr_x;
            maxx = this.point1.X - UxCanvasWindow.scr_x;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.scr_y;
            maxy = this.point1.Y - UxCanvasWindow.scr_y;
        }

        var pendash = new Pen(Color.Black, 1) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        g.DrawRectangle(pendash, r);
    }
    public override void DrawSelection(Graphics g, Pen pen) {
        var rect = Rectangle.FromLTRB(
            Math.Min(this.point1.X, this.point2.X),
            Math.Min(this.point1.Y, this.point2.Y),
            Math.Max(this.point1.X, this.point2.X),
            Math.Max(this.point1.Y, this.point2.Y)
        );
        g.DrawRectangle(pen, rect);
    }
    // Реализация ContainsPoint для Rect
    public override bool ContainsPoint(Point p) {
        var rect = Rectangle.FromLTRB(
            Math.Min(this.point1.X, this.point2.X),
            Math.Min(this.point1.Y, this.point2.Y),
            Math.Max(this.point1.X, this.point2.X),
            Math.Max(this.point1.Y, this.point2.Y)
        );
        return rect.Contains(p);
    }
}

[Serializable()]
public class Ellipse : Figure {

    public Ellipse(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : base(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {

    }

    public override void Draw(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.scr_x;
            maxx = this.point1.X - UxCanvasWindow.scr_x;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.scr_y;
            maxy = this.point1.Y - UxCanvasWindow.scr_y;
        }

        var pen = new Pen(this.line_color, this.px);
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        Brush brush = new SolidBrush(this.back_color);
        if (this.back_TF == true) {
            g.FillEllipse(brush, r);
        }

        g.DrawEllipse(pen, r);

    }

    public override void Hide(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.scr_x;
            maxx = this.point1.X - UxCanvasWindow.scr_x;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.scr_y;
            maxy = this.point1.Y - UxCanvasWindow.scr_y;
        }

        var penwhite = new Pen(Color.White, 1);
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        g.DrawEllipse(penwhite, r);
    }

    public override void Dash(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.scr_x;
            maxx = this.point1.X - UxCanvasWindow.scr_x;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.scr_y;
            maxy = this.point1.Y - UxCanvasWindow.scr_y;
        }

        var pendash = new Pen(Color.Black, 1) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        g.DrawEllipse(pendash, r);
    }
    public override void DrawSelection(Graphics g, Pen pen) {
        var rect = Rectangle.FromLTRB(
            Math.Min(this.point1.X, this.point2.X),
            Math.Min(this.point1.Y, this.point2.Y),
            Math.Max(this.point1.X, this.point2.X),
            Math.Max(this.point1.Y, this.point2.Y)
        );
        g.DrawRectangle(pen, rect);
    }
    // Реализация ContainsPoint для Ellipse
    public override bool ContainsPoint(Point p) {
        var rect = Rectangle.FromLTRB(
            Math.Min(this.point1.X, this.point2.X),
            Math.Min(this.point1.Y, this.point2.Y),
            Math.Max(this.point1.X, this.point2.X),
            Math.Max(this.point1.Y, this.point2.Y)
        );

        double a = rect.Width / 2.0;  // Полуось по X
        double b = rect.Height / 2.0; // Полуось по Y
        double centerX = rect.Left + a;
        double centerY = rect.Top + b;

        double normalizedX = (p.X - centerX) / a;
        double normalizedY = (p.Y - centerY) / b;

        return (normalizedX * normalizedX) + (normalizedY * normalizedY) <= 1;
    }
}

[Serializable()]
public class Line : Figure {

    public Line(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : base(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {

    }

    public override void Draw(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        var pen = new Pen(this.line_color, this.px);
        g.DrawLine(pen, minx, miny, maxx, maxy);

    }

    public override void Hide(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        var penwhite = new Pen(Color.White, 1);
        g.DrawLine(penwhite, minx, miny, maxx, maxy);
    }

    public override void Dash(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        var pendash = new Pen(Color.Black, 1) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };
        g.DrawLine(pendash, minx, miny, maxx, maxy);
    }
    public override void DrawSelection(Graphics g, Pen pen) {
        var rect = Rectangle.FromLTRB(
            Math.Min(this.point1.X, this.point2.X),
            Math.Min(this.point1.Y, this.point2.Y),
            Math.Max(this.point1.X, this.point2.X),
            Math.Max(this.point1.Y, this.point2.Y)
        );
        g.DrawRectangle(pen, rect);
    }
    public override bool ContainsPoint(Point p) {
        const int tolerance = 3;

        double distance = Math.Abs(((this.point2.Y - this.point1.Y) * p.X) -
                                    ((this.point2.X - this.point1.X) * p.Y) +
                                    (this.point2.X * this.point1.Y) -
                                    (this.point2.Y * this.point1.X)) /
                          Math.Sqrt(Math.Pow(this.point2.Y - this.point1.Y, 2) +
                                    Math.Pow(this.point2.X - this.point1.X, 2));

        return distance <= tolerance;
    }
}

[Serializable()]
public class CurveLine : Figure {

    public CurveLine(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : base(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {

    }

    public override void Draw(Graphics g) {
        var points = new Point[this.mas_points.Count() - 1];
        for (int i = 0 ; i < this.mas_points.Count() - 1 ; i++) {
            points[i].X = this.mas_points[i + 1].X - UxCanvasWindow.scr_x;
            points[i].Y = this.mas_points[i + 1].Y - UxCanvasWindow.scr_y;
        }

        var pen = new Pen(this.line_color, this.px);
        g.DrawCurve(pen, points);

    }

    public override void Hide(Graphics g) {
        var points = new Point[this.mas_points.Count()];
        for (int i = 0 ; i < this.mas_points.Count() - 1 ; i++) {
            points[i].X = this.mas_points[i + 1].X - UxCanvasWindow.scr_x;
            points[i].Y = this.mas_points[i + 1].Y - UxCanvasWindow.scr_y;
        }

        var penwhite = new Pen(Color.White, 1);
        if (points.Length > 2) {
            Point[] points1 = points.Take(points.Length - 1).ToArray();
            Console.WriteLine(points1.Last());
            g.DrawCurve(penwhite, points1);
        }
    }

    public override void Dash(Graphics g) {
        var points = new Point[this.mas_points.Count() - 1];
        for (int i = 0 ; i < this.mas_points.Count() - 1 ; i++) {
            points[i].X = this.mas_points[i + 1].X - UxCanvasWindow.scr_x;
            points[i].Y = this.mas_points[i + 1].Y - UxCanvasWindow.scr_y;
        }

        var pendash = new Pen(Color.Black, 1) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };
        g.DrawCurve(pendash, points);
    }
    public override void DrawSelection(Graphics g, Pen pen) {
        var rect = Rectangle.FromLTRB(
            Math.Min(this.point1.X, this.point2.X),
            Math.Min(this.point1.Y, this.point2.Y),
            Math.Max(this.point1.X, this.point2.X),
            Math.Max(this.point1.Y, this.point2.Y)
        );
        g.DrawRectangle(pen, rect);
    }
    public override bool ContainsPoint(Point p) {
        const int tolerance = 3;

        for (int i = 0 ; i < this.mas_points.Length - 1 ; i++) {
            Point start = this.mas_points[i];
            Point end = this.mas_points[i + 1];

            double distance = Math.Abs(((end.Y - start.Y) * p.X) -
                                        ((end.X - start.X) * p.Y) +
                                        (end.X * start.Y) -
                                        (end.Y * start.X)) /
                              Math.Sqrt(Math.Pow(end.Y - start.Y, 2) +
                                        Math.Pow(end.X - start.X, 2));

            if (distance <= tolerance) {
                return true;
            }
        }

        return false;
    }
}

[Serializable()]
public class TxtBox : Figure {

    public TxtBox(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : base(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {

    }

    public override void Draw(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.scr_x;
            maxx = this.point1.X - UxCanvasWindow.scr_x;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.scr_y;
            maxy = this.point1.Y - UxCanvasWindow.scr_y;
        }

        var pen = new Pen(Color.Transparent, this.px);
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        Brush brush = new SolidBrush(Color.Transparent);
        Brush brushtext = new SolidBrush(this.line_color);
        if (this.back_TF == true) {
            g.FillRectangle(brush, r);
        }

        g.DrawRectangle(pen, r);
        g.DrawString(this.text, this.font, brushtext, r);

    }

    public override void Hide(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.scr_x;
            maxx = this.point1.X - UxCanvasWindow.scr_x;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.scr_y;
            maxy = this.point1.Y - UxCanvasWindow.scr_y;
        }

        var penwhite = new Pen(Color.White, 1);
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        g.DrawRectangle(penwhite, r);
    }

    public override void Dash(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.scr_x;
        int miny = this.point1.Y - UxCanvasWindow.scr_y;
        int maxx = this.point2.X - UxCanvasWindow.scr_x;
        int maxy = this.point2.Y - UxCanvasWindow.scr_y;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.scr_x;
            maxx = this.point1.X - UxCanvasWindow.scr_x;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.scr_y;
            maxy = this.point1.Y - UxCanvasWindow.scr_y;
        }

        var pendash = new Pen(Color.Black, 1) {
            DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        };
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        g.DrawRectangle(pendash, r);
    }
    public override void DrawSelection(Graphics g, Pen pen) {
        var rect = Rectangle.FromLTRB(
            Math.Min(this.point1.X, this.point2.X),
            Math.Min(this.point1.Y, this.point2.Y),
            Math.Max(this.point1.X, this.point2.X),
            Math.Max(this.point1.Y, this.point2.Y)
        );
        g.DrawRectangle(pen, rect);
    }
    public override bool ContainsPoint(Point p) {
        // Проверяем попадание точки в текстовый блок
        var rect = Rectangle.FromLTRB(
            Math.Min(this.point1.X, this.point2.X),
            Math.Min(this.point1.Y, this.point2.Y),
            Math.Max(this.point1.X, this.point2.X),
            Math.Max(this.point1.Y, this.point2.Y)
        );

        return rect.Contains(p);
    }
}
