using Paint.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint;

internal partial class PenSizeForm : Form {
    private Color PenColor { get; set; }
    private Form MainWindow { get; set; }

    public PenSizeForm(MainForm mainWindow, Color penColor) {
        this.InitializeComponent();

        this.PenColor = penColor;
        this.MainWindow = mainWindow;
        this.PenSizeNumericForm.Value = 2;
    }

    public PenSizeForm(EditForm uiEditTable, Color penColor) {
        this.InitializeComponent();

        this.PenColor = penColor;
        this.MainWindow = uiEditTable;
        this.PenSizeNumericForm.Value = 2;
    }

    private void OkButtonClick(object sender, EventArgs e) {
        int penSize = (int)this.PenSizeNumericForm.Value;
        if (this.MainWindow is MainForm mainWindow) {
            mainWindow.UpdatePenInfo(this.PenColor, penSize);
        }

        if (this.MainWindow is EditForm uiEditTable) {
            uiEditTable.PenSize = penSize;
        }

        this.DialogResult = DialogResult.OK;
        this.Close();

    }

    private void DeclineButtonClick(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
