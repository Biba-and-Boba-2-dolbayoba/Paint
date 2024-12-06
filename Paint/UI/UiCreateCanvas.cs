using System.ComponentModel;

namespace Paint;

[Serializable()]
internal partial class UiCreateCanvas : Form {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Size CanvasSize { get; private set; } = new Size(320, 240);

    public UiCreateCanvas() {
        this.InitializeComponent();
    }

    private void SizeSmallButtonCheckedChanged(object sender, EventArgs e) {
        this.CanvasSize = new Size(320, 240);
    }

    private void SizeAverageButtonCheckedChanged(object sender, EventArgs e) {
        this.CanvasSize = new Size(640, 480);
    }

    private void SizeBigButtonCheckedChanged(object sender, EventArgs e) {
        this.CanvasSize = new Size(800, 600);
    }

    private void OkButtonClick(object sender, EventArgs e) {
        if (this.ManualSelectionCheckBox.Checked) {
            this.CanvasSize = new Size(int.Parse(this.WidthTextBox.Text), int.Parse(this.HeightTextBox.Text));
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void CancelButtonClick(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
