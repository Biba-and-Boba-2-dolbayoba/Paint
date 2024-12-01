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

    private void Form4_Load(object sender, EventArgs e) {

    }

    public static string getSizeWidth() {
        return CanvasWidth;
    }

    public static string getSizeHeight() {
        return CanvasHeight;
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e) {
        CanvasHeight = "240";
        CanvasWidth = "320";
    }
    private void radioButton2_CheckedChanged(object sender, EventArgs e) {
        CanvasHeight = "480";
        CanvasWidth = "640";
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e) {
        CanvasHeight = "600";
        CanvasWidth = "800";
    }

    private void label1_Click(object sender, EventArgs e) {

    }

    private void label2_Click(object sender, EventArgs e) {

    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e) {

    }

    private void label3_Click(object sender, EventArgs e) {

    }

    private void textBox1_TextChanged(object sender, EventArgs e) {

    }

    private void textBox2_TextChanged(object sender, EventArgs e) {

    }

    public void button1_Click(object sender, EventArgs e) {
        if (this.checkBox1.Checked) {
            CanvasHeight = this.textBox1.Text;
            CanvasWidth = this.textBox2.Text;
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void button2_Click(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void radioButton1_Click(object sender, EventArgs e) {

    }

    private void radioButton2_Click(object sender, EventArgs e) {

    }

    private void radioButton3_Click(object sender, EventArgs e) {

    }

    private void groupBox1_Enter(object sender, EventArgs e) {

    }
}
