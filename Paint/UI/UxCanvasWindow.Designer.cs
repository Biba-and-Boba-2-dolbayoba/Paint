
namespace Paint
{
    partial class UxCanvasWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UxCanvasWindow));
            this.SuspendLayout();
            // 
            // UxCanvasWindow
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightGray;
            this.ClientSize = new Size(915, 637);
            this.DoubleBuffered = true;
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(4, 4, 4, 4);
            this.Name = "UxCanvasWindow";
            this.Text = "Canvas";
            this.FormClosing += this.CloseHandler;
            this.Load += this.LoadHandler;
            this.Paint += this.PaintHandler;
            this.MouseDown += this.MouseDownHandler;
            this.MouseMove += this.MouseMoveHandler;
            this.MouseUp += this.MouseUpHandler;
            this.ResumeLayout(false);
        }

        #endregion
    }
}