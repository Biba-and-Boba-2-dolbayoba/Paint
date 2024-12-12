using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.SettingsToolButton = new ToolStripMenuItem();
            this.PenColorToolButton = new ToolStripMenuItem();
            this.PenSizeToolButton = new ToolStripMenuItem();
            this.BrushColorToolButton = new ToolStripMenuItem();
            this.FontToolButton = new ToolStripMenuItem();
            this.FigureToolButton = new ToolStripMenuItem();
            this.RectangleToolButton = new ToolStripMenuItem();
            this.EllipseToolButton = new ToolStripMenuItem();
            this.StraightLineToolButton = new ToolStripMenuItem();
            this.CurveLineToolButton = new ToolStripMenuItem();
            this.TextToolButton = new ToolStripMenuItem();
            this.FillingSeparator = new ToolStripSeparator();
            this.FillingToolButton = new ToolStripMenuItem();
            this.StateToolButton = new ToolStripMenuItem();
            this.DrawingToolButton = new ToolStripMenuItem();
            this.SelectionToolButton = new ToolStripMenuItem();
            this.EditToolButton = new ToolStripMenuItem();
            this.CoordinatToolButton = new ToolStripMenuItem();
            this.GridToolButton = new ToolStripMenuItem();
            this.GridStepToolButton = new ToolStripMenuItem();
            this.DefaultGridStepToolButton = new ToolStripMenuItem();
            this.MaxGridStepToolButton = new ToolStripMenuItem();
            this.SnapToGridToolButton = new ToolStripMenuItem();
            this.StatusStrip = new StatusStrip();
            this.PointerInfo = new ToolStripStatusLabel();
            this.CanvasInfo = new ToolStripStatusLabel();
            this.FontInfo = new ToolStripStatusLabel();
            this.PenInfo = new ToolStripStatusLabel();
            this.BrushInfo = new ToolStripStatusLabel();
            this.ToolStrip = new ToolStrip();
            this.NewFileButton = new ToolStripButton();
            this.SaveFileButton = new ToolStripButton();
            this.OpenFileButton = new ToolStripButton();
            this.BrushGroupSeparator = new ToolStripSeparator();
            this.PenDropDownButton = new ToolStripDropDownButton();
            this.PenColorButton = new ToolStripMenuItem();
            this.PenSizeButton = new ToolStripMenuItem();
            this.FillingDropDownButton = new ToolStripDropDownButton();
            this.FillingButton = new ToolStripMenuItem();
            this.BrushColorButton = new ToolStripMenuItem();
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
            this.CoordinateGridSeparator = new ToolStripSeparator();
            this.CoordinatDownButton = new ToolStripDropDownButton();
            this.GridButton = new ToolStripMenuItem();
            this.GridStepButton = new ToolStripMenuItem();
            this.DefaultGridStepButton = new ToolStripMenuItem();
            this.MaxGridStepButton = new ToolStripMenuItem();
            this.SnapToGridButton = new ToolStripMenuItem();
            this.FontDialog = new FontDialog();
            this.FigureTableButton = new ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = Color.WhiteSmoke;
            this.MenuStrip.Items.AddRange(new ToolStripItem[] { this.FileToolButton, this.SettingsToolButton, this.FigureToolButton, this.StateToolButton, this.CoordinatToolButton, this.FigureTableButton });
            this.MenuStrip.Location = new Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new Padding(5, 0, 5, 0);
            this.MenuStrip.RenderMode = ToolStripRenderMode.Professional;
            this.MenuStrip.Size = new Size(1264, 24);
            this.MenuStrip.TabIndex = 1;
            // 
            // FileToolButton
            // 
            this.FileToolButton.DropDownItems.AddRange(new ToolStripItem[] { this.NewFileToolButton, this.OpenFileToolButton, this.SaveFileToolButton });
            this.FileToolButton.Name = "FileToolButton";
            this.FileToolButton.Size = new Size(48, 24);
            this.FileToolButton.Text = "Файл";
            // 
            // NewFileToolButton
            // 
            this.NewFileToolButton.Name = "NewFileToolButton";
            this.NewFileToolButton.Size = new Size(180, 22);
            this.NewFileToolButton.Text = "Новый";
            this.NewFileToolButton.Click += this.NewCanvasButtonClick;
            // 
            // OpenFileToolButton
            // 
            this.OpenFileToolButton.Name = "OpenFileToolButton";
            this.OpenFileToolButton.Size = new Size(180, 22);
            this.OpenFileToolButton.Text = "Открыть";
            this.OpenFileToolButton.Click += this.OpenCanvasButtonClick;
            // 
            // SaveFileToolButton
            // 
            this.SaveFileToolButton.Name = "SaveFileToolButton";
            this.SaveFileToolButton.Size = new Size(180, 22);
            this.SaveFileToolButton.Text = "Сохранить";
            this.SaveFileToolButton.Click += this.SaveCanvasButtonClick;
            // 
            // SettingsToolButton
            // 
            this.SettingsToolButton.DropDownItems.AddRange(new ToolStripItem[] { this.PenColorToolButton, this.PenSizeToolButton, this.BrushColorToolButton, this.FontToolButton });
            this.SettingsToolButton.Name = "SettingsToolButton";
            this.SettingsToolButton.Size = new Size(83, 24);
            this.SettingsToolButton.Text = "Параметры";
            // 
            // PenColorToolButton
            // 
            this.PenColorToolButton.Name = "PenColorToolButton";
            this.PenColorToolButton.Size = new Size(205, 22);
            this.PenColorToolButton.Text = "Изменить цвет кисти";
            this.PenColorToolButton.Click += this.PenColorButtonClick;
            // 
            // PenSizeToolButton
            // 
            this.PenSizeToolButton.Name = "PenSizeToolButton";
            this.PenSizeToolButton.Size = new Size(205, 22);
            this.PenSizeToolButton.Text = "Изменить размер кисти";
            this.PenSizeToolButton.Click += this.PenSizeButtonClick;
            // 
            // BrushColorToolButton
            // 
            this.BrushColorToolButton.Name = "BrushColorToolButton";
            this.BrushColorToolButton.Size = new Size(205, 22);
            this.BrushColorToolButton.Text = "Изменить цвет заливки";
            this.BrushColorToolButton.Click += this.BrushColorButtonClick;
            // 
            // FontToolButton
            // 
            this.FontToolButton.Name = "FontToolButton";
            this.FontToolButton.Size = new Size(205, 22);
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
            // StateToolButton
            // 
            this.StateToolButton.DropDownItems.AddRange(new ToolStripItem[] { this.DrawingToolButton, this.SelectionToolButton, this.EditToolButton });
            this.StateToolButton.Name = "StateToolButton";
            this.StateToolButton.Size = new Size(57, 24);
            this.StateToolButton.Text = "Режим";
            // 
            // DrawingToolButton
            // 
            this.DrawingToolButton.Name = "DrawingToolButton";
            this.DrawingToolButton.Size = new Size(163, 22);
            this.DrawingToolButton.Text = "Рисование";
            this.DrawingToolButton.Click += this.DrawingButtonClick;
            // 
            // SelectionToolButton
            // 
            this.SelectionToolButton.Name = "SelectionToolButton";
            this.SelectionToolButton.Size = new Size(163, 22);
            this.SelectionToolButton.Text = "Выделение";
            this.SelectionToolButton.Click += this.SelectionButtonClick;
            // 
            // EditToolButton
            // 
            this.EditToolButton.Name = "EditToolButton";
            this.EditToolButton.Size = new Size(163, 22);
            this.EditToolButton.Text = "Редактирование";
            // 
            // CoordinatToolButton
            // 
            this.CoordinatToolButton.DropDownItems.AddRange(new ToolStripItem[] { this.GridToolButton, this.GridStepToolButton, this.SnapToGridToolButton });
            this.CoordinatToolButton.Name = "CoordinatToolButton";
            this.CoordinatToolButton.Size = new Size(129, 24);
            this.CoordinatToolButton.Text = "Координатная сетка";
            // 
            // GridToolButton
            // 
            this.GridToolButton.Name = "GridToolButton";
            this.GridToolButton.Size = new Size(167, 22);
            this.GridToolButton.Text = "Сетка";
            this.GridToolButton.Click += this.GridToolButtonClick;
            // 
            // GridStepToolButton
            // 
            this.GridStepToolButton.DropDownItems.AddRange(new ToolStripItem[] { this.DefaultGridStepToolButton, this.MaxGridStepToolButton });
            this.GridStepToolButton.Name = "GridStepToolButton";
            this.GridStepToolButton.Size = new Size(167, 22);
            this.GridStepToolButton.Text = "Шаг сетки";
            // 
            // DefaultGridStepToolButton
            // 
            this.DefaultGridStepToolButton.Name = "DefaultGridStepToolButton";
            this.DefaultGridStepToolButton.Size = new Size(102, 22);
            this.DefaultGridStepToolButton.Text = "10 px";
            this.DefaultGridStepToolButton.Click += this.DefaultGridStepToolButtonClick;
            // 
            // MaxGridStepToolButton
            // 
            this.MaxGridStepToolButton.Name = "MaxGridStepToolButton";
            this.MaxGridStepToolButton.Size = new Size(102, 22);
            this.MaxGridStepToolButton.Text = "50 px";
            this.MaxGridStepToolButton.Click += this.MaxGridStepToolButtonClick;
            // 
            // SnapToGridToolButton
            // 
            this.SnapToGridToolButton.Name = "SnapToGridToolButton";
            this.SnapToGridToolButton.Size = new Size(167, 22);
            this.SnapToGridToolButton.Text = "Привязка к сетке";
            this.SnapToGridToolButton.Click += this.SnapToGridToolButtonClick;
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = Color.WhiteSmoke;
            this.StatusStrip.GripMargin = new Padding(0, 0, 0, 2);
            this.StatusStrip.Items.AddRange(new ToolStripItem[] { this.PointerInfo, this.CanvasInfo, this.FontInfo, this.PenInfo, this.BrushInfo });
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
            // PenInfo
            // 
            this.PenInfo.AutoSize = false;
            this.PenInfo.Image = (Image)resources.GetObject("PenInfo.Image");
            this.PenInfo.ImageAlign = ContentAlignment.MiddleLeft;
            this.PenInfo.Margin = new Padding(0, 0, 5, 0);
            this.PenInfo.Name = "PenInfo";
            this.PenInfo.Size = new Size(160, 24);
            this.PenInfo.TextAlign = ContentAlignment.MiddleLeft;
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
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = Color.White;
            this.ToolStrip.BackgroundImageLayout = ImageLayout.None;
            this.ToolStrip.CanOverflow = false;
            this.ToolStrip.GripMargin = new Padding(0);
            this.ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new Size(24, 24);
            this.ToolStrip.Items.AddRange(new ToolStripItem[] { this.NewFileButton, this.SaveFileButton, this.OpenFileButton, this.BrushGroupSeparator, this.PenDropDownButton, this.FillingDropDownButton, this.FuguresGroupSeparator, this.RectangleButton, this.EllipseButton, this.StraightLineButton, this.CurveLineButton, this.TextGroupSeparator, this.TextButton, this.FontButton, this.SelectionGroupSeparator, this.DrawingButton, this.SelectionButton, this.EditButton, this.CoordinateGridSeparator, this.CoordinatDownButton });
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
            this.NewFileButton.Click += this.NewCanvasButtonClick;
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
            this.SaveFileButton.Click += this.SaveCanvasButtonClick;
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
            this.OpenFileButton.Click += this.OpenCanvasButtonClick;
            // 
            // BrushGroupSeparator
            // 
            this.BrushGroupSeparator.Name = "BrushGroupSeparator";
            this.BrushGroupSeparator.Size = new Size(6, 32);
            // 
            // PenDropDownButton
            // 
            this.PenDropDownButton.AutoToolTip = false;
            this.PenDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.PenDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { this.PenColorButton, this.PenSizeButton });
            this.PenDropDownButton.Image = (Image)resources.GetObject("PenDropDownButton.Image");
            this.PenDropDownButton.ImageTransparentColor = Color.Magenta;
            this.PenDropDownButton.Margin = new Padding(0, 2, 2, 2);
            this.PenDropDownButton.Name = "PenDropDownButton";
            this.PenDropDownButton.Size = new Size(37, 28);
            // 
            // PenColorButton
            // 
            this.PenColorButton.Name = "PenColorButton";
            this.PenColorButton.Size = new Size(205, 22);
            this.PenColorButton.Text = "Изменить цвет кисти";
            this.PenColorButton.Click += this.PenColorButtonClick;
            // 
            // PenSizeButton
            // 
            this.PenSizeButton.Name = "PenSizeButton";
            this.PenSizeButton.Size = new Size(205, 22);
            this.PenSizeButton.Text = "Изменить размер кисти";
            this.PenSizeButton.Click += this.PenSizeButtonClick;
            // 
            // FillingDropDownButton
            // 
            this.FillingDropDownButton.AutoToolTip = false;
            this.FillingDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.FillingDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { this.FillingButton, this.BrushColorButton });
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
            // BrushColorButton
            // 
            this.BrushColorButton.Name = "BrushColorButton";
            this.BrushColorButton.Size = new Size(202, 22);
            this.BrushColorButton.Text = "Изменить цвет заливки";
            this.BrushColorButton.Click += this.BrushColorButtonClick;
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
            // CoordinateGridSeparator
            // 
            this.CoordinateGridSeparator.Name = "CoordinateGridSeparator";
            this.CoordinateGridSeparator.Size = new Size(6, 32);
            // 
            // CoordinatDownButton
            // 
            this.CoordinatDownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.CoordinatDownButton.DropDownItems.AddRange(new ToolStripItem[] { this.GridButton, this.GridStepButton, this.SnapToGridButton });
            this.CoordinatDownButton.Image = (Image)resources.GetObject("CoordinatDownButton.Image");
            this.CoordinatDownButton.ImageTransparentColor = Color.Magenta;
            this.CoordinatDownButton.Name = "CoordinatDownButton";
            this.CoordinatDownButton.Size = new Size(37, 29);
            this.CoordinatDownButton.Text = "Редактирование сетки ";
            // 
            // GridButton
            // 
            this.GridButton.Name = "GridButton";
            this.GridButton.Size = new Size(167, 22);
            this.GridButton.Text = "Сетка";
            this.GridButton.Click += this.GridToolButtonClick;
            // 
            // GridStepButton
            // 
            this.GridStepButton.DropDownItems.AddRange(new ToolStripItem[] { this.DefaultGridStepButton, this.MaxGridStepButton });
            this.GridStepButton.Name = "GridStepButton";
            this.GridStepButton.Size = new Size(167, 22);
            this.GridStepButton.Text = "Шаг сетки";
            // 
            // DefaultGridStepButton
            // 
            this.DefaultGridStepButton.Name = "DefaultGridStepButton";
            this.DefaultGridStepButton.Size = new Size(102, 22);
            this.DefaultGridStepButton.Text = "10 px";
            this.DefaultGridStepButton.Click += this.DefaultGridStepToolButtonClick;
            // 
            // MaxGridStepButton
            // 
            this.MaxGridStepButton.Name = "MaxGridStepButton";
            this.MaxGridStepButton.Size = new Size(102, 22);
            this.MaxGridStepButton.Text = "50 px";
            this.MaxGridStepButton.Click += this.MaxGridStepToolButtonClick;
            // 
            // SnapToGridButton
            // 
            this.SnapToGridButton.Name = "SnapToGridButton";
            this.SnapToGridButton.Size = new Size(167, 22);
            this.SnapToGridButton.Text = "Привязка к сетке";
            this.SnapToGridButton.Click += this.SnapToGridToolButtonClick;
            // 
            // FigureTableButton
            // 
            this.FigureTableButton.Name = "FigureTableButton";
            this.FigureTableButton.Size = new Size(126, 24);
            this.FigureTableButton.Text = "Фигуры на рисунке";
            this.FigureTableButton.Click += this.FigureTableButtonClick;
            // 
            // UiMainWindow
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1264, 681);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
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
        private ToolStripMenuItem FileToolButton;
        private ToolStripMenuItem NewFileToolButton;
        private ToolStripMenuItem OpenFileToolButton;
        private ToolStripMenuItem SaveFileToolButton;
        private ToolStripMenuItem SettingsToolButton;
        private ToolStripMenuItem PenColorToolButton;
        private ToolStripMenuItem PenSizeToolButton;
        private ToolStripMenuItem BrushColorToolButton;
        private ToolStripMenuItem FigureToolButton;
        private ToolStripMenuItem RectangleToolButton;
        private ToolStripMenuItem EllipseToolButton;
        private ToolStripMenuItem StraightLineToolButton;
        private ToolStripMenuItem CurveLineToolButton;
        private ToolStripMenuItem FillingToolButton;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel BrushInfo;
        private ToolStripStatusLabel CanvasInfo;
        private ToolStripStatusLabel PenInfo;
		private ToolStripStatusLabel PointerInfo;
        private ToolStrip ToolStrip;
        private ToolStripButton NewFileButton;
        private ToolStripButton SaveFileButton;
        private ToolStripButton OpenFileButton;
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
        private ToolStripMenuItem StateToolButton;
        private ToolStripMenuItem DrawingToolButton;
        private ToolStripMenuItem EditToolButton;
        private ToolStripDropDownButton PenDropDownButton;
        private ToolStripMenuItem PenColorButton;
        private ToolStripMenuItem PenSizeButton;
        private ToolStripDropDownButton FillingDropDownButton;
        private ToolStripMenuItem FillingButton;
        private ToolStripMenuItem BrushColorButton;
        private ToolStripButton DrawingButton;
        private ToolStripButton EditButton;
        private ToolStripSeparator CoordinateGridSeparator;
        private ToolStripDropDownButton CoordinatDownButton;
        private ToolStripMenuItem CoordinatToolButton;
        private ToolStripMenuItem GridToolButton;
        private ToolStripMenuItem GridStepToolButton;
        private ToolStripMenuItem SnapToGridToolButton;
        private ToolStripMenuItem GridButton;
        private ToolStripMenuItem GridStepButton;
        private ToolStripMenuItem SnapToGridButton;
        private ToolStripMenuItem DefaultGridStepToolButton;
        private ToolStripMenuItem MaxGridStepToolButton;
        private ToolStripMenuItem DefaultGridStepButton;
        private ToolStripMenuItem MaxGridStepButton;
        private ToolStripMenuItem FigureTableButton;
    }
}
