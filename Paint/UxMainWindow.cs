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
using System.Timers;

namespace Paint
{
    public partial class UxMainWindow : Form {
        public static System.Timers.Timer aTimer;
        public static Color line_color = Color.Black;
        public static Color back_color = Color.White;
        public static bool back_TF2 = false;
        public static int Heig;
        public static int Wid;
        public static int type_figure = 1;
        public Button button1;
        public ColorDialog colorDialog1;
        public ColorDialog colorDialog2;
        public static Font text_font = new Font("Times New Roman", 12.0f);
        private bool isSelectionMode = false;


        public UxMainWindow() {
            InitializeComponent();
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        public static int setWidth() {
            return Wid;
        }
        public static int setHeigh() {
            return Heig;
        }

        public static void saveFile(UxCanvasWindow f) {

            string fileName;
            var f2 = f;
            List<Figure> array;

            BinaryFormatter formatter = new BinaryFormatter();

            if (f2.fileName == null) {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                saveFileDialog1.Filter = "Графический редактор (*.png)|*.png|All files(*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    fileName = saveFileDialog1.FileName;
                    f2.fileName = fileName;
                    array = f2.array;
                    var siz = f2.Sz;
                    Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    {
                        formatter.Serialize(stream, array);
                        formatter.Serialize(stream, siz);
                    }
                    stream.Close();
                    f2.flag3 = false;
                }
            } else {
                fileName = f2.fileName;

                array = f2.array;
                var siz = f2.Sz;
                Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                {
                    formatter.Serialize(stream, array);
                    formatter.Serialize(stream, siz);
                }
                f2.Text = Path.GetFileName(fileName);
                stream.Close();
                f2.flag3 = false;
            }
        }

        private void MainWindowMouseDown(object sender, MouseEventArgs e) {
            Graphics g = CreateGraphics();

            if (e.Button == MouseButtons.Left) {
                string s = e.Location.ToString();

                g.DrawString(s, new Font("Times New Roman", 8),
                new SolidBrush(Color.Black), new Point(e.X, e.Y));
            }
            if (e.Button == MouseButtons.Right) {
                string s = "Hello";
                g.DrawString(s, new Font("Times New Roman", 8),
                new SolidBrush(Color.Black), new Point(e.X, e.Y));
            }
            if (e.Button == MouseButtons.Middle) {
                MessageBox.Show("Вы уверены что хотите удалить текст?", "Удаление");
                g.Clear(Color.White);
            }
        }

