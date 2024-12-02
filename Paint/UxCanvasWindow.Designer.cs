
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
            this.SuspendLayout();
            // 
            // UxCanvasWindow
            // 
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.LightGray;
            this.ClientSize = new Size(1307, 1079);
            this.DoubleBuffered = true;
            this.Margin = new Padding(5, 6, 5, 6);
            this.Name = "UxCanvasWindow";
            this.Text = "Canvas";
            this.Activated += this.CanvasWindowActivated;
            this.FormClosing += this.CanvasWindowClose;
            this.Load += this.CanvasWindowLoad;
            this.Paint += this.CanvasWindowPaint;
            this.MouseDown += this.CanvasWindowMouseDown;
            this.MouseMove += this.CanvasWindowMouseMove;
            this.MouseUp += this.CanvvasWindowMouseUp;
            this.ResumeLayout(false);
        }

        #endregion
    }
}