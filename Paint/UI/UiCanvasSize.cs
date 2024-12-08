using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint;

internal partial class UiCanvasSize : Form {
    private Size CanvasSize  { get; set; } = new Size(320, 240);
    private UiMainWindow MainWindow { get; set; }

    public UiCanvasSize(UiMainWindow mainWindow) {
        this.InitializeComponent();
        this.MainWindow = mainWindow;
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
            try {
                this.CanvasSize = new Size(int.Parse(this.WidthTextBox.Text), int.Parse(this.HeightTextBox.Text));
            } catch (FormatException exception) {
                _ = MessageBox.Show($"Ошибка при создании холста: {exception.Message}");
            }
        }

        this.MainWindow.UpdateCanvasInfo(this.CanvasSize);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void DeclineButtonClick(object sender, EventArgs e) {
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
