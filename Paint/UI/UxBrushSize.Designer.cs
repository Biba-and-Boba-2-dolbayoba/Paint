
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
            this.OkButton = new Button();
            this.DeclineButton = new Button();
            this.BrushSizeComboBox = new ComboBox();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new Point(47, 76);
            this.OkButton.Margin = new Padding(4, 3, 4, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new Size(88, 27);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += this.OkButtonClick;
            // 
            // CancelButton
            // 
            this.DeclineButton.Location = new Point(192, 78);
            this.DeclineButton.Margin = new Padding(4, 3, 4, 3);
            this.DeclineButton.Name = "CancelButton";
            this.DeclineButton.Size = new Size(88, 27);
            this.DeclineButton.TabIndex = 1;
            this.DeclineButton.Text = "Cancel";
            this.DeclineButton.UseVisualStyleBackColor = true;
            this.DeclineButton.Click += this.DeclineButtonClick;
            // 
            // BrushSizeComboBox
            // 
            this.BrushSizeComboBox.Items.AddRange(new object[] { "1", "2", "5", "8", "10", "12", "15" });
            this.BrushSizeComboBox.Location = new Point(47, 14);
            this.BrushSizeComboBox.Margin = new Padding(4, 3, 4, 3);
            this.BrushSizeComboBox.Name = "BrushSizeComboBox";
            this.BrushSizeComboBox.Size = new Size(233, 23);
            this.BrushSizeComboBox.TabIndex = 2;
            // 
            // UxBrushSize
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(331, 117);
            this.Controls.Add(this.BrushSizeComboBox);
            this.Controls.Add(this.DeclineButton);
            this.Controls.Add(this.OkButton);
            this.Margin = new Padding(4, 3, 4, 3);
            this.Name = "UxBrushSize";
            this.Text = "Изменение размера кисти";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button DeclineButton;
        private System.Windows.Forms.ComboBox BrushSizeComboBox;
    }
}