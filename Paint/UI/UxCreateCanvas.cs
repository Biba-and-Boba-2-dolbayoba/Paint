using System.ComponentModel;

namespace Paint;

[Serializable()]
public partial class UxCreateCanvas : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static string CanvasWidth { get; private set; } = "320";

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static string CanvasHeight { get; private set; } = "240";

    public UxCreateCanvas() {
        this.InitializeComponent();
    }

    private void SizeSmallButtonCheckedChanged(object sender, EventArgs e) {
        CanvasHeight = "240";
        CanvasWidth = "320";
    }

    private void SizeAverageButtonCheckedChanged(object sender, EventArgs e) {
        CanvasHeight = "480";
        CanvasWidth = "640";
    }

    private void SizeBigButtonCheckedChanged(object sender, EventArgs e) {
        CanvasHeight = "600";
        CanvasWidth = "800";
    }

    private void OkButtonClick(object sender, EventArgs e) {
        if (this.ManualSelectionCheckBox.Checked) {
            CanvasHeight = this.HeightTextBox.Text;
            CanvasWidth = this.WidthTextBox.Text;
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void CancelButtonClick(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
