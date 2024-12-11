namespace Paint.UI;

partial class UiEditTable {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(UiEditTable));
        this.OkButton = new System.Windows.Forms.Button();
        this.button4 = new System.Windows.Forms.Button();
        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        this.DeleteButton = new System.Windows.Forms.ToolStripMenuItem();
        this.AddButton = new System.Windows.Forms.ToolStripMenuItem();
        this.RectangleButton = new System.Windows.Forms.ToolStripMenuItem();
        this.EllipseButton = new System.Windows.Forms.ToolStripMenuItem();
        this.StraightLineButton = new System.Windows.Forms.ToolStripMenuItem();
        this.CurveLineButton = new System.Windows.Forms.ToolStripMenuItem();
        this.PenSizeButton = new System.Windows.Forms.ToolStripMenuItem();
        this.PenColorButton = new System.Windows.Forms.ToolStripMenuItem();
        this.BrushColorButton = new System.Windows.Forms.ToolStripMenuItem();
        this.FontButton = new System.Windows.Forms.ToolStripMenuItem();
        this.textBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.ColorDialog = new System.Windows.Forms.ColorDialog();
        this.CoordinateBox = new System.Windows.Forms.GroupBox();
        this.CoordinateY = new System.Windows.Forms.Label();
        this.CoordinateX = new System.Windows.Forms.Label();
        this.TextY = new System.Windows.Forms.TextBox();
        this.TextX = new System.Windows.Forms.TextBox();
        this.MoveButton = new System.Windows.Forms.Button();
        this.FontDialog = new System.Windows.Forms.FontDialog();
        this.menuStrip1.SuspendLayout();
        this.CoordinateBox.SuspendLayout();
        this.SuspendLayout();
        // 
        // OkButton
        // 
        this.OkButton.Location = new System.Drawing.Point(12, 252);
        this.OkButton.Name = "OkButton";
        this.OkButton.Size = new System.Drawing.Size(92, 38);
        this.OkButton.TabIndex = 2;
        this.OkButton.Text = "Ok";
        this.OkButton.UseVisualStyleBackColor = true;
        this.OkButton.Click += this.OkButtonClick;
        // 
        // button4
        // 
        this.button4.Location = new System.Drawing.Point(191, 252);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(100, 38);
        this.button4.TabIndex = 3;
        this.button4.Text = "Save";
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += this.SaveButtonClick;
        // 
        // menuStrip1
        // 
        this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
        this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.DeleteButton, this.AddButton, this.PenSizeButton, this.PenColorButton, this.BrushColorButton, this.FontButton, this.textBoxToolStripMenuItem });
        this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new System.Drawing.Size(79, 302);
        this.menuStrip1.TabIndex = 4;
        this.menuStrip1.Text = "menuStrip1";
        // 
        // DeleteButton
        // 
        this.DeleteButton.Name = "DeleteButton";
        this.DeleteButton.Size = new System.Drawing.Size(72, 19);
        this.DeleteButton.Text = "Delete";
        this.DeleteButton.Click += this.DeleteButtonClick;
        // 
        // AddButton
        // 
        this.AddButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.RectangleButton, this.EllipseButton, this.StraightLineButton, this.CurveLineButton });
        this.AddButton.Name = "AddButton";
        this.AddButton.Size = new System.Drawing.Size(72, 19);
        this.AddButton.Text = "Add";
        // 
        // RectangleButton
        // 
        this.RectangleButton.Name = "RectangleButton";
        this.RectangleButton.Size = new System.Drawing.Size(137, 22);
        this.RectangleButton.Text = "Rectangle";
        this.RectangleButton.Click += this.RectangleButtonClick;
        // 
        // EllipseButton
        // 
        this.EllipseButton.Name = "EllipseButton";
        this.EllipseButton.Size = new System.Drawing.Size(137, 22);
        this.EllipseButton.Text = "Ellipse";
        this.EllipseButton.Click += this.EllipseButtonClick;
        // 
        // StraightLineButton
        // 
        this.StraightLineButton.Name = "StraightLineButton";
        this.StraightLineButton.Size = new System.Drawing.Size(137, 22);
        this.StraightLineButton.Text = "StraightLine";
        this.StraightLineButton.Click += this.StraightLineClick;
        // 
        // CurveLineButton
        // 
        this.CurveLineButton.Name = "CurveLineButton";
        this.CurveLineButton.Size = new System.Drawing.Size(137, 22);
        this.CurveLineButton.Text = "CurveLine";
        this.CurveLineButton.Click += this.CurveLineClick;
        // 
        // PenSizeButton
        // 
        this.PenSizeButton.Name = "PenSizeButton";
        this.PenSizeButton.Size = new System.Drawing.Size(72, 19);
        this.PenSizeButton.Text = "PenSize";
        this.PenSizeButton.Click += this.PenSizeClick;
        // 
        // PenColorButton
        // 
        this.PenColorButton.Name = "PenColorButton";
        this.PenColorButton.Size = new System.Drawing.Size(72, 19);
        this.PenColorButton.Text = "Pen Color";
        this.PenColorButton.Click += this.PenColorClick;
        // 
        // BrushColorButton
        // 
        this.BrushColorButton.Name = "BrushColorButton";
        this.BrushColorButton.Size = new System.Drawing.Size(72, 19);
        this.BrushColorButton.Text = "Back Color";
        this.BrushColorButton.Click += this.BrushColorButtonClick;
        // 
        // FontButton
        // 
        this.FontButton.Name = "FontButton";
        this.FontButton.Size = new System.Drawing.Size(72, 19);
        this.FontButton.Text = "Font";
        this.FontButton.Click += this.FontButtonClick;
        // 
        // textBoxToolStripMenuItem
        // 
        this.textBoxToolStripMenuItem.Name = "textBoxToolStripMenuItem";
        this.textBoxToolStripMenuItem.Size = new System.Drawing.Size(72, 19);
        this.textBoxToolStripMenuItem.Text = "TextBox";
        this.textBoxToolStripMenuItem.Click += this.TextBoxButtonClick;
        // 
        // CoordinateBox
        // 
        this.CoordinateBox.Controls.Add(this.CoordinateY);
        this.CoordinateBox.Controls.Add(this.CoordinateX);
        this.CoordinateBox.Controls.Add(this.TextY);
        this.CoordinateBox.Controls.Add(this.TextX);
        this.CoordinateBox.Location = new System.Drawing.Point(93, 12);
        this.CoordinateBox.Name = "CoordinateBox";
        this.CoordinateBox.Size = new System.Drawing.Size(209, 84);
        this.CoordinateBox.TabIndex = 5;
        this.CoordinateBox.TabStop = false;
        this.CoordinateBox.Text = "Координаты выделенной фигуры";
        // 
        // CoordinateY
        // 
        this.CoordinateY.AutoSize = true;
        this.CoordinateY.Location = new System.Drawing.Point(91, 40);
        this.CoordinateY.Name = "CoordinateY";
        this.CoordinateY.Size = new System.Drawing.Size(14, 15);
        this.CoordinateY.TabIndex = 3;
        this.CoordinateY.Text = "Y";
        // 
        // CoordinateX
        // 
        this.CoordinateX.AutoSize = true;
        this.CoordinateX.Location = new System.Drawing.Point(6, 40);
        this.CoordinateX.Name = "CoordinateX";
        this.CoordinateX.Size = new System.Drawing.Size(14, 15);
        this.CoordinateX.TabIndex = 2;
        this.CoordinateX.Text = "X";
        // 
        // TextY
        // 
        this.TextY.Location = new System.Drawing.Point(110, 37);
        this.TextY.Name = "TextY";
        this.TextY.Size = new System.Drawing.Size(62, 23);
        this.TextY.TabIndex = 1;
        // 
        // TextX
        // 
        this.TextX.Location = new System.Drawing.Point(23, 37);
        this.TextX.Name = "TextX";
        this.TextX.Size = new System.Drawing.Size(62, 23);
        this.TextX.TabIndex = 0;
        // 
        // MoveButton
        // 
        this.MoveButton.Location = new System.Drawing.Point(143, 102);
        this.MoveButton.Name = "MoveButton";
        this.MoveButton.Size = new System.Drawing.Size(100, 38);
        this.MoveButton.TabIndex = 6;
        this.MoveButton.Text = "Move";
        this.MoveButton.UseVisualStyleBackColor = true;
        this.MoveButton.Click += this.MoveButtonClick;
        // 
        // UiEditTable
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(303, 302);
        this.Controls.Add(this.MoveButton);
        this.Controls.Add(this.CoordinateBox);
        this.Controls.Add(this.button4);
        this.Controls.Add(this.OkButton);
        this.Controls.Add(this.menuStrip1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
        this.MainMenuStrip = this.menuStrip1;
        this.Name = "UiEditTable";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "UiEditTable";
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.CoordinateBox.ResumeLayout(false);
        this.CoordinateBox.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
    private System.Windows.Forms.Button OkButton;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem DeleteButton;
    private System.Windows.Forms.ToolStripMenuItem AddButton;
    private System.Windows.Forms.ToolStripMenuItem RectangleButton;
    private System.Windows.Forms.ToolStripMenuItem EllipseButton;
    private System.Windows.Forms.ToolStripMenuItem StraightLineButton;
    private System.Windows.Forms.ToolStripMenuItem CurveLineButton;
    private System.Windows.Forms.ToolStripMenuItem PenColorButton;
    private System.Windows.Forms.ToolStripMenuItem PenSizeButton;
    private System.Windows.Forms.ToolStripMenuItem FontButton;
    private System.Windows.Forms.ColorDialog ColorDialog;
    private System.Windows.Forms.ToolStripMenuItem BrushColorButton;
    private System.Windows.Forms.GroupBox CoordinateBox;
    private System.Windows.Forms.TextBox TextX;
    private System.Windows.Forms.ToolStripMenuItem textBoxToolStripMenuItem;
    private System.Windows.Forms.Label CoordinateY;
    private System.Windows.Forms.Label CoordinateX;
    private System.Windows.Forms.TextBox TextY;
    private System.Windows.Forms.Button MoveButton;
    private System.Windows.Forms.FontDialog FontDialog;
}