
namespace Paint
{
    partial class UxBrushSize
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new Button();
            this.button2 = new Button();
            this.comboBox1 = new ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new Point(47, 76);
            this.button1.Margin = new Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new Size(88, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += this.button1_Click;
            // 
            // button2
            // 
            this.button2.Location = new Point(192, 76);
            this.button2.Margin = new Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new Size(88, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += this.button2_Click;
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] { "1", "2", "5", "8", "10", "12", "15" });
            this.comboBox1.Location = new Point(47, 14);
            this.comboBox1.Margin = new Padding(4, 3, 4, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(233, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // UxBrushSize
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(331, 117);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new Padding(4, 3, 4, 3);
            this.Name = "UxBrushSize";
            this.Text = "Изменение размера кисти";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}