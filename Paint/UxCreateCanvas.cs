using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    [Serializable()] public partial class UxCreateCanvas : Form
    {
        public static string height;
        public static string width;

        public UxCreateCanvas()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        public static string getSizeWidth()
        {
            return width;
        }

        public static string getSizeHeight()
        {
            return height;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            height = "240";
            width = "320";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            height = "480";
            width = "640";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            height = "600";
            width = "800";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                height = this.textBox1.Text;
                width = this.textBox2.Text;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
