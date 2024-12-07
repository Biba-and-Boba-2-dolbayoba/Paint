
namespace Paint
{
    partial class UiMainWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UiMainWindow));
            this.MenuStrip = new MenuStrip();
            this.FileToolButton = new ToolStripMenuItem();
            this.NewFileToolButton = new ToolStripMenuItem();
            this.OpenFileToolButton = new ToolStripMenuItem();
            this.SaveFileToolButton = new ToolStripMenuItem();
            this.SaveFileAsToolButton = new ToolStripMenuItem();
            this.SettingsToolButton = new ToolStripMenuItem();
            this.BrushColorToolButton = new ToolStripMenuItem();
            this.BrushSizeToolButton = new ToolStripMenuItem();
            this.FillingColorToolButton = new ToolStripMenuItem();
            this.CanvasSizeToolButton = new ToolStripMenuItem();
            this.FontToolButton = new ToolStripMenuItem();
            this.FigureToolButton = new ToolStripMenuItem();
            this.RectangleToolButton = new ToolStripMenuItem();
            this.EllipseToolButton = new ToolStripMenuItem();
            this.StraightLineToolButton = new ToolStripMenuItem();
            this.CurveLineToolButton = new ToolStripMenuItem();
            this.TextToolButton = new ToolStripMenuItem();
            this.FillingSeparator = new ToolStripSeparator();
            this.FillingToolButton = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripMenuItem();
            this.DrawingToolButton = new ToolStripMenuItem();
            this.SelectionToolButton = new ToolStripMenuItem();
            this.EditToolButton = new ToolStripMenuItem();
            this.StatusStrip = new StatusStrip();
            this.PointerInfo = new ToolStripStatusLabel();
            this.CanvasInfo = new ToolStripStatusLabel();
            this.FontInfo = new ToolStripStatusLabel();
            this.BrushInfo = new ToolStripStatusLabel();
            this.FillingInfo = new ToolStripStatusLabel();
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
            this.DrawingButton = new ToolStripButton();
            this.SelectionButton = new ToolStripButton();
            this.EditButton = new ToolStripButton();
            this.FontDialog = new FontDialog();
            this.CanvasPlaceholder = new Panel();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = Color.WhiteSmoke;
            this.MenuStrip.Items.AddRange(new ToolStripItem[] { this.FileToolButton, this.SettingsToolButton, this.FigureToolButton, this.toolStripMenuItem1 });
            this.MenuStrip.Location = new Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new Padding(5, 0, 5, 0);
            this.MenuStrip.RenderMode = ToolStripRenderMode.Professional;
            this.MenuStrip.Size = new Size(1264, 24);
            this.MenuStrip.TabIndex = 1;
            // 
            // FileToolButton
            // 
            this.FileToolButton.DropDownItems.AddRange(new ToolStripItem[] { this.NewFileToolButton, this.OpenFileToolButton, this.SaveFileToolButton, this.SaveFileAsToolButton });
            this.FileToolButton.Name = "FileToolButton";
            this.FileToolButton.Size = new Size(48, 24);
            this.FileToolButton.Text = "Файл";
            // 
            // NewFileToolButton
            // 
            this.NewFileToolButton.Name = "NewFileToolButton";
            this.NewFileToolButton.Size = new Size(163, 22);
            this.NewFileToolButton.Text = "Новый";
            this.NewFileToolButton.Click += this.NewFileButtonClick;
            // 
            // OpenFileToolButton
            // 
            this.OpenFileToolButton.Name = "OpenFileToolButton";
            this.OpenFileToolButton.Size = new Size(163, 22);
            this.OpenFileToolButton.Text = "Открыть";
            this.OpenFileToolButton.Click += this.OpenFileButtonClick;
            // 
            // SaveFileToolButton
            // 
            this.SaveFileToolButton.Name = "SaveFileToolButton";
            this.SaveFileToolButton.Size = new Size(163, 22);
            this.SaveFileToolButton.Text = "Сохранить";
            this.SaveFileToolButton.Click += this.SaveFileButtonClick;
            // 
            // SaveFileAsToolButton
            // 
            this.SaveFileAsToolButton.Name = "SaveFileAsToolButton";
            this.SaveFileAsToolButton.Size = new Size(163, 22);
            this.SaveFileAsToolButton.Text = "Сохранить как...";
            this.SaveFileAsToolButton.Click += this.SaveFileAsButtonClick;
            // 
            // SettingsToolButton
            // 
            this.SettingsToolButton.DropDownItems.AddRange(new ToolStripItem[] { this.BrushColorToolButton, this.BrushSizeToolButton, this.FillingColorToolButton, this.CanvasSizeToolButton, this.FontToolButton });
            this.SettingsToolButton.Name = "SettingsToolButton";
            this.SettingsToolButton.Size = new Size(83, 24);
            this.SettingsToolButton.Text = "Параметры";
            // 
            // BrushColorToolButton
            // 
            this.BrushColorToolButton.Name = "BrushColorToolButton";
            this.BrushColorToolButton.Size = new Size(211, 22);
            this.BrushColorToolButton.Text = "Изменить цвет кисти";
            this.BrushColorToolButton.Click += this.PenColorButtonClick;
            // 
            // BrushSizeToolButton
            // 
            this.BrushSizeToolButton.Name = "BrushSizeToolButton";
            this.BrushSizeToolButton.Size = new Size(211, 22);
            this.BrushSizeToolButton.Text = "Изменить размер кисти";
            this.BrushSizeToolButton.Click += this.PenSizeButtonClick;
            // 
            // FillingColorToolButton
            // 
            this.FillingColorToolButton.Name = "FillingColorToolButton";
            this.FillingColorToolButton.Size = new Size(211, 22);
            this.FillingColorToolButton.Text = "Изменить цвет заливки";
            this.FillingColorToolButton.Click += this.BrushColorButtonClick;
            // 
            // CanvasSizeToolButton
            // 
            this.CanvasSizeToolButton.Name = "CanvasSizeToolButton";
            this.CanvasSizeToolButton.Size = new Size(211, 22);
            this.CanvasSizeToolButton.Text = "Изменить размер холста";
            this.CanvasSizeToolButton.Click += this.CanvasSizeButtonClick;
            // 
            // FontToolButton
            // 
            this.FontToolButton.Name = "FontToolButton";
            this.FontToolButton.Size = new Size(211, 22);
            this.FontToolButton.Text = "Изменить шрифт";
            this.FontToolButton.Click += this.FontButtonClick;
            // 
            // FigureToolButton
            // 
            this.FigureToolButton.DropDownItems.AddRange(new ToolStripItem[] { this.RectangleToolButton, this.EllipseToolButton, this.StraightLineToolButton, this.CurveLineToolButton, this.TextToolButton, this.FillingSeparator, this.FillingToolButton });
            this.FigureToolButton.Name = "FigureToolButton";
            this.FigureToolButton.Size = new Size(59, 24);
            this.FigureToolButton.Text = "Фигура";
            // 
            // RectangleToolButton
            // 
            this.RectangleToolButton.Checked = true;
            this.RectangleToolButton.CheckState = CheckState.Checked;
            this.RectangleToolButton.Name = "RectangleToolButton";
            this.RectangleToolButton.Size = new Size(191, 22);
            this.RectangleToolButton.Text = "Прямоугольник";
            this.RectangleToolButton.Click += this.RectangleButtonClick;
            // 
            // EllipseToolButton
            // 
            this.EllipseToolButton.Name = "EllipseToolButton";
            this.EllipseToolButton.Size = new Size(191, 22);
            this.EllipseToolButton.Text = "Эллипс";
            this.EllipseToolButton.Click += this.EllipseButtonClick;
            // 
            // StraightLineToolButton
            // 
            this.StraightLineToolButton.Name = "StraightLineToolButton";
            this.StraightLineToolButton.Size = new Size(191, 22);
            this.StraightLineToolButton.Text = "Прямая линия";
            this.StraightLineToolButton.Click += this.StraightLineButtonClick;
            // 
            // CurveLineToolButton
            // 
            this.CurveLineToolButton.Name = "CurveLineToolButton";
            this.CurveLineToolButton.Size = new Size(191, 22);
            this.CurveLineToolButton.Text = "Произвольная линия";
            this.CurveLineToolButton.Click += this.CurveLineButtonClick;
            // 
            // TextToolButton
            // 
            this.TextToolButton.Name = "TextToolButton";
            this.TextToolButton.Size = new Size(191, 22);
            this.TextToolButton.Text = "Текст";
            this.TextToolButton.Click += this.TextButtonClick;
            // 
            // FillingSeparator
            // 
            this.FillingSeparator.Name = "FillingSeparator";
            this.FillingSeparator.Size = new Size(188, 6);
            // 
            // FillingToolButton
            // 
            this.FillingToolButton.Name = "FillingToolButton";
            this.FillingToolButton.Size = new Size(191, 22);
            this.FillingToolButton.Text = "Заливка";
            this.FillingToolButton.Click += this.FillingButtonClick;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { this.DrawingToolButton, this.SelectionToolButton, this.EditToolButton });
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(57, 24);
            this.toolStripMenuItem1.Text = "Режим";
            // 
            // DrawingToolButton
            // 
            this.DrawingToolButton.Name = "DrawingToolButton";
            this.DrawingToolButton.Size = new Size(180, 22);
            this.DrawingToolButton.Text = "Рисование";
            this.DrawingToolButton.Click += this.DrawingButtonClick;
            // 
            // SelectionToolButton
            // 
            this.SelectionToolButton.Name = "SelectionToolButton";
            this.SelectionToolButton.Size = new Size(180, 22);
            this.SelectionToolButton.Text = "Выделение";
            this.SelectionToolButton.Click += this.SelectionButtonClick;
            // 
            // EditToolButton
            // 
            this.EditToolButton.Name = "EditToolButton";
            this.EditToolButton.Size = new Size(180, 22);
            this.EditToolButton.Text = "Редактирование";
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = Color.WhiteSmoke;
            this.StatusStrip.GripMargin = new Padding(0, 0, 0, 2);
            this.StatusStrip.Items.AddRange(new ToolStripItem[] { this.PointerInfo, this.CanvasInfo, this.FontInfo, this.BrushInfo, this.FillingInfo });
            this.StatusStrip.Location = new Point(0, 657);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Padding = new Padding(1, 0, 16, 0);
            this.StatusStrip.RenderMode = ToolStripRenderMode.Professional;
            this.StatusStrip.Size = new Size(1264, 24);
            this.StatusStrip.Stretch = false;
            this.StatusStrip.TabIndex = 3;
            // 
            // PointerInfo
            // 
            this.PointerInfo.AutoSize = false;
            this.PointerInfo.Image = (Image)resources.GetObject("PointerInfo.Image");
            this.PointerInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.PointerInfo.Margin = new Padding(0, 0, 5, 0);
            this.PointerInfo.Name = "PointerInfo";
            this.PointerInfo.Size = new Size(150, 24);
            this.PointerInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CanvasInfo
            // 
            this.CanvasInfo.AutoSize = false;
            this.CanvasInfo.Image = (Image)resources.GetObject("CanvasInfo.Image");
            this.CanvasInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.CanvasInfo.Margin = new Padding(0, 0, 5, 0);
            this.CanvasInfo.Name = "CanvasInfo";
            this.CanvasInfo.Size = new Size(150, 24);
            this.CanvasInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FontInfo
            // 
            this.FontInfo.AutoSize = false;
            this.FontInfo.Image = (Image)resources.GetObject("FontInfo.Image");
            this.FontInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.FontInfo.Margin = new Padding(0, 0, 5, 0);
            this.FontInfo.Name = "FontInfo";
            this.FontInfo.Size = new Size(200, 24);
            this.FontInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BrushInfo
            // 
            this.BrushInfo.AutoSize = false;
            this.BrushInfo.Image = (Image)resources.GetObject("BrushInfo.Image");
            this.BrushInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.BrushInfo.Margin = new Padding(0, 0, 5, 0);
            this.BrushInfo.Name = "BrushInfo";
            this.BrushInfo.Size = new Size(160, 24);
            this.BrushInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FillingInfo
            // 
            this.FillingInfo.AutoSize = false;
            this.FillingInfo.Image = (Image)resources.GetObject("FillingInfo.Image");
            this.FillingInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.FillingInfo.Margin = new Padding(0, 0, 5, 0);
            this.FillingInfo.Name = "FillingInfo";
            this.FillingInfo.Size = new Size(160, 24);
            this.FillingInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = Color.White;
            this.ToolStrip.BackgroundImageLayout = ImageLayout.None;
            this.ToolStrip.CanOverflow = false;
            this.ToolStrip.GripMargin = new Padding(0);
            this.ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new Size(24, 24);
            this.ToolStrip.Items.AddRange(new ToolStripItem[] { this.NewFileButton, this.SaveFileButton, this.OpenFileButton, this.CanvasSizeButton, this.BrushGroupSeparator, this.BrushDropDownButton, this.FillingDropDownButton, this.FuguresGroupSeparator, this.RectangleButton, this.EllipseButton, this.StraightLineButton, this.CurveLineButton, this.TextGroupSeparator, this.TextButton, this.FontButton, this.SelectionGroupSeparator, this.DrawingButton, this.SelectionButton, this.EditButton });
            this.ToolStrip.Location = new Point(0, 24);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new Padding(10, 0, 10, 0);
            this.ToolStrip.RenderMode = ToolStripRenderMode.Professional;
            this.ToolStrip.ShowItemToolTips = false;
            this.ToolStrip.Size = new Size(1264, 32);
            this.ToolStrip.TabIndex = 5;
            // 
            // NewFileButton
            // 
            this.NewFileButton.AutoToolTip = false;
            this.NewFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.NewFileButton.Image = (Image)resources.GetObject("NewFileButton.Image");
            this.NewFileButton.ImageTransparentColor = Color.Magenta;
            this.NewFileButton.Margin = new Padding(0, 2, 2, 2);
            this.NewFileButton.Name = "NewFileButton";
            this.NewFileButton.Size = new Size(28, 28);
            this.NewFileButton.Text = "Новый";
            this.NewFileButton.Click += this.NewFileButtonClick;
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.AutoToolTip = false;
            this.SaveFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.SaveFileButton.Image = (Image)resources.GetObject("SaveFileButton.Image");
            this.SaveFileButton.ImageTransparentColor = Color.Magenta;
            this.SaveFileButton.Margin = new Padding(0, 2, 2, 2);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new Size(28, 28);
            this.SaveFileButton.Text = "Сохранить";
            this.SaveFileButton.Click += this.SaveFileButtonClick;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.AutoToolTip = false;
            this.OpenFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.OpenFileButton.Image = (Image)resources.GetObject("OpenFileButton.Image");
            this.OpenFileButton.ImageTransparentColor = Color.Magenta;
            this.OpenFileButton.Margin = new Padding(0, 2, 2, 2);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new Size(28, 28);
            this.OpenFileButton.Text = "Открыть";
            this.OpenFileButton.Click += this.OpenFileButtonClick;
            // 
            // CanvasSizeButton
            // 
            this.CanvasSizeButton.AutoToolTip = false;
            this.CanvasSizeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.CanvasSizeButton.Image = (Image)resources.GetObject("CanvasSizeButton.Image");
            this.CanvasSizeButton.ImageTransparentColor = Color.Magenta;
            this.CanvasSizeButton.Margin = new Padding(0, 2, 2, 2);
            this.CanvasSizeButton.Name = "CanvasSizeButton";
            this.CanvasSizeButton.Size = new Size(28, 28);
            this.CanvasSizeButton.Text = "Размер холста";
            this.CanvasSizeButton.Click += this.CanvasSizeButtonClick;
            // 
            // BrushGroupSeparator
            // 
            this.BrushGroupSeparator.Name = "BrushGroupSeparator";
            this.BrushGroupSeparator.Size = new Size(6, 32);
            // 
            // BrushDropDownButton
            // 
            this.BrushDropDownButton.AutoToolTip = false;
            this.BrushDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.BrushDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { this.BrushColorButton, this.BrushSizeButton });
            this.BrushDropDownButton.Image = (Image)resources.GetObject("BrushDropDownButton.Image");
            this.BrushDropDownButton.ImageTransparentColor = Color.Magenta;
            this.BrushDropDownButton.Margin = new Padding(0, 2, 2, 2);
            this.BrushDropDownButton.Name = "BrushDropDownButton";
            this.BrushDropDownButton.Size = new Size(37, 28);
            // 
            // BrushColorButton
            // 
            this.BrushColorButton.Name = "BrushColorButton";
            this.BrushColorButton.Size = new Size(205, 22);
            this.BrushColorButton.Text = "Изменить цвет кисти";
            this.BrushColorButton.Click += this.PenColorButtonClick;
            // 
            // BrushSizeButton
            // 
            this.BrushSizeButton.Name = "BrushSizeButton";
            this.BrushSizeButton.Size = new Size(205, 22);
            this.BrushSizeButton.Text = "Изменить размер кисти";
            this.BrushSizeButton.Click += this.PenSizeButtonClick;
            // 
            // FillingDropDownButton
            // 
            this.FillingDropDownButton.AutoToolTip = false;
            this.FillingDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.FillingDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { this.FillingButton, this.FillingColorButton });
            this.FillingDropDownButton.Image = (Image)resources.GetObject("FillingDropDownButton.Image");
            this.FillingDropDownButton.ImageTransparentColor = Color.Magenta;
            this.FillingDropDownButton.Margin = new Padding(0, 2, 2, 2);
            this.FillingDropDownButton.Name = "FillingDropDownButton";
            this.FillingDropDownButton.Size = new Size(37, 28);
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
            this.FillingColorButton.Click += this.BrushColorButtonClick;
            // 
            // FuguresGroupSeparator
            // 
            this.FuguresGroupSeparator.Name = "FuguresGroupSeparator";
            this.FuguresGroupSeparator.Size = new Size(6, 32);
            // 
            // RectangleButton
            // 
            this.RectangleButton.AutoToolTip = false;
            this.RectangleButton.Checked = true;
            this.RectangleButton.CheckState = CheckState.Checked;
            this.RectangleButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.RectangleButton.Image = (Image)resources.GetObject("RectangleButton.Image");
            this.RectangleButton.ImageTransparentColor = Color.Magenta;
            this.RectangleButton.Margin = new Padding(0, 2, 2, 2);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new Size(28, 28);
            this.RectangleButton.Text = "Прямоугольник";
            this.RectangleButton.Click += this.RectangleButtonClick;
            // 
            // EllipseButton
            // 
            this.EllipseButton.AutoToolTip = false;
            this.EllipseButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.EllipseButton.Image = (Image)resources.GetObject("EllipseButton.Image");
            this.EllipseButton.ImageTransparentColor = Color.Magenta;
            this.EllipseButton.Margin = new Padding(0, 2, 2, 2);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new Size(28, 28);
            this.EllipseButton.Text = "Элипс";
            this.EllipseButton.Click += this.EllipseButtonClick;
            // 
            // StraightLineButton
            // 
            this.StraightLineButton.AutoToolTip = false;
            this.StraightLineButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.StraightLineButton.Image = (Image)resources.GetObject("StraightLineButton.Image");
            this.StraightLineButton.ImageTransparentColor = Color.Magenta;
            this.StraightLineButton.Margin = new Padding(0, 2, 2, 2);
            this.StraightLineButton.Name = "StraightLineButton";
            this.StraightLineButton.Size = new Size(28, 28);
            this.StraightLineButton.Text = "Прямая линия";
            this.StraightLineButton.Click += this.StraightLineButtonClick;
            // 
            // CurveLineButton
            // 
            this.CurveLineButton.AutoToolTip = false;
            this.CurveLineButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.CurveLineButton.Image = (Image)resources.GetObject("CurveLineButton.Image");
            this.CurveLineButton.ImageTransparentColor = Color.Magenta;
            this.CurveLineButton.Margin = new Padding(0, 2, 2, 2);
            this.CurveLineButton.Name = "CurveLineButton";
            this.CurveLineButton.Size = new Size(28, 28);
            this.CurveLineButton.Text = "Кривая линия";
            this.CurveLineButton.Click += this.CurveLineButtonClick;
            // 
            // TextGroupSeparator
            // 
            this.TextGroupSeparator.Name = "TextGroupSeparator";
            this.TextGroupSeparator.Size = new Size(6, 32);
            // 
            // TextButton
            // 
            this.TextButton.AutoToolTip = false;
            this.TextButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.TextButton.Image = (Image)resources.GetObject("TextButton.Image");
            this.TextButton.ImageTransparentColor = Color.Magenta;
            this.TextButton.Margin = new Padding(0, 2, 2, 2);
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new Size(28, 28);
            this.TextButton.Text = "Текст";
            this.TextButton.Click += this.TextButtonClick;
            // 
            // FontButton
            // 
            this.FontButton.AutoToolTip = false;
            this.FontButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.FontButton.Image = (Image)resources.GetObject("FontButton.Image");
            this.FontButton.ImageTransparentColor = Color.Magenta;
            this.FontButton.Margin = new Padding(0, 2, 2, 2);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new Size(28, 28);
            this.FontButton.Text = "Шрифт";
            this.FontButton.Click += this.FontButtonClick;
            // 
            // SelectionGroupSeparator
            // 
            this.SelectionGroupSeparator.Name = "SelectionGroupSeparator";
            this.SelectionGroupSeparator.Size = new Size(6, 32);
            // 
            // DrawingButton
            // 
            this.DrawingButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.DrawingButton.Image = (Image)resources.GetObject("DrawingButton.Image");
            this.DrawingButton.ImageTransparentColor = Color.Magenta;
            this.DrawingButton.Name = "DrawingButton";
            this.DrawingButton.Size = new Size(28, 29);
            this.DrawingButton.Text = "Рисование";
            this.DrawingButton.Click += this.DrawingButtonClick;
            // 
            // SelectionButton
            // 
            this.SelectionButton.AutoToolTip = false;
            this.SelectionButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.SelectionButton.Image = (Image)resources.GetObject("SelectionButton.Image");
            this.SelectionButton.ImageTransparentColor = Color.Magenta;
            this.SelectionButton.Margin = new Padding(0, 2, 2, 2);
            this.SelectionButton.Name = "SelectionButton";
            this.SelectionButton.Size = new Size(28, 28);
            this.SelectionButton.Text = "Выделение";
            this.SelectionButton.Click += this.SelectionButtonClick;
            // 
            // EditButton
            // 
            this.EditButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.EditButton.Image = (Image)resources.GetObject("EditButton.Image");
            this.EditButton.ImageTransparentColor = Color.Magenta;
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new Size(28, 29);
            this.EditButton.Text = "Редактирование";
            this.EditButton.Click += this.EditButtonClick;
            // 
            // CanvasPlaceholder
            // 
            this.CanvasPlaceholder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.CanvasPlaceholder.AutoSize = true;
            this.CanvasPlaceholder.BackColor = Color.Transparent;
            this.CanvasPlaceholder.Location = new Point(0, 59);
            this.CanvasPlaceholder.Name = "CanvasPlaceholder";
            this.CanvasPlaceholder.Size = new Size(1264, 595);
            this.CanvasPlaceholder.TabIndex = 7;
            this.CanvasPlaceholder.Visible = false;
            // 
            // UiMainWindow
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1264, 681);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.CanvasPlaceholder);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.IsMdiContainer = true;
            this.Margin = new Padding(4);
            this.Name = "UiMainWindow";
            this.Text = "Paint";
            this.Load += this.OnLoad;
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

        private MenuStrip MenuStrip;
        private ToolStripMenuItem CanvasSizeToolButton;
        private ToolStripMenuItem FileToolButton;
        private ToolStripMenuItem NewFileToolButton;
        private ToolStripMenuItem SaveFileAsToolButton;
        private ToolStripMenuItem OpenFileToolButton;
        private ToolStripMenuItem SaveFileToolButton;
        private ToolStripMenuItem SettingsToolButton;
        private ToolStripMenuItem BrushColorToolButton;
        private ToolStripMenuItem BrushSizeToolButton;
        private ToolStripMenuItem FillingColorToolButton;
        private ToolStripMenuItem FigureToolButton;
        private ToolStripMenuItem RectangleToolButton;
        private ToolStripMenuItem EllipseToolButton;
        private ToolStripMenuItem StraightLineToolButton;
        private ToolStripMenuItem CurveLineToolButton;
        private ToolStripMenuItem FillingToolButton;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel FillingInfo;
        private ToolStripStatusLabel CanvasInfo;
        private ToolStripStatusLabel BrushInfo;
		private ToolStripStatusLabel PointerInfo;
        private ToolStrip ToolStrip;
        private ToolStripButton NewFileButton;
        private ToolStripButton SaveFileButton;
        private ToolStripButton OpenFileButton;
        private ToolStripButton CanvasSizeButton;
        private ToolStripButton RectangleButton;
        private ToolStripButton EllipseButton;
        private ToolStripButton StraightLineButton;
        private ToolStripButton CurveLineButton;
        private ToolStripButton TextButton;
        private ToolStripMenuItem TextToolButton;
        private ToolStripStatusLabel FontInfo;
        private ToolStripMenuItem FontToolButton;
        private ToolStripButton FontButton;
        private FontDialog FontDialog;
        private ToolStripMenuItem SelectionToolButton;
        private ToolStripButton SelectionButton;
        private ToolStripSeparator BrushGroupSeparator;
        private ToolStripSeparator FuguresGroupSeparator;
        private ToolStripSeparator TextGroupSeparator;
        private ToolStripSeparator SelectionGroupSeparator;
        private ToolStripSeparator FillingSeparator;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem DrawingToolButton;
        private ToolStripMenuItem EditToolButton;
        private ToolStripDropDownButton BrushDropDownButton;
        private ToolStripMenuItem BrushColorButton;
        private ToolStripMenuItem BrushSizeButton;
        private ToolStripDropDownButton FillingDropDownButton;
        private ToolStripMenuItem FillingButton;
        private ToolStripMenuItem FillingColorButton;
        private Panel CanvasPlaceholder;
        private ToolStripButton DrawingButton;
        private ToolStripButton EditButton;
    }
}
