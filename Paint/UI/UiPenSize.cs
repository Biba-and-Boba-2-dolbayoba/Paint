namespace Paint;

internal partial class UiPenSize : Form {
    private Color PenColor { get; set; }
    private UiMainWindow MainWindow { get; set; }

    public UiPenSize(UiMainWindow mainWindow, Color penColor) {
        this.InitializeComponent();

        this.PenColor = penColor;
        this.MainWindow = mainWindow;
        this.PenSizeNumericForm.Value = 2;
    }

    private void OkButtonClick(object sender, EventArgs e) {
        int penSize = (int)this.PenSizeNumericForm.Value;

        this.MainWindow.UpdatePenInfo(this.PenColor, penSize);

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void DeclineButtonClick(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
