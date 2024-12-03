namespace Paint.Figures;

[Serializable()]
public abstract class Figure(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) {
    public int px = px;
    public Color line_color = line_color;
    public Color back_color = back_color;
    public Point point1 = point1;
    public Point point2 = point2;
    public string text = text;
    public bool back_TF = back_TF;
    public Point[] mas_points = mas_points;
    public Font font = font;

    public abstract void Draw(Graphics g);

    public abstract void Hide(Graphics g);

    public abstract void Dash(Graphics g);

    public abstract void DrawSelection(Graphics g, Pen pen);

    public abstract bool ContainsPoint(Point p);

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
public class Rect(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : Figure(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {
    public override void Draw(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.ScrollX;
            maxx = this.point1.X - UxCanvasWindow.ScrollX;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.ScrollY;
            maxy = this.point1.Y - UxCanvasWindow.ScrollY;
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
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.ScrollX;
            maxx = this.point1.X - UxCanvasWindow.ScrollX;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.ScrollY;
            maxy = this.point1.Y - UxCanvasWindow.ScrollY;
        }

        var penwhite = new Pen(Color.White, 1);
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        g.DrawRectangle(penwhite, r);
    }

    public override void Dash(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.ScrollX;
            maxx = this.point1.X - UxCanvasWindow.ScrollX;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.ScrollY;
            maxy = this.point1.Y - UxCanvasWindow.ScrollY;
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
public class Ellipse(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : Figure(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {
    public override void Draw(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.ScrollX;
            maxx = this.point1.X - UxCanvasWindow.ScrollX;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.ScrollY;
            maxy = this.point1.Y - UxCanvasWindow.ScrollY;
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
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.ScrollX;
            maxx = this.point1.X - UxCanvasWindow.ScrollX;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.ScrollY;
            maxy = this.point1.Y - UxCanvasWindow.ScrollY;
        }

        var penwhite = new Pen(Color.White, 1);
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        g.DrawEllipse(penwhite, r);
    }

    public override void Dash(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.ScrollX;
            maxx = this.point1.X - UxCanvasWindow.ScrollX;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.ScrollY;
            maxy = this.point1.Y - UxCanvasWindow.ScrollY;
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

        return normalizedX * normalizedX + normalizedY * normalizedY <= 1;
    }
}

[Serializable()]
public class Line(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : Figure(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {
    public override void Draw(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        var pen = new Pen(this.line_color, this.px);
        g.DrawLine(pen, minx, miny, maxx, maxy);

    }

    public override void Hide(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        var penwhite = new Pen(Color.White, 1);
        g.DrawLine(penwhite, minx, miny, maxx, maxy);
    }

    public override void Dash(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
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

        double distance = Math.Abs((this.point2.Y - this.point1.Y) * p.X -
                                    (this.point2.X - this.point1.X) * p.Y +
                                    this.point2.X * this.point1.Y -
                                    this.point2.Y * this.point1.X) /
                          Math.Sqrt(Math.Pow(this.point2.Y - this.point1.Y, 2) +
                                    Math.Pow(this.point2.X - this.point1.X, 2));

        return distance <= tolerance;
    }
}

[Serializable()]
public class CurveLine(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : Figure(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {
    public override void Draw(Graphics g) {
        var points = new Point[this.mas_points.Length - 1];
        for (int i = 0 ; i < this.mas_points.Length - 1 ; i++) {
            points[i].X = this.mas_points[i + 1].X - UxCanvasWindow.ScrollX;
            points[i].Y = this.mas_points[i + 1].Y - UxCanvasWindow.ScrollY;
        }

        var pen = new Pen(this.line_color, this.px);
        g.DrawCurve(pen, points);

    }

    public override void Hide(Graphics g) {
        var points = new Point[this.mas_points.Length];
        for (int i = 0 ; i < this.mas_points.Length - 1 ; i++) {
            points[i].X = this.mas_points[i + 1].X - UxCanvasWindow.ScrollX;
            points[i].Y = this.mas_points[i + 1].Y - UxCanvasWindow.ScrollY;
        }

        var penwhite = new Pen(Color.White, 1);
        if (points.Length > 2) {
            Point[] points1 = points.Take(points.Length - 1).ToArray();
            Console.WriteLine(points1.Last());
            g.DrawCurve(penwhite, points1);
        }
    }

    public override void Dash(Graphics g) {
        var points = new Point[this.mas_points.Length - 1];
        for (int i = 0 ; i < this.mas_points.Length - 1 ; i++) {
            points[i].X = this.mas_points[i + 1].X - UxCanvasWindow.ScrollX;
            points[i].Y = this.mas_points[i + 1].Y - UxCanvasWindow.ScrollY;
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

            double distance = Math.Abs((end.Y - start.Y) * p.X -
                                        (end.X - start.X) * p.Y +
                                        end.X * start.Y -
                                        end.Y * start.X) /
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
public class TxtBox(Point point1, Point point2, Color line_color, Color back_color, int px, bool back_TF, Point[] mas_points, Font font, string text) : Figure(point1, point2, line_color, back_color, px, back_TF, mas_points, font, text) {
    public override void Draw(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.ScrollX;
            maxx = this.point1.X - UxCanvasWindow.ScrollX;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.ScrollY;
            maxy = this.point1.Y - UxCanvasWindow.ScrollY;
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
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.ScrollX;
            maxx = this.point1.X - UxCanvasWindow.ScrollX;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.ScrollY;
            maxy = this.point1.Y - UxCanvasWindow.ScrollY;
        }

        var penwhite = new Pen(Color.White, 1);
        var r = Rectangle.FromLTRB(minx, miny, maxx, maxy);
        g.DrawRectangle(penwhite, r);
    }

    public override void Dash(Graphics g) {
        int minx = this.point1.X - UxCanvasWindow.ScrollX;
        int miny = this.point1.Y - UxCanvasWindow.ScrollY;
        int maxx = this.point2.X - UxCanvasWindow.ScrollX;
        int maxy = this.point2.Y - UxCanvasWindow.ScrollY;
        if (minx > maxx) {
            minx = this.point2.X - UxCanvasWindow.ScrollX;
            maxx = this.point1.X - UxCanvasWindow.ScrollX;
        }

        if (miny > maxy) {
            miny = this.point2.Y - UxCanvasWindow.ScrollY;
            maxy = this.point1.Y - UxCanvasWindow.ScrollY;
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
