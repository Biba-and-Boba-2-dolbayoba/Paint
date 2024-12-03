
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
            this.SettingsToolStripMenuItem = new ToolStripMenuItem();
            this.BrushColorToolStripMenuItem = new ToolStripMenuItem();
            this.BrushSizeToolStripMenuItem = new ToolStripMenuItem();
            this.FillingColorToolStripMenuItem = new ToolStripMenuItem();
            this.FigureToolStripMenuItem = new ToolStripMenuItem();
            this.RectangleToolStripMenuItem = new ToolStripMenuItem();
            this.EllipseToolStripMenuItem = new ToolStripMenuItem();
            this.StraightLineToolStripMenuItem = new ToolStripMenuItem();
            this.CurveLineToolStripMenuItem = new ToolStripMenuItem();
            this.TextToolStripMenuItem = new ToolStripMenuItem();
            this.FillingSeparator = new ToolStripSeparator();
            this.FillingToolStripMenuItem = new ToolStripMenuItem();
            this.FontToolStripMenuItem = new ToolStripMenuItem();
            this.SelectionToolStripMenuItem = new ToolStripMenuItem();
            this.StatusStrip = new StatusStrip();
            this.MouseCords = new ToolStripStatusLabel();
            this.CanvasSize = new ToolStripStatusLabel();
            this.FontName = new ToolStripStatusLabel();
            this.BrushSize = new ToolStripStatusLabel();
            this.FillingColor = new ToolStripStatusLabel();
            this.ToolStrip = new ToolStrip();
            this.NewFileButton = new ToolStripButton();
            this.SaveFileButton = new ToolStripButton();
            this.OpenFileButton = new ToolStripButton();
            this.CanvasSizeButton = new ToolStripButton();
            this.BrushGroupSeparator = new ToolStripSeparator();
            this.BrushDropDownButton = new ToolStripDropDownButton();
            this.BrushColorButton = new ToolStripMenuItem();
            this.BrushSizeButton = new ToolStripMenuItem();
            this.FillingDropDownButton = new ToolStripDropDownButton();
            this.FillingButton = new ToolStripMenuItem();
            this.FillingColorButton = new ToolStripMenuItem();
            this.FuguresGroupSeparator = new ToolStripSeparator();
            this.RectangleButton = new ToolStripButton();
            this.EllipseButton = new ToolStripButton();
            this.StraightLineButton = new ToolStripButton();
            this.CurveLineButton = new ToolStripButton();
            this.TextGroupSeparator = new ToolStripSeparator();
            this.TextButton = new ToolStripButton();
            this.FontButton = new ToolStripButton();
            this.SelectionGroupSeparator = new ToolStripSeparator();
            this.SelectionButton = new ToolStripButton();
            this.FontDialog = new FontDialog();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = Color.WhiteSmoke;
            this.MenuStrip.Items.AddRange(new ToolStripItem[] { this.FileToolStripMenuItem, this.WindowToolStripMenuItem, this.SettingsToolStripMenuItem, this.FigureToolStripMenuItem, this.FontToolStripMenuItem, this.SelectionToolStripMenuItem });
            this.MenuStrip.Location = new Point(0, 0);
            this.MenuStrip.MdiWindowListItem = this.WindowToolStripMenuItem;
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new Padding(5, 0, 5, 0);
            this.MenuStrip.RenderMode = ToolStripRenderMode.Professional;
            this.MenuStrip.Size = new Size(1264, 24);
            this.MenuStrip.TabIndex = 1;
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.NewFileToolStripMenuItem, this.OpenFileToolStripMenuItem, this.SaveFileToolStripMenuItem, this.SaveFileAsToolStripMenuItem });
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new Size(48, 24);
            this.FileToolStripMenuItem.Text = "Файл";
            this.FileToolStripMenuItem.Click += this.FileToolButtonClick;
            // 
            // NewFileToolStripMenuItem
            // 
            this.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem";
            this.NewFileToolStripMenuItem.Size = new Size(163, 22);
            this.NewFileToolStripMenuItem.Text = "Новый";
            this.NewFileToolStripMenuItem.Click += this.NewFileButtonClick;
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new Size(163, 22);
            this.OpenFileToolStripMenuItem.Text = "Открыть";
            this.OpenFileToolStripMenuItem.Click += this.OpenFileButtonClick;
            // 
            // SaveFileToolStripMenuItem
            // 
            this.SaveFileToolStripMenuItem.Enabled = false;
            this.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem";
            this.SaveFileToolStripMenuItem.Size = new Size(163, 22);
            this.SaveFileToolStripMenuItem.Text = "Сохранить";
            this.SaveFileToolStripMenuItem.Click += this.SaveFileButtonClick;
            // 
            // SaveFileAsToolStripMenuItem
            // 
            this.SaveFileAsToolStripMenuItem.Enabled = false;
            this.SaveFileAsToolStripMenuItem.Name = "SaveFileAsToolStripMenuItem";
            this.SaveFileAsToolStripMenuItem.Size = new Size(163, 22);
            this.SaveFileAsToolStripMenuItem.Text = "Сохранить как...";
            this.SaveFileAsToolStripMenuItem.Click += this.SaveFileAsButtonClick;
            // 
            // WindowToolStripMenuItem
            // 
            this.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            this.WindowToolStripMenuItem.Size = new Size(48, 24);
            this.WindowToolStripMenuItem.Text = "Окно";
            this.WindowToolStripMenuItem.Click += this.CanvasSizeButtonClick;
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.BrushColorToolStripMenuItem, this.BrushSizeToolStripMenuItem, this.FillingColorToolStripMenuItem });
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new Size(83, 24);
            this.SettingsToolStripMenuItem.Text = "Параметры";
            // 
            // BrushColorToolStripMenuItem
            // 
            this.BrushColorToolStripMenuItem.Name = "BrushColorToolStripMenuItem";
            this.BrushColorToolStripMenuItem.Size = new Size(205, 22);
            this.BrushColorToolStripMenuItem.Text = "Изменить цвет кисти";
            this.BrushColorToolStripMenuItem.Click += this.BrushColorButtonClick;
            // 
            // BrushSizeToolStripMenuItem
            // 
            this.BrushSizeToolStripMenuItem.Name = "BrushSizeToolStripMenuItem";
            this.BrushSizeToolStripMenuItem.Size = new Size(205, 22);
            this.BrushSizeToolStripMenuItem.Text = "Изменить размер кисти";
            this.BrushSizeToolStripMenuItem.Click += this.BrushSizeButtonClick;
            // 
            // FillingColorToolStripMenuItem
            // 
            this.FillingColorToolStripMenuItem.Name = "FillingColorToolStripMenuItem";
            this.FillingColorToolStripMenuItem.Size = new Size(205, 22);
            this.FillingColorToolStripMenuItem.Text = "Изменить цвет заливки";
            this.FillingColorToolStripMenuItem.Click += this.FillingColorButtonClick;
            // 
            // FigureToolStripMenuItem
            // 
            this.FigureToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.RectangleToolStripMenuItem, this.EllipseToolStripMenuItem, this.StraightLineToolStripMenuItem, this.CurveLineToolStripMenuItem, this.TextToolStripMenuItem, this.FillingSeparator, this.FillingToolStripMenuItem });
            this.FigureToolStripMenuItem.Name = "FigureToolStripMenuItem";
            this.FigureToolStripMenuItem.Size = new Size(59, 24);
            this.FigureToolStripMenuItem.Text = "Фигура";
            // 
            // RectangleToolStripMenuItem
            // 
            this.RectangleToolStripMenuItem.Checked = true;
            this.RectangleToolStripMenuItem.CheckState = CheckState.Checked;
            this.RectangleToolStripMenuItem.Name = "RectangleToolStripMenuItem";
            this.RectangleToolStripMenuItem.Size = new Size(191, 22);
            this.RectangleToolStripMenuItem.Text = "Прямоугольник";
            this.RectangleToolStripMenuItem.Click += this.RectangleButtonClick;
            // 
            // EllipseToolStripMenuItem
            // 
            this.EllipseToolStripMenuItem.Name = "EllipseToolStripMenuItem";
            this.EllipseToolStripMenuItem.Size = new Size(191, 22);
            this.EllipseToolStripMenuItem.Text = "Эллипс";
            this.EllipseToolStripMenuItem.Click += this.EllipseButtonClick;
            // 
            // StraightLineToolStripMenuItem
            // 
            this.StraightLineToolStripMenuItem.Name = "StraightLineToolStripMenuItem";
            this.StraightLineToolStripMenuItem.Size = new Size(191, 22);
            this.StraightLineToolStripMenuItem.Text = "Прямая линия";
            this.StraightLineToolStripMenuItem.Click += this.StraightLineButtonClick;
            // 
            // CurveLineToolStripMenuItem
            // 
            this.CurveLineToolStripMenuItem.Name = "CurveLineToolStripMenuItem";
            this.CurveLineToolStripMenuItem.Size = new Size(191, 22);
            this.CurveLineToolStripMenuItem.Text = "Произвольная линия";
            this.CurveLineToolStripMenuItem.Click += this.CurveLineButtonClick;
            // 
            // TextToolStripMenuItem
            // 
            this.TextToolStripMenuItem.Name = "TextToolStripMenuItem";
            this.TextToolStripMenuItem.Size = new Size(191, 22);
            this.TextToolStripMenuItem.Text = "Текст";
            this.TextToolStripMenuItem.Click += this.TextButtonClick;
            // 
            // FillingSeparator
            // 
            this.FillingSeparator.Name = "FillingSeparator";
            this.FillingSeparator.Size = new Size(188, 6);
            // 
            // FillingToolStripMenuItem
            // 
            this.FillingToolStripMenuItem.CheckOnClick = true;
            this.FillingToolStripMenuItem.Name = "FillingToolStripMenuItem";
            this.FillingToolStripMenuItem.Size = new Size(191, 22);
            this.FillingToolStripMenuItem.Text = "Заливка";
            this.FillingToolStripMenuItem.Click += this.FillingButtonClick;
            // 
            // FontToolStripMenuItem
            // 
            this.FontToolStripMenuItem.Name = "FontToolStripMenuItem";
            this.FontToolStripMenuItem.Size = new Size(58, 24);
            this.FontToolStripMenuItem.Text = "Шрифт";
            this.FontToolStripMenuItem.Click += this.FontButtonClick;
            // 
            // SelectionToolStripMenuItem
            // 
            this.SelectionToolStripMenuItem.Name = "SelectionToolStripMenuItem";
            this.SelectionToolStripMenuItem.Size = new Size(120, 24);
            this.SelectionToolStripMenuItem.Text = "Режим выделения";
            this.SelectionToolStripMenuItem.Click += this.SelectionButtonClick;
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = Color.WhiteSmoke;
            this.StatusStrip.GripMargin = new Padding(0, 0, 0, 2);
            this.StatusStrip.Items.AddRange(new ToolStripItem[] { this.MouseCords, this.CanvasSize, this.FontName, this.BrushSize, this.FillingColor });
            this.StatusStrip.Location = new Point(0, 657);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new Padding(1, 0, 16, 0);
            this.StatusStrip.RenderMode = ToolStripRenderMode.Professional;
            this.StatusStrip.Size = new Size(1264, 24);
            this.StatusStrip.Stretch = false;
            this.StatusStrip.TabIndex = 3;
            // 
            // MouseCords
            // 
            this.MouseCords.AutoSize = false;
            this.MouseCords.Image = (Image)resources.GetObject("MouseCords.Image");
            this.MouseCords.ImageAlign = ContentAlignment.MiddleLeft;
            this.MouseCords.Margin = new Padding(0);
            this.MouseCords.Name = "MouseCords";
            this.MouseCords.Size = new Size(150, 24);
            this.MouseCords.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CanvasSize
            // 
            this.CanvasSize.AutoSize = false;
            this.CanvasSize.Image = (Image)resources.GetObject("CanvasSize.Image");
            this.CanvasSize.ImageAlign = ContentAlignment.MiddleLeft;
            this.CanvasSize.Margin = new Padding(0);
            this.CanvasSize.Name = "CanvasSize";
            this.CanvasSize.Size = new Size(150, 24);
            this.CanvasSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FontName
            // 
            this.FontName.AutoSize = false;
            this.FontName.Image = (Image)resources.GetObject("FontName.Image");
            this.FontName.ImageAlign = ContentAlignment.MiddleLeft;
            this.FontName.Margin = new Padding(0);
            this.FontName.Name = "FontName";
            this.FontName.Size = new Size(160, 24);
            this.FontName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BrushSize
            // 
            this.BrushSize.AutoSize = false;
            this.BrushSize.Image = (Image)resources.GetObject("BrushSize.Image");
            this.BrushSize.ImageAlign = ContentAlignment.MiddleLeft;
            this.BrushSize.Margin = new Padding(0);
            this.BrushSize.Name = "BrushSize";
            this.BrushSize.Size = new Size(160, 24);
            this.BrushSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FillingColor
            // 
            this.FillingColor.AutoSize = false;
            this.FillingColor.Image = (Image)resources.GetObject("FillingColor.Image");
            this.FillingColor.ImageAlign = ContentAlignment.MiddleLeft;
            this.FillingColor.Margin = new Padding(0);
            this.FillingColor.Name = "FillingColor";
            this.FillingColor.Size = new Size(160, 24);
            this.FillingColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = Color.WhiteSmoke;
            this.ToolStrip.CanOverflow = false;
            this.ToolStrip.GripMargin = new Padding(0);
            this.ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new Size(24, 24);
            this.ToolStrip.Items.AddRange(new ToolStripItem[] { this.NewFileButton, this.SaveFileButton, this.OpenFileButton, this.CanvasSizeButton, this.BrushGroupSeparator, this.BrushDropDownButton, this.FillingDropDownButton, this.FuguresGroupSeparator, this.RectangleButton, this.EllipseButton, this.StraightLineButton, this.CurveLineButton, this.TextGroupSeparator, this.TextButton, this.FontButton, this.SelectionGroupSeparator, this.SelectionButton });
            this.ToolStrip.Location = new Point(0, 24);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new Padding(10, 0, 10, 0);
            this.ToolStrip.RenderMode = ToolStripRenderMode.Professional;
            this.ToolStrip.Size = new Size(1264, 31);
            this.ToolStrip.TabIndex = 5;
            // 
            // NewFileButton
            // 
            this.NewFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.NewFileButton.Image = (Image)resources.GetObject("NewFileButton.Image");
            this.NewFileButton.ImageTransparentColor = Color.Magenta;
            this.NewFileButton.Margin = new Padding(0, 2, 2, 2);
            this.NewFileButton.Name = "NewFileButton";
            this.NewFileButton.Size = new Size(28, 27);
            this.NewFileButton.Text = "Новый";
            this.NewFileButton.Click += this.NewFileButtonClick;
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.SaveFileButton.Image = (Image)resources.GetObject("SaveFileButton.Image");
            this.SaveFileButton.ImageTransparentColor = Color.Magenta;
            this.SaveFileButton.Margin = new Padding(0, 2, 2, 2);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new Size(28, 27);
            this.SaveFileButton.Text = "Сохранить";
            this.SaveFileButton.Click += this.SaveFileButtonClick;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.OpenFileButton.Image = (Image)resources.GetObject("OpenFileButton.Image");
            this.OpenFileButton.ImageTransparentColor = Color.Magenta;
            this.OpenFileButton.Margin = new Padding(0, 2, 2, 2);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new Size(28, 27);
            this.OpenFileButton.Text = "Открыть";
            this.OpenFileButton.Click += this.OpenFileButtonClick;
            // 
            // CanvasSizeButton
            // 
            this.CanvasSizeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.CanvasSizeButton.Image = (Image)resources.GetObject("CanvasSizeButton.Image");
            this.CanvasSizeButton.ImageTransparentColor = Color.Magenta;
            this.CanvasSizeButton.Margin = new Padding(0, 2, 2, 2);
            this.CanvasSizeButton.Name = "CanvasSizeButton";
            this.CanvasSizeButton.Size = new Size(28, 27);
            this.CanvasSizeButton.Text = "Размер холста";
            this.CanvasSizeButton.Click += this.CanvasSizeButtonClick;
            // 
            // BrushGroupSeparator
            // 
            this.BrushGroupSeparator.Name = "BrushGroupSeparator";
            this.BrushGroupSeparator.Size = new Size(6, 31);
            // 
            // BrushDropDownButton
            // 
            this.BrushDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.BrushDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { this.BrushColorButton, this.BrushSizeButton });
            this.BrushDropDownButton.Image = (Image)resources.GetObject("BrushDropDownButton.Image");
            this.BrushDropDownButton.ImageTransparentColor = Color.Magenta;
            this.BrushDropDownButton.Margin = new Padding(0, 2, 2, 2);
            this.BrushDropDownButton.Name = "BrushDropDownButton";
            this.BrushDropDownButton.Size = new Size(37, 27);
            // 
            // BrushColorButton
            // 
            this.BrushColorButton.Name = "BrushColorButton";
            this.BrushColorButton.Size = new Size(205, 22);
            this.BrushColorButton.Text = "Изменить цвет кисти";
            this.BrushColorButton.Click += this.BrushColorButtonClick;
            // 
            // BrushSizeButton
            // 
            this.BrushSizeButton.Name = "BrushSizeButton";
            this.BrushSizeButton.Size = new Size(205, 22);
            this.BrushSizeButton.Text = "Изменить размер кисти";
            this.BrushSizeButton.Click += this.BrushSizeButtonClick;
            // 
            // FillingDropDownButton
            // 
            this.FillingDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.FillingDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { this.FillingButton, this.FillingColorButton });
            this.FillingDropDownButton.Image = (Image)resources.GetObject("FillingDropDownButton.Image");
            this.FillingDropDownButton.ImageTransparentColor = Color.Magenta;
            this.FillingDropDownButton.Margin = new Padding(0, 2, 2, 2);
            this.FillingDropDownButton.Name = "FillingDropDownButton";
            this.FillingDropDownButton.Size = new Size(37, 27);
            this.FillingDropDownButton.ToolTipText = "Заливка";
            this.FillingDropDownButton.Click += this.FillingColorButtonClick;
            // 
            // FillingButton
            // 
            this.FillingButton.Name = "FillingButton";
            this.FillingButton.Size = new Size(202, 22);
            this.FillingButton.Text = "Заливка";
            this.FillingButton.Click += this.FillingButtonClick;
            // 
            // FillingColorButton
            // 
            this.FillingColorButton.Name = "FillingColorButton";
            this.FillingColorButton.Size = new Size(202, 22);
            this.FillingColorButton.Text = "Изменить цвет заливки";
            this.FillingColorButton.Click += this.FillingColorButtonClick;
            // 
            // FuguresGroupSeparator
            // 
            this.FuguresGroupSeparator.Name = "FuguresGroupSeparator";
            this.FuguresGroupSeparator.Size = new Size(6, 31);
            // 
            // RectangleButton
            // 
            this.RectangleButton.Checked = true;
            this.RectangleButton.CheckState = CheckState.Checked;
            this.RectangleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.RectangleButton.Image = (Image)resources.GetObject("RectangleButton.Image");
            this.RectangleButton.ImageTransparentColor = Color.Magenta;
            this.RectangleButton.Margin = new Padding(0, 2, 2, 2);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new Size(28, 27);
            this.RectangleButton.Text = "Прямоугольник";
            this.RectangleButton.Click += this.RectangleButtonClick;
            // 
            // EllipseButton
            // 
            this.EllipseButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.EllipseButton.Image = (Image)resources.GetObject("EllipseButton.Image");
            this.EllipseButton.ImageTransparentColor = Color.Magenta;
            this.EllipseButton.Margin = new Padding(0, 2, 2, 2);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new Size(28, 27);
            this.EllipseButton.Text = "Элипс";
            this.EllipseButton.Click += this.EllipseButtonClick;
            // 
            // StraightLineButton
            // 
            this.StraightLineButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.StraightLineButton.Image = (Image)resources.GetObject("StraightLineButton.Image");
            this.StraightLineButton.ImageTransparentColor = Color.Magenta;
            this.StraightLineButton.Margin = new Padding(0, 2, 2, 2);
            this.StraightLineButton.Name = "StraightLineButton";
            this.StraightLineButton.Size = new Size(28, 27);
            this.StraightLineButton.Text = "Прямая линия";
            this.StraightLineButton.Click += this.StraightLineButtonClick;
            // 
            // CurveLineButton
            // 
            this.CurveLineButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.CurveLineButton.Image = (Image)resources.GetObject("CurveLineButton.Image");
            this.CurveLineButton.ImageTransparentColor = Color.Magenta;
            this.CurveLineButton.Margin = new Padding(0, 2, 2, 2);
            this.CurveLineButton.Name = "CurveLineButton";
            this.CurveLineButton.Size = new Size(28, 27);
            this.CurveLineButton.Text = "Кривая линия";
            this.CurveLineButton.Click += this.CurveLineButtonClick;
            // 
            // TextGroupSeparator
            // 
            this.TextGroupSeparator.Name = "TextGroupSeparator";
            this.TextGroupSeparator.Size = new Size(6, 31);
            // 
            // TextButton
            // 
            this.TextButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.TextButton.Image = (Image)resources.GetObject("TextButton.Image");
            this.TextButton.ImageTransparentColor = Color.Magenta;
            this.TextButton.Margin = new Padding(0, 2, 2, 2);
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new Size(28, 27);
            this.TextButton.Text = "Текст";
            this.TextButton.Click += this.TextButtonClick;
            // 
            // FontButton
            // 
            this.FontButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.FontButton.Image = (Image)resources.GetObject("FontButton.Image");
            this.FontButton.ImageTransparentColor = Color.Magenta;
            this.FontButton.Margin = new Padding(0, 2, 2, 2);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new Size(28, 27);
            this.FontButton.Text = "Шрифт";
            this.FontButton.Click += this.FontButtonClick;
            // 
            // SelectionGroupSeparator
            // 
            this.SelectionGroupSeparator.Name = "SelectionGroupSeparator";
            this.SelectionGroupSeparator.Size = new Size(6, 31);
            // 
            // SelectionButton
            // 
            this.SelectionButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.SelectionButton.Image = (Image)resources.GetObject("SelectionButton.Image");
            this.SelectionButton.ImageTransparentColor = Color.Magenta;
            this.SelectionButton.Margin = new Padding(0, 2, 2, 2);
            this.SelectionButton.Name = "SelectionButton";
            this.SelectionButton.Size = new Size(28, 27);
            this.SelectionButton.Text = "Выделение";
            this.SelectionButton.Click += this.SelectionButtonClick;
            // 
            // UxMainWindow
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1264, 681);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.IsMdiContainer = true;
            this.Margin = new Padding(4);
            this.Name = "UxMainWindow";
            this.Text = "Paint";
            this.Load += this.LoadHandler;
            this.MouseDown += this.MouseDownHandler;
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
        private System.Windows.Forms.ToolStripMenuItem BrushColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrushSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FillingColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FigureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StraightLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CurveLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FillingToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel FillingColor;
        private System.Windows.Forms.ToolStripStatusLabel CanvasSize;
        private System.Windows.Forms.ToolStripStatusLabel BrushSize;
		private System.Windows.Forms.ToolStripStatusLabel MouseCords;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton NewFileButton;
        private System.Windows.Forms.ToolStripButton SaveFileButton;
        private System.Windows.Forms.ToolStripButton OpenFileButton;
        private System.Windows.Forms.ToolStripButton CanvasSizeButton;
        private System.Windows.Forms.ToolStripButton RectangleButton;
        private System.Windows.Forms.ToolStripButton EllipseButton;
        private System.Windows.Forms.ToolStripButton StraightLineButton;
        private System.Windows.Forms.ToolStripButton CurveLineButton;
        private System.Windows.Forms.ToolStripButton TextButton;
        private System.Windows.Forms.ToolStripMenuItem TextToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel FontName;
        private System.Windows.Forms.ToolStripMenuItem FontToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton FontButton;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.ToolStripMenuItem SelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SelectionButton;
        private ToolStripDropDownButton BrushDropDownButton;
        private ToolStripMenuItem BrushSizeButton;
        private ToolStripMenuItem BrushColorButton;
        private ToolStripSeparator BrushGroupSeparator;
        private ToolStripSeparator FuguresGroupSeparator;
        private ToolStripSeparator TextGroupSeparator;
        private ToolStripSeparator SelectionGroupSeparator;
        private ToolStripSeparator FillingSeparator;
        private ToolStripDropDownButton FillingDropDownButton;
        private ToolStripMenuItem FillingButton;
        private ToolStripMenuItem FillingColorButton;
    }
}
