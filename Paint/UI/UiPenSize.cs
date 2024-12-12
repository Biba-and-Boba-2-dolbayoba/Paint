using Paint.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint;

internal partial class UiPenSize : Form {
    private Color PenColor { get; set; }
    private Form MainWindow { get; set; }


    public UiPenSize(UiMainWindow mainWindow, Color penColor) {
        this.InitializeComponent();

        this.PenColor = penColor;
        this.MainWindow = mainWindow;
        this.PenSizeNumericForm.Value = 2;
    }

    public UiPenSize(UiEditTable uiEditTable, Color penColor) {
        this.InitializeComponent();

        this.PenColor = penColor;
        this.MainWindow = uiEditTable;
        this.PenSizeNumericForm.Value = 2;
    }

    private void OkButtonClick(object sender, EventArgs e) {
        int penSize = (int)this.PenSizeNumericForm.Value;
        if (this.MainWindow is UiMainWindow mainWindow) {
            mainWindow.UpdatePenInfo(this.PenColor, penSize);
        }
        if (this.MainWindow is UiEditTable uiEditTable) {
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
