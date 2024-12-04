namespace Paint;

public partial class UiBrushSize : Form {
    public UiBrushSize() {
        this.InitializeComponent();

        this.BrushSizeNumericForm.Value = 2;
    }

    private void OkButtonClick(object sender, EventArgs e) {
        int brushSize = (int)this.BrushSizeNumericForm.Value;
        if (this.MdiParent is UiMainWindow activeForm) {
            _ = activeForm.Invoke(activeForm.UpdateBrushInfo, activeForm.BrushColor, brushSize);
        }

        this.Close();
    }

    private void DeclineButtonClick(object sender, EventArgs e) {
        this.Close();
    }
}
