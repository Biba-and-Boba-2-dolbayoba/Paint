using System.ComponentModel;

namespace Paint;

public partial class UxBrushSize : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int BrushSize { get; private set; } = 1;

    public UxBrushSize() {
        this.InitializeComponent();

        this.BrushSizeComboBox.Text = Convert.ToString(BrushSize);

    }

    private void OkButtonClick(object sender, EventArgs e) {
        BrushSize = Convert.ToInt32(this.BrushSizeComboBox.Text);
        this.Close();
    }

    private void DeclineButtonClick(object sender, EventArgs e) {
        this.Close();
    }
}
