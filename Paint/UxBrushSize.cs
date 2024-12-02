namespace Paint;

public partial class UxBrushSize : Form {
    public static int pix = 1;

    public UxBrushSize() {
        this.InitializeComponent();

        this.comboBox1.Text = Convert.ToString(pix);

    }

    private void button1_Click(object sender, EventArgs e) {
        pix = Convert.ToInt32(this.comboBox1.Text);
        this.Close();
    }

    private void button2_Click(object sender, EventArgs e) {
        this.Close();
    }
}
