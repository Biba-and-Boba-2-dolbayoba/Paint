
namespace Paint
{
    partial class UxMainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UxMainWindow));
            this.MenuStrip = new MenuStrip();
            this.FileToolStripMenuItem = new ToolStripMenuItem();
            this.NewFileToolStripMenuItem = new ToolStripMenuItem();
            this.OpenFileToolStripMenuItem = new ToolStripMenuItem();
            this.SaveFileToolStripMenuItem = new ToolStripMenuItem();
            this.SaveFileAsToolStripMenuItem = new ToolStripMenuItem();
            this.WindowToolStripMenuItem = new ToolStripMenuItem();
            this.CanvasSizeToolStripMenuItem = new ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new ToolStripMenuItem();
            this.PenColorToolStripMenuItem = new ToolStripMenuItem();
            this.FillingColorToolStripMenuItem = new ToolStripMenuItem();
            this.PenSizeToolStripMenuItem = new ToolStripMenuItem();
            this.FigureToolStripMenuItem = new ToolStripMenuItem();
            this.RectangleToolStripMenuItem = new ToolStripMenuItem();
            this.EllipseToolStripMenuItem = new ToolStripMenuItem();
            this.StraightLineToolStripMenuItem = new ToolStripMenuItem();
            this.CurveLineToolStripMenuItem = new ToolStripMenuItem();
            this.FillingToolStripMenuItem = new ToolStripMenuItem();
            this.TextToolStripMenuItem = new ToolStripMenuItem();
            this.FontToolStripMenuItem = new ToolStripMenuItem();
            this.SelectionToolStripMenuItem = new ToolStripMenuItem();
            this.StatusStrip = new StatusStrip();
            this.PenSize = new ToolStripStatusLabel();
            this.PenColor = new ToolStripStatusLabel();
            this.FillingColor = new ToolStripStatusLabel();
            this.MouseCords = new ToolStripStatusLabel();
            this.CanvasSize = new ToolStripStatusLabel();
            this.FontName = new ToolStripStatusLabel();
            this.FontSize = new ToolStripStatusLabel();
            this.ToolStrip = new ToolStrip();
            this.NewFileButton = new ToolStripButton();
            this.SaveFileButton = new ToolStripButton();
            this.OpenFileButton = new ToolStripButton();
            this.PenSizeButton = new ToolStripButton();
            this.PenColorButton = new ToolStripButton();
            this.FillingColorButton = new ToolStripButton();
            this.CanvasSizeButton = new ToolStripButton();
            this.RectangleButton = new ToolStripButton();
            this.EllipseButton = new ToolStripButton();
            this.StraightLineButton = new ToolStripButton();
            this.CurveLineButton = new ToolStripButton();
            this.TextButton = new ToolStripButton();
            this.FontButton = new ToolStripButton();
            this.SelectionButton = new ToolStripButton();
            this.FontDialog = new FontDialog();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new Size(24, 24);
            this.MenuStrip.Items.AddRange(new ToolStripItem[] { this.FileToolStripMenuItem, this.WindowToolStripMenuItem, this.SettingsToolStripMenuItem, this.FigureToolStripMenuItem, this.FontToolStripMenuItem, this.SelectionToolStripMenuItem });
            this.MenuStrip.Location = new Point(0, 0);
            this.MenuStrip.MdiWindowListItem = this.WindowToolStripMenuItem;
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new Padding(10, 4, 0, 4);
            this.MenuStrip.Size = new Size(1670, 37);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.NewFileToolStripMenuItem, this.OpenFileToolStripMenuItem, this.SaveFileToolStripMenuItem, this.SaveFileAsToolStripMenuItem });
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new Size(69, 29);
            this.FileToolStripMenuItem.Text = "Файл";
            this.FileToolStripMenuItem.Click += this.FileToolStripMenuItemClick;
            // 
            // NewFileToolStripMenuItem
            // 
            this.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem";
            this.NewFileToolStripMenuItem.Size = new Size(244, 34);
            this.NewFileToolStripMenuItem.Text = "Новый";
            this.NewFileToolStripMenuItem.Click += this.NewFileToolStripMenuItemClick;
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new Size(244, 34);
            this.OpenFileToolStripMenuItem.Text = "Открыть";
            this.OpenFileToolStripMenuItem.Click += this.OpenFileToolStripMenuItemClick;
            // 
            // SaveFileToolStripMenuItem
            // 
            this.SaveFileToolStripMenuItem.Enabled = false;
            this.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            this.SaveFileToolStripMenuItem.Size = new Size(244, 34);
            this.SaveFileToolStripMenuItem.Text = "Сохранить";
            this.SaveFileToolStripMenuItem.Click += this.SaveFileToolStripMenuItemClick;
            // 
            // SaveFileAsToolStripMenuItem
            // 
            this.SaveFileAsToolStripMenuItem.Enabled = false;
            this.SaveFileAsToolStripMenuItem.Name = "SaveFileAsToolStripMenuItem";
            this.SaveFileAsToolStripMenuItem.Size = new Size(244, 34);
            this.SaveFileAsToolStripMenuItem.Text = "Сохранить как...";
            this.SaveFileAsToolStripMenuItem.Click += this.SaveFileAsToolStripMenuItemClick;
            // 
            // WindowToolStripMenuItem
            // 
            this.WindowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.CanvasSizeToolStripMenuItem });
            this.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            this.WindowToolStripMenuItem.Size = new Size(72, 29);
            this.WindowToolStripMenuItem.Text = "Окно";
            // 
            // CanvasSizeToolStripMenuItem
            // 
            this.CanvasSizeToolStripMenuItem.Name = "CanvasSizeToolStripMenuItem";
            this.CanvasSizeToolStripMenuItem.Size = new Size(347, 34);
            this.CanvasSizeToolStripMenuItem.Text = "Выбор размера новых окон";
            this.CanvasSizeToolStripMenuItem.Click += this.CanvasSizeToolStripMenuItemClick;
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.PenColorToolStripMenuItem, this.FillingColorToolStripMenuItem, this.PenSizeToolStripMenuItem });
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new Size(123, 29);
            this.SettingsToolStripMenuItem.Text = "Параметры";
            // 
            // PenColorToolStripMenuItem
            // 
            this.PenColorToolStripMenuItem.Name = "PenColorToolStripMenuItem";
            this.PenColorToolStripMenuItem.Size = new Size(241, 34);
            this.PenColorToolStripMenuItem.Text = "Цвет линии";
            this.PenColorToolStripMenuItem.Click += this.PenColorToolStripMenuItemClick;
            // 
            // FillingColorToolStripMenuItem
            // 
            this.FillingColorToolStripMenuItem.Name = "FillingColorToolStripMenuItem";
            this.FillingColorToolStripMenuItem.Size = new Size(241, 34);
            this.FillingColorToolStripMenuItem.Text = "Цвет фона";
            this.FillingColorToolStripMenuItem.Click += this.FillingColorToolStripMenuItemClick;
            // 
            // PenSizeToolStripMenuItem
            // 
            this.PenSizeToolStripMenuItem.Name = "PenSizeToolStripMenuItem";
            this.PenSizeToolStripMenuItem.Size = new Size(241, 34);
            this.PenSizeToolStripMenuItem.Text = "Толщина линии";
            this.PenSizeToolStripMenuItem.Click += this.PenSizeToolStripMenuItemClick;
            // 
            // FigureToolStripMenuItem
            // 
            this.FigureToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.RectangleToolStripMenuItem, this.EllipseToolStripMenuItem, this.StraightLineToolStripMenuItem, this.CurveLineToolStripMenuItem, this.FillingToolStripMenuItem, this.TextToolStripMenuItem });
            this.FigureToolStripMenuItem.Name = "FigureToolStripMenuItem";
            this.FigureToolStripMenuItem.Size = new Size(87, 29);
            this.FigureToolStripMenuItem.Text = "Фигура";
            // 
            // RectangleToolStripMenuItem
            // 
            this.RectangleToolStripMenuItem.Checked = true;
            this.RectangleToolStripMenuItem.CheckState = CheckState.Checked;
            this.RectangleToolStripMenuItem.Name = "RectangleToolStripMenuItem";
            this.RectangleToolStripMenuItem.Size = new Size(287, 34);
            this.RectangleToolStripMenuItem.Text = "Прямоугольник";
            this.RectangleToolStripMenuItem.Click += this.RectangleToolStripMenuItemClick;
            // 
            // EllipseToolStripMenuItem
            // 
            this.EllipseToolStripMenuItem.Name = "EllipseToolStripMenuItem";
            this.EllipseToolStripMenuItem.Size = new Size(287, 34);
            this.EllipseToolStripMenuItem.Text = "Эллипс";
            this.EllipseToolStripMenuItem.Click += this.EllipseToolStripMenuItemClick;
            // 
            // StraightLineToolStripMenuItem
            // 
            this.StraightLineToolStripMenuItem.Name = "StraightLineToolStripMenuItem";
            this.StraightLineToolStripMenuItem.Size = new Size(287, 34);
            this.StraightLineToolStripMenuItem.Text = "Прямая линия";
            this.StraightLineToolStripMenuItem.Click += this.StraightLineToolStripMenuItemClick;
            // 
            // CurveLineToolStripMenuItem
            // 
            this.CurveLineToolStripMenuItem.Name = "CurveLineToolStripMenuItem";
            this.CurveLineToolStripMenuItem.Size = new Size(287, 34);
            this.CurveLineToolStripMenuItem.Text = "Произвольная линия";
            this.CurveLineToolStripMenuItem.Click += this.CurveLineToolStripMenuItemClick;
            // 
            // FillingToolStripMenuItem
            // 
            this.FillingToolStripMenuItem.CheckOnClick = true;
            this.FillingToolStripMenuItem.Name = "FillingToolStripMenuItem";
            this.FillingToolStripMenuItem.Size = new Size(287, 34);
            this.FillingToolStripMenuItem.Text = "Заливка";
            this.FillingToolStripMenuItem.Click += this.FillingToolStripMenuItemClick;
            // 
            // TextToolStripMenuItem
            // 
            this.TextToolStripMenuItem.Name = "TextToolStripMenuItem";
            this.TextToolStripMenuItem.Size = new Size(287, 34);
            this.TextToolStripMenuItem.Text = "Текст";
            this.TextToolStripMenuItem.Click += this.TextToolStripMenuItemClick;
            // 
            // FontToolStripMenuItem
            // 
            this.FontToolStripMenuItem.Name = "FontToolStripMenuItem";
            this.FontToolStripMenuItem.Size = new Size(85, 29);
            this.FontToolStripMenuItem.Text = "Шрифт";
            this.FontToolStripMenuItem.Click += this.FontToolStripMenuItemClick;
            // 
            // SelectionToolStripMenuItem
            // 
            this.SelectionToolStripMenuItem.Name = "SelectionToolStripMenuItem";
            this.SelectionToolStripMenuItem.Size = new Size(177, 29);
            this.SelectionToolStripMenuItem.Text = "Режим выделения";
            // 
            // StatusStrip
            // 
            this.StatusStrip.GripMargin = new Padding(20);
            this.StatusStrip.ImageScalingSize = new Size(24, 24);
            this.StatusStrip.Items.AddRange(new ToolStripItem[] { this.PenSize, this.PenColor, this.FillingColor, this.MouseCords, this.CanvasSize, this.FontName, this.FontSize });
            this.StatusStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
            this.StatusStrip.Location = new Point(0, 1337);
            this.StatusStrip.Margin = new Padding(15);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new Padding(2, 0, 23, 0);
            this.StatusStrip.Size = new Size(1670, 32);
            this.StatusStrip.TabIndex = 3;
            // 
            // PenSize
            // 
            this.PenSize.Name = "PenSize";
            this.PenSize.Size = new Size(128, 25);
            this.PenSize.Text = "Размер пера -";
            this.PenSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PenColor
            // 
            this.PenColor.AutoSize = false;
            this.PenColor.Margin = new Padding(20, 4, 0, 3);
            this.PenColor.Name = "PenColor";
            this.PenColor.Size = new Size(150, 25);
            this.PenColor.Text = "Цвет пера";
            this.PenColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FillingColor
            // 
            this.FillingColor.AutoSize = false;
            this.FillingColor.Name = "FillingColor";
            this.FillingColor.Size = new Size(150, 25);
            this.FillingColor.Text = "Цвет заливки";
            this.FillingColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MouseCords
            // 
            this.MouseCords.Name = "MouseCords";
            this.MouseCords.Size = new Size(174, 25);
            this.MouseCords.Text = "Координаты мыши ";
            // 
            // CanvasSize
            // 
            this.CanvasSize.Name = "CanvasSize";
            this.CanvasSize.Size = new Size(129, 25);
            this.CanvasSize.Text = "Размер холста";
            // 
            // FontName
            // 
            this.FontName.Name = "FontName";
            this.FontName.Size = new Size(159, 25);
            this.FontName.Text = "Times New Roman";
            // 
            // FontSize
            // 
            this.FontSize.Name = "FontSize";
            this.FontSize.Size = new Size(62, 25);
            this.FontSize.Text = "Size:   ";
            // 
            // ToolStrip
            // 
            this.ToolStrip.ImageScalingSize = new Size(24, 24);
            this.ToolStrip.Items.AddRange(new ToolStripItem[] { this.NewFileButton, this.SaveFileButton, this.OpenFileButton, this.PenSizeButton, this.PenColorButton, this.FillingColorButton, this.CanvasSizeButton, this.RectangleButton, this.EllipseButton, this.StraightLineButton, this.CurveLineButton, this.TextButton, this.FontButton, this.SelectionButton });
            this.ToolStrip.Location = new Point(0, 37);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new Padding(0, 0, 3, 0);
            this.ToolStrip.Size = new Size(1670, 33);
            this.ToolStrip.TabIndex = 5;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // NewFileButton
            // 
            this.NewFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.NewFileButton.Image = (Image)resources.GetObject("NewFileButton.Image");
            this.NewFileButton.ImageTransparentColor = Color.Magenta;
            this.NewFileButton.Name = "NewFileButton";
            this.NewFileButton.Size = new Size(34, 28);
            this.NewFileButton.Text = "Новый";
            this.NewFileButton.Click += this.NewFileButtonClick;
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.SaveFileButton.Image = (Image)resources.GetObject("SaveFileButton.Image");
            this.SaveFileButton.ImageTransparentColor = Color.Magenta;
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new Size(34, 28);
            this.SaveFileButton.Text = "Сохранить";
            this.SaveFileButton.Click += this.SaveFileButtonClick;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.OpenFileButton.Image = (Image)resources.GetObject("OpenFileButton.Image");
            this.OpenFileButton.ImageTransparentColor = Color.Magenta;
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new Size(34, 28);
            this.OpenFileButton.Text = "Открыть";
            this.OpenFileButton.Click += this.OpenFileButtonClick;
            // 
            // PenSizeButton
            // 
            this.PenSizeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.PenSizeButton.Image = (Image)resources.GetObject("PenSizeButton.Image");
            this.PenSizeButton.ImageTransparentColor = Color.Magenta;
            this.PenSizeButton.Name = "PenSizeButton";
            this.PenSizeButton.Size = new Size(34, 28);
            this.PenSizeButton.Text = "Размер пера";
            this.PenSizeButton.Click += this.PenSizeButtonClick;
            // 
            // PenColorButton
            // 
            this.PenColorButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.PenColorButton.Image = (Image)resources.GetObject("PenColorButton.Image");
            this.PenColorButton.ImageTransparentColor = Color.Magenta;
            this.PenColorButton.Name = "PenColorButton";
            this.PenColorButton.Size = new Size(34, 28);
            this.PenColorButton.Text = "Цвет пера";
            this.PenColorButton.Click += this.PenColorButtonClick;
            // 
            // FillingColorButton
            // 
            this.FillingColorButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.FillingColorButton.Image = (Image)resources.GetObject("FillingColorButton.Image");
            this.FillingColorButton.ImageTransparentColor = Color.Magenta;
            this.FillingColorButton.Name = "FillingColorButton";
            this.FillingColorButton.Size = new Size(34, 28);
            this.FillingColorButton.Text = "Цвет заливки";
            this.FillingColorButton.Click += this.FillingColorButtonClick;
            // 
            // CanvasSizeButton
            // 
            this.CanvasSizeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.CanvasSizeButton.Image = (Image)resources.GetObject("CanvasSizeButton.Image");
            this.CanvasSizeButton.ImageTransparentColor = Color.Magenta;
            this.CanvasSizeButton.Name = "CanvasSizeButton";
            this.CanvasSizeButton.Size = new Size(34, 28);
            this.CanvasSizeButton.Text = "Размер холста";
            this.CanvasSizeButton.Click += this.CanvasSizeButtonClick;
            // 
            // RectangleButton
            // 
            this.RectangleButton.Checked = true;
            this.RectangleButton.CheckState = CheckState.Checked;
            this.RectangleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.RectangleButton.Image = (Image)resources.GetObject("RectangleButton.Image");
            this.RectangleButton.ImageTransparentColor = Color.Magenta;
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new Size(34, 28);
            this.RectangleButton.Text = "Прямоугольник";
            this.RectangleButton.Click += this.RectangleButtonClick;
            // 
            // EllipseButton
            // 
            this.EllipseButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.EllipseButton.Image = (Image)resources.GetObject("EllipseButton.Image");
            this.EllipseButton.ImageTransparentColor = Color.Magenta;
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new Size(34, 28);
            this.EllipseButton.Text = "Элипс";
            this.EllipseButton.Click += this.EllipseButtonClick;
            // 
            // StraightLineButton
            // 
            this.StraightLineButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.StraightLineButton.Image = (Image)resources.GetObject("StraightLineButton.Image");
            this.StraightLineButton.ImageTransparentColor = Color.Magenta;
            this.StraightLineButton.Name = "StraightLineButton";
            this.StraightLineButton.Size = new Size(34, 28);
            this.StraightLineButton.Text = "Прямая линия";
            this.StraightLineButton.Click += this.StraightLineButtonClick;
            // 
            // CurveLineButton
            // 
            this.CurveLineButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.CurveLineButton.Image = (Image)resources.GetObject("CurveLineButton.Image");
            this.CurveLineButton.ImageTransparentColor = Color.Magenta;
            this.CurveLineButton.Name = "CurveLineButton";
            this.CurveLineButton.Size = new Size(34, 28);
            this.CurveLineButton.Text = "Кривая линия";
            this.CurveLineButton.Click += this.CurveLineButtonClick;
            // 
            // TextButton
            // 
            this.TextButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.TextButton.Image = (Image)resources.GetObject("TextButton.Image");
            this.TextButton.ImageTransparentColor = Color.Magenta;
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new Size(34, 28);
            this.TextButton.Text = "Текст";
            this.TextButton.Click += this.TextButtonClick;
            // 
            // FontButton
            // 
            this.FontButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.FontButton.Image = (Image)resources.GetObject("FontButton.Image");
            this.FontButton.ImageTransparentColor = Color.Magenta;
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new Size(34, 28);
            this.FontButton.Text = "Шрифт";
            this.FontButton.Click += this.FontButtonClick;
            // 
            // SelectionButton
            // 
            this.SelectionButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.SelectionButton.Image = (Image)resources.GetObject("SelectionButton.Image");
            this.SelectionButton.ImageTransparentColor = Color.Magenta;
            this.SelectionButton.Name = "SelectionButton";
            this.SelectionButton.Size = new Size(34, 28);
            this.SelectionButton.Text = "Выделение";
            this.SelectionButton.Click += this.SelectionButtonClick;
            // 
            // UxMainWindow
            // 
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1670, 1369);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.IsMdiContainer = true;
            this.Margin = new Padding(5, 6, 5, 6);
            this.MaximumSize = new Size(1692, 1425);
            this.MinimumSize = new Size(1692, 1425);
            this.Name = "UxMainWindow";
            this.Text = "Paint";
            this.Load += this.MainWindowLoad;
            this.ResizeBegin += this.MainWindowResizeBegin;
            this.ResizeEnd += this.MainWindowResizeEnd;
            this.MouseDown += this.MainWindowMouseDown;
            this.Resize += this.MainWindowResize;
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem WindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PenColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PenSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem черныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem красныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FillingColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CanvasSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FigureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StraightLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CurveLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FillingToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel PenColor;
        private System.Windows.Forms.ToolStripStatusLabel FillingColor;
        private System.Windows.Forms.ToolStripStatusLabel CanvasSize;
        private System.Windows.Forms.ToolStripStatusLabel PenSize;
		private System.Windows.Forms.ToolStripStatusLabel MouseCords;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton NewFileButton;
        private System.Windows.Forms.ToolStripButton SaveFileButton;
        private System.Windows.Forms.ToolStripButton OpenFileButton;
        private System.Windows.Forms.ToolStripButton PenSizeButton;
        private System.Windows.Forms.ToolStripButton PenColorButton;
        private System.Windows.Forms.ToolStripButton FillingColorButton;
        private System.Windows.Forms.ToolStripButton CanvasSizeButton;
        private System.Windows.Forms.ToolStripButton RectangleButton;
        private System.Windows.Forms.ToolStripButton EllipseButton;
        private System.Windows.Forms.ToolStripButton StraightLineButton;
        private System.Windows.Forms.ToolStripButton CurveLineButton;
        private System.Windows.Forms.ToolStripButton TextButton;
        private System.Windows.Forms.ToolStripMenuItem TextToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel FontName;
        private System.Windows.Forms.ToolStripStatusLabel FontSize;
        private System.Windows.Forms.ToolStripMenuItem FontToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton FontButton;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.ToolStripMenuItem SelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SelectionButton;
    }
}