        private void dfdfToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void MainWindowLoad(object sender, EventArgs e) {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void NewFileToolStripMenuItemClick(object sender, EventArgs e) {
            if (Wid > 0 && Heig > 0) {
                UxCanvasWindow f2 = new UxCanvasWindow();
                f2.MdiParent = this;
                f2.Text = "Рисунок " + this.MdiChildren.Length.ToString();
                f2.CursorMoved += Form2_CursorMoved;
                f2.FormActivated += Form2_FormActivated;
                f2.Show();
            } else {
                UxCreateCanvas sizeDialog = new UxCreateCanvas();
                sizeDialog.ShowDialog(this);
                Wid = int.Parse(UxCreateCanvas.getSizeWidth());
                Heig = int.Parse(UxCreateCanvas.getSizeHeight());

                if (Wid > 0 && Heig > 0) {
                    UxCanvasWindow f2 = new UxCanvasWindow();
                    f2.MdiParent = this;
                    f2.Text = "Рисунок " + this.MdiChildren.Length.ToString();
                    f2.CursorMoved += Form2_CursorMoved;
                    f2.FormActivated += Form2_FormActivated;
                    f2.Show();
                }
            }
        }

        private void Form2_CursorMoved(int x, int y) {
            if (x <= UxCanvasWindow.windowsizex && y <= UxCanvasWindow.windowsizey) {
                MouseCords.Text = $"Положение курсора X: {x}, Y: {y}";
            } else if (x > UxCanvasWindow.windowsizex && y <= UxCanvasWindow.windowsizey) {
                MouseCords.Text = $"Положение курсора X: {UxCanvasWindow.windowsizex}, Y: {y}";
            } else if (x <= UxCanvasWindow.windowsizex && y > UxCanvasWindow.windowsizey) {
                MouseCords.Text = $"Положение курсора X: {x}, Y: {UxCanvasWindow.windowsizey}";
            } else if (x > UxCanvasWindow.windowsizex && y > UxCanvasWindow.windowsizey) {
                MouseCords.Text = $"Положение курсора X: {UxCanvasWindow.windowsizex}, Y: {UxCanvasWindow.windowsizey}";
            }
        }

        private void Form2_FormActivated(int x, int y) {
            CanvasSize.Text = $"Размер окна X: {x}, Y: {y}";
        }

        private void SaveFileToolStripMenuItemClick(object sender, EventArgs e) {
            saveFile((UxCanvasWindow)this.ActiveMdiChild);
        }

        public void SaveFileAsToolStripMenuItemClick(object sender, EventArgs e) {
            var f2 = (UxCanvasWindow)this.ActiveMdiChild;
            f2.fileName = null;
            saveFile(f2);
        }

        private void OpenFileToolStripMenuItemClick(object sender, EventArgs e) {
            string fileName;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "Графический редактор (*.png)|*.png|All files(*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {

                    fileName = openFileDialog1.FileName;
                    BinaryFormatter formatter = new BinaryFormatter();
                    Stream stream2 = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    List<Figure> array = (List<Figure>)formatter.Deserialize(stream2);
                    Size siz = (Size)formatter.Deserialize(stream2);
                    var f2 = new UxCanvasWindow();
                    f2.MdiParent = this;
                    f2.fileName = fileName;
                    f2.Text = openFileDialog1.SafeFileName;
                    f2.Sz = siz;
                    foreach (Figure f in array) {
                        f2.array.Add(f);
                    }
                    f2.CursorMoved += Form2_CursorMoved;
                    f2.FormActivated += Form2_FormActivated;
                    f2.Show();
                    stream2.Close();

                } catch (Exception ex) {
                    MessageBox.Show("Error. " + ex.Message);
                }
            }
        }

        public bool checkOpenWindows() {
            if ((UxCanvasWindow)this.ActiveMdiChild == null) {
                return false;
            } else {
                return true;
            }
        }


        private void FileToolStripMenuItemClick(object sender, EventArgs e) {
            this.SaveFileToolStripMenuItem.Enabled = checkOpenWindows();
            this.SaveFileAsToolStripMenuItem.Enabled = checkOpenWindows();
        }


        private void толщинаЛинииToolStripMenuItem_Click(object sender, EventArgs e) {

            UxBrushSize f = new UxBrushSize();
            f.Text = "Изменение размера кисти";
            f.MdiParent = this;
            f.FormClosing += new FormClosingEventHandler(f3_FormClosing);
            f.Show();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e) {

        }

        private void pxToolStripMenuItem2_Click(object sender, EventArgs e) {

        }

        private void CanvasSizeToolStripMenuItemClick(object sender, EventArgs e) {
            UxCreateCanvas sizeDialog = new UxCreateCanvas();
            sizeDialog.ShowDialog(this);
            Wid = int.Parse(UxCreateCanvas.getSizeWidth());
            Heig = int.Parse(UxCreateCanvas.getSizeHeight());
        }

        private void заливкаToolStripMenuItem_Click(object sender, EventArgs e) {
            if (FillingToolStripMenuItem.Checked == true) {
                back_TF2 = true;
            } else {
                back_TF2 = false;
            }
        }



