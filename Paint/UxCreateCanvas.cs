namespace Paint;

[Serializable()]
public partial class UxCreateCanvas : Form {
    public static required string height;
    public static required string width;

    public UxCreateCanvas() {
        this.InitializeComponent();
    }

    private void Form4_Load(object sender, EventArgs e) {

    }

    public static string getSizeWidth() {
        return width;
    }

    public static string getSizeHeight() {
        return height;
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e) {
        height = "240";
        width = "320";
    }
    private void radioButton2_CheckedChanged(object sender, EventArgs e) {
        height = "480";
        width = "640";
    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e) {
        height = "600";
        width = "800";
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
            height = this.textBox1.Text;
            width = this.textBox2.Text;
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
