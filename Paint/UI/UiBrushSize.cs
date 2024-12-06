using System.ComponentModel;

namespace Paint;

internal partial class UiBrushSize : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color PenColor { get; set; }

    public UiBrushSize() {
        this.InitializeComponent();

        this.BrushSizeNumericForm.Value = 2;
    }

    private void OkButtonClick(object sender, EventArgs e) {
        int penSize = (int)this.BrushSizeNumericForm.Value;
        if (this.MdiParent is UiMainWindow activeForm) {
            activeForm.UpdatePenInfo(this.PenColor, penSize);
        }

        this.Close();
    }

    private void DeclineButtonClick(object sender, EventArgs e) {
        this.Close();
    }
}