        private void прямоугольникToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            type_figure = 1;
            RectangleToolStripMenuItem.Checked = true;
            EllipseToolStripMenuItem.Checked = false;
            StraightLineToolStripMenuItem.Checked = false;
            CurveLineToolStripMenuItem.Checked = false;
            TextToolStripMenuItem.Checked = false;
            SelectionToolStripMenuItem.Checked = false;


            RectangleButton.Checked = true;
            EllipseButton.Checked = false;
            StraightLineButton.Checked = false;
            CurveLineButton.Checked = false;
            TextButton.Checked = false;
            SelectionButton.Checked = false;

            isSelectionMode = false;
            var activeForm = this.ActiveMdiChild as UxCanvasWindow;
            if (activeForm != null) {
                activeForm.isSelectionMode = isSelectionMode;
            }

        }

        private void эллипсToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            type_figure = 2;
            RectangleToolStripMenuItem.Checked = false;
            EllipseToolStripMenuItem.Checked = true;
            StraightLineToolStripMenuItem.Checked = false;
            CurveLineToolStripMenuItem.Checked = false;
            TextToolStripMenuItem.Checked = false;
            SelectionToolStripMenuItem.Checked = false;


            RectangleButton.Checked = false;
            EllipseButton.Checked = true;
            StraightLineButton.Checked = false;
            CurveLineButton.Checked = false;
            TextButton.Checked = false;
            SelectionButton.Checked = false;

            isSelectionMode = false;
            var activeForm = this.ActiveMdiChild as UxCanvasWindow;
            if (activeForm != null) {
                activeForm.isSelectionMode = isSelectionMode;
            }


        }

        private void прямаяЛинияToolStripMenuItem_CheckStateChanged(object sender, EventArgs e) {
            type_figure = 3;
            RectangleToolStripMenuItem.Checked = false;
            EllipseToolStripMenuItem.Checked = false;
            StraightLineToolStripMenuItem.Checked = true;
            CurveLineToolStripMenuItem.Checked = false;
            TextToolStripMenuItem.Checked = false;
            SelectionToolStripMenuItem.Checked = false;


            RectangleButton.Checked = false;
            EllipseButton.Checked = false;
            StraightLineButton.Checked = true;
            CurveLineButton.Checked = false;
            TextButton.Checked = false;
            SelectionButton.Checked = false;

            isSelectionMode = false;
            var activeForm = this.ActiveMdiChild as UxCanvasWindow;
            if (activeForm != null) {
                activeForm.isSelectionMode = isSelectionMode;
            }

        }

        private void произвольнаяЛинияToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            type_figure = 4;
            RectangleToolStripMenuItem.Checked = false;
            EllipseToolStripMenuItem.Checked = false;
            StraightLineToolStripMenuItem.Checked = false;
            CurveLineToolStripMenuItem.Checked = true;
            TextToolStripMenuItem.Checked = false;
            SelectionToolStripMenuItem.Checked = false;


            RectangleButton.Checked = false;
            EllipseButton.Checked = false;
            StraightLineButton.Checked = false;
            CurveLineButton.Checked = true;
            TextButton.Checked = false;
            SelectionButton.Checked = false;

            isSelectionMode = false;
            var activeForm = this.ActiveMdiChild as UxCanvasWindow;
            if (activeForm != null) {
                activeForm.isSelectionMode = isSelectionMode;
            }
        }


        private void FillingColorToolStripMenuItemClick(object sender, EventArgs e) {
            StatusStrip.Invalidate();
            colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                цветToolStripMenuItem.BackColor = colorDialog1.Color;
            }
            back_color = colorDialog1.Color;

            Graphics g = StatusStrip.CreateGraphics();
            Pen RectColorPen = new Pen(back_color, 1);
            Brush brush = new SolidBrush(back_color);
            Rectangle r = new Rectangle(this.Width / 10 + this.Width / 20, 0, this.Width / 20, this.Height);
            g.FillRectangle(brush, r);
            g.DrawRectangle(RectColorPen, r);
        }

        private void PenColorToolStripMenuItemClick(object sender, EventArgs e) {
            StatusStrip.Invalidate();
            colorDialog2 = new ColorDialog();
            if (colorDialog2.ShowDialog() == DialogResult.OK) {
                цветToolStripMenuItem.BackColor = colorDialog2.Color;
            }
            line_color = colorDialog2.Color;

            Graphics g = StatusStrip.CreateGraphics();
            Brush brush = new SolidBrush(line_color);
            Pen RectColorPen = new Pen(line_color, 1);
            Rectangle r = new Rectangle(this.Width / 10, 0, this.Width / 20, this.Height);
            g.FillRectangle(brush, r);
            g.DrawRectangle(RectColorPen, r);
        }

        private void statusBar1_DrawItem(object sender, DrawItemEventArgs e) {
            Graphics g = StatusStrip.CreateGraphics();
            Pen RectColorPen = new Pen(line_color, 1);
            Brush brush = new SolidBrush(line_color);
            Rectangle r = new Rectangle(this.Width / 10, 0, this.Width / 20, this.Height);
            g.FillRectangle(brush, r);
            g.DrawRectangle(RectColorPen, r);

            RectColorPen = new Pen(back_color, 1);
            brush = new SolidBrush(back_color);
            r = new Rectangle(this.Width / 10 + this.Width / 20, 0, this.Width / 20, this.Height);
            g.FillRectangle(brush, r);
            g.DrawRectangle(RectColorPen, r);

            PenSize.Text = "Размер пера - " + UxBrushSize.pix;
        }

        void f3_FormClosing(object sender, FormClosingEventArgs e) {
            StatusStrip.Invalidate();
            PenSize.Text = "Размер пера - " + UxBrushSize.pix;
        }

        private void MainWindowResizeBegin(object sender, EventArgs e) {
            StatusStrip.Invalidate();
        }

        private void MainWindowResize(object sender, EventArgs e) {
            if (TextToolStripMenuItem.Checked) {
                PenSize.Width = this.Width / 10;
                PenColor.Width = this.Width / 20;
                FillingColor.Width = this.Width / 20;
                MouseCords.Width = this.Width / 5;
                CanvasSize.Width = this.Width / 5;
                FontName.Width = this.Width / 5;
                FontSize.Width = this.Width / 5;
            } else {
                PenSize.Width = this.Width / 10;
                PenColor.Width = this.Width / 20;
                FillingColor.Width = this.Width / 20;
                MouseCords.Width = this.Width / 25 * 10;
                CanvasSize.Width = this.Width / 25 * 10;
            }

            Graphics g = StatusStrip.CreateGraphics();
            Pen RectColorPen = new Pen(line_color, 1);
            Brush brush = new SolidBrush(line_color);
            Rectangle r = new Rectangle(this.Width / 10, 0, this.Width / 20, this.Height);
            g.FillRectangle(brush, r);
            g.DrawRectangle(RectColorPen, r);

            RectColorPen = new Pen(back_color, 1);
            brush = new SolidBrush(back_color);
            r = new Rectangle(this.Width / 10 + this.Width / 20, 0, this.Width / 20, this.Height);
            g.FillRectangle(brush, r);
            g.DrawRectangle(RectColorPen, r);
        }

        private void MainWindowResizeEnd(object sender, EventArgs e) {
            if (TextToolStripMenuItem.Checked == true) {
                PenSize.Width = this.Width / 10;
                PenColor.Width = this.Width / 20;
                FillingColor.Width = this.Width / 20;
                MouseCords.Width = this.Width / 5;
                CanvasSize.Width = this.Width / 5;
                FontName.Width = this.Width / 5;
                FontSize.Width = this.Width / 5;
            }
            Graphics g = StatusStrip.CreateGraphics();
            Pen RectColorPen = new Pen(line_color, 1);
            Brush brush = new SolidBrush(line_color);
            Rectangle r = new Rectangle(this.Width / 10, 0, this.Width / 20, this.Height);
            g.FillRectangle(brush, r);
            g.DrawRectangle(RectColorPen, r);

            RectColorPen = new Pen(back_color, 1);
            brush = new SolidBrush(back_color);
            r = new Rectangle(this.Width / 10 + this.Width / 20, 0, this.Width / 20, this.Height);
            g.FillRectangle(brush, r);
            g.DrawRectangle(RectColorPen, r);
        }

        private void NewFileButtonClick(object sender, EventArgs e) {
            NewFileToolStripMenuItemClick(sender, e);
        }

        private void SaveFileButtonClick(object sender, EventArgs e) {
            SaveFileToolStripMenuItemClick(sender, e);
        }

        private void OpenFileButtonClick(object sender, EventArgs e) {
            OpenFileToolStripMenuItemClick(sender, e);
        }

        private void PenSizeButtonClick(object sender, EventArgs e) {
            толщинаЛинииToolStripMenuItem_Click(sender, e);
        }

        private void PenColorButtonClick(object sender, EventArgs e) {
            PenColorToolStripMenuItemClick(sender, e);
        }

        private void FillingColorButtonClick(object sender, EventArgs e) {
            FillingColorToolStripMenuItemClick(sender, e);
        }

        private void CanvasSizeButtonClick(object sender, EventArgs e) {
            CanvasSizeToolStripMenuItemClick(sender, e);
        }

        private void RectangleButtonClick(object sender, EventArgs e) {
            прямоугольникToolStripMenuItem_CheckedChanged(sender, e);
            if (RectangleToolStripMenuItem.Checked == true) {
                RectangleButton.Checked = true;
                EllipseButton.Checked = false;
                StraightLineButton.Checked = false;
                CurveLineButton.Checked = false;
                TextButton.Checked = false;
                SelectionButton.Checked = false;

                isSelectionMode = false;
                var activeForm = this.ActiveMdiChild as UxCanvasWindow;
                if (activeForm != null) {
                    activeForm.isSelectionMode = isSelectionMode;
                }
            }
        }

        private void EllipseButtonClick(object sender, EventArgs e) {
            эллипсToolStripMenuItem_CheckedChanged(sender, e);
            if (EllipseToolStripMenuItem.Checked == true) {
                RectangleButton.Checked = false;
                EllipseButton.Checked = true;
                StraightLineButton.Checked = false;
                CurveLineButton.Checked = false;
                TextButton.Checked = false;
                SelectionButton.Checked = false;

                isSelectionMode = false;
                var activeForm = this.ActiveMdiChild as UxCanvasWindow;
                if (activeForm != null) {
                    activeForm.isSelectionMode = isSelectionMode;
                }
            }
        }

        private void StraightLineButtonClick(object sender, EventArgs e) {
            прямаяЛинияToolStripMenuItem_CheckStateChanged(sender, e);
            if (StraightLineToolStripMenuItem.Checked == true) {
                RectangleButton.Checked = false;
                EllipseButton.Checked = false;
                StraightLineButton.Checked = true;
                CurveLineButton.Checked = false;
                TextButton.Checked = false;
                SelectionButton.Checked = false;

                isSelectionMode = false;
                var activeForm = this.ActiveMdiChild as UxCanvasWindow;
                if (activeForm != null) {
                    activeForm.isSelectionMode = isSelectionMode;
                }
            }
        }

        private void CurveLineButtonClick(object sender, EventArgs e) {
            произвольнаяЛинияToolStripMenuItem_CheckedChanged(sender, e);
            if (CurveLineToolStripMenuItem.Checked == true) {
                RectangleButton.Checked = false;
                EllipseButton.Checked = false;
                StraightLineButton.Checked = false;
                CurveLineButton.Checked = true;
                TextButton.Checked = false;
                SelectionButton.Checked = false;

                isSelectionMode = false;
                var activeForm = this.ActiveMdiChild as UxCanvasWindow;
                if (activeForm != null) {
                    activeForm.isSelectionMode = isSelectionMode;
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void statusBar1_PanelClick(object sender, // TODO StatusBarPanel is no longer supported. Use ToolStripStatusLabel instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/windows-forms/5.0/winforms-deprecated-controls
        EventArgs e) {

        }

        private void TextButtonClick(object sender, EventArgs e) {
            текстToolStripMenuItem_Click(sender, e);
            if (TextToolStripMenuItem.Checked == true) {
                RectangleButton.Checked = false;
                EllipseButton.Checked = false;
                StraightLineButton.Checked = false;
                CurveLineButton.Checked = false;
                TextButton.Checked = true;
                SelectionButton.Checked = false;

                isSelectionMode = false;
                var activeForm = this.ActiveMdiChild as UxCanvasWindow;
                if (activeForm != null) {
                    activeForm.isSelectionMode = isSelectionMode;
                }

            }
        }

        private void текстToolStripMenuItem_Click(object sender, EventArgs e) {
            type_figure = 5;
            RectangleToolStripMenuItem.Checked = false;
            EllipseToolStripMenuItem.Checked = false;
            StraightLineToolStripMenuItem.Checked = false;
            CurveLineToolStripMenuItem.Checked = false;
            TextToolStripMenuItem.Checked = true;

            {
                StatusStrip.Invalidate();
                RectangleButton.Checked = false;
                EllipseButton.Checked = false;
                StraightLineButton.Checked = false;
                CurveLineButton.Checked = false;
                TextButton.Checked = true;
                FontName.Text = Convert.ToString(text_font.Name);
                FontSize.Text = Convert.ToString(text_font.Size);
                PenSize.Width = this.Width / 10;
                PenColor.Width = this.Width / 20;
                FillingColor.Width = this.Width / 20;
                MouseCords.Width = this.Width / 5;
                CanvasSize.Width = this.Width / 5;
                FontName.Width = this.Width / 5;
                FontSize.Width = this.Width / 5;
            }

            RectangleButton.Checked = false;
            EllipseButton.Checked = false;
            StraightLineButton.Checked = false;
            CurveLineButton.Checked = false;
            TextButton.Checked = true;
            SelectionButton.Checked = false;
        }

        private void выборШрифтаToolStripMenuItem_Click(object sender, EventArgs e) {
            StatusStrip.Invalidate();
            FontDialog.ShowDialog();
            if (FontDialog.Font != text_font) {
                text_font = FontDialog.Font;
                FontName.Text = Convert.ToString(text_font.Name);
                FontSize.Text = Convert.ToString(text_font.Size);
            }
        }

        private void FontButtonClick(object sender, EventArgs e) {
            выборШрифтаToolStripMenuItem_Click(sender, e);
        }

        private void режимВыделенияToolStripMenuItem_Click(object sender, EventArgs e) {
            SelectionModeSetter();

        }
        private void SelectionModeSetter() {
            type_figure = 6;

            RectangleButton.Checked = false;
            EllipseButton.Checked = false;
            StraightLineButton.Checked = false;
            CurveLineButton.Checked = false;
            TextButton.Checked = false;
            SelectionButton.Checked = true;

            RectangleToolStripMenuItem.Checked = false;
            EllipseToolStripMenuItem.Checked = false;
            StraightLineToolStripMenuItem.Checked = false;
            CurveLineToolStripMenuItem.Checked = false;
            TextToolStripMenuItem.Checked = false;
            SelectionToolStripMenuItem.Checked = true;

            isSelectionMode = true;
            var activeForm = this.ActiveMdiChild as UxCanvasWindow;
            if (activeForm != null) {
                activeForm.isSelectionMode = isSelectionMode;
            }
        }

        private void SelectionButtonClick(object sender, EventArgs e) {
            SelectionModeSetter();
        }
    }
}
