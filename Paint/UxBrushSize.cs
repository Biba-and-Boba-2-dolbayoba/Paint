namespace Paint;

public partial class UxBrushSize : Form {
    public static int pix = 1;

    public UxBrushSize() {
        this.InitializeComponent();

        this.BrushSizeComboBox.Text = Convert.ToString(pix);

    }

    private void OkButtonClick(object sender, EventArgs e) {
        pix = Convert.ToInt32(this.BrushSizeComboBox.Text);
        this.Close();
    }

    private void CancelButtonClick(object sender, EventArgs e) {
        this.Close();
    }
}
