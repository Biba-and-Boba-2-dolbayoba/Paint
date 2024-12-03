
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UxBrushSize));
            this.OkButton = new Button();
            this.DeclineButton = new Button();
            this.BrushSizeNumericForm = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)this.BrushSizeNumericForm).BeginInit();
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
            // DeclineButton
            // 
            this.DeclineButton.Location = new Point(192, 78);
            this.DeclineButton.Margin = new Padding(4, 3, 4, 3);
            this.DeclineButton.Name = "DeclineButton";
            this.DeclineButton.Size = new Size(88, 27);
            this.DeclineButton.TabIndex = 1;
            this.DeclineButton.Text = "Cancel";
            this.DeclineButton.UseVisualStyleBackColor = true;
            this.DeclineButton.Click += this.DeclineButtonClick;
            // 
            // BrushSizeNumericForm
            // 
            this.BrushSizeNumericForm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.BrushSizeNumericForm.Location = new Point(47, 21);
            this.BrushSizeNumericForm.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            this.BrushSizeNumericForm.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.BrushSizeNumericForm.Name = "BrushSizeNumericForm";
            this.BrushSizeNumericForm.Size = new Size(233, 29);
            this.BrushSizeNumericForm.TabIndex = 3;
            this.BrushSizeNumericForm.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // UxBrushSize
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(331, 117);
            this.Controls.Add(this.BrushSizeNumericForm);
            this.Controls.Add(this.DeclineButton);
            this.Controls.Add(this.OkButton);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(4, 3, 4, 3);
            this.Name = "UxBrushSize";
            this.Text = "Изменение размера кисти";
            ((System.ComponentModel.ISupportInitialize)this.BrushSizeNumericForm).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button DeclineButton;
        private NumericUpDown BrushSizeNumericForm;
    }
}