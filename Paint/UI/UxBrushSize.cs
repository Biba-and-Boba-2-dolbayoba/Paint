using System.ComponentModel;

namespace Paint;

public partial class UxBrushSize : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int BrushSize { get; private set; } = 2;

    public UxBrushSize() {
        this.InitializeComponent();

        this.BrushSizeNumericForm.Value = BrushSize;
    }

    private void OkButtonClick(object sender, EventArgs e) {
        BrushSize = (int) this.BrushSizeNumericForm.Value;
        this.Close();
    }

    private void DeclineButtonClick(object sender, EventArgs e) {
        this.Close();
    }
}
