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

        this.CanvasSize = new Size(0, 0);
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void ManualSelectionCheckBoxCheckedChanged(object sender, EventArgs e) {
        bool isChecked = this.ManualSelectionCheckBox.Checked;
        this.WidthTextBox.Enabled = isChecked;
        this.HeightTextBox.Enabled = isChecked;


        if (!isChecked) {
            this.WidthTextBox.Text = "320";
            this.HeightTextBox.Text = "240";
        }

        this.SizeSmallButton.Enabled = !isChecked;
        this.SizeAverageButton.Enabled = !isChecked;
        this.SizeBigButton.Enabled = !isChecked;


        if (isChecked) {
            this.SizeSmallButton.Checked = false;
            this.SizeAverageButton.Checked = false;
            this.SizeBigButton.Checked = false;
        }
    }

   
}
