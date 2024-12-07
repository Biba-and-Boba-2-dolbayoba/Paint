
namespace Paint
{
    partial class UiCreateCanvas
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UiCreateCanvas));
            this.SizeSmallButton = new RadioButton();
            this.SizeAverageButton = new RadioButton();
            this.SizeBigButton = new RadioButton();
            this.ManualSelectionCheckBox = new CheckBox();
            this.HeightTextBox = new TextBox();
            this.WidthTextBox = new TextBox();
            this.HeightLabel = new Label();
            this.WidthLabel = new Label();
            this.OkButton = new Button();
            this.DeclineButton = new Button();
            this.CreateCanvasGroupBox = new GroupBox();
            this.CreateCanvasGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SizeSmallButton
            // 
            this.SizeSmallButton.AutoSize = true;
            this.SizeSmallButton.Checked = true;
            this.SizeSmallButton.Location = new Point(10, 22);
            this.SizeSmallButton.Margin = new Padding(4, 3, 4, 3);
            this.SizeSmallButton.Name = "SizeSmallButton";
            this.SizeSmallButton.Size = new Size(67, 19);
            this.SizeSmallButton.TabIndex = 0;
            this.SizeSmallButton.TabStop = true;
            this.SizeSmallButton.Text = "320x240";
            this.SizeSmallButton.UseVisualStyleBackColor = true;
            this.SizeSmallButton.CheckedChanged += this.SizeSmallButtonCheckedChanged;
            // 
            // SizeAverageButton
            // 
            this.SizeAverageButton.AutoSize = true;
            this.SizeAverageButton.Location = new Point(173, 22);
            this.SizeAverageButton.Margin = new Padding(4, 3, 4, 3);
            this.SizeAverageButton.Name = "SizeAverageButton";
            this.SizeAverageButton.Size = new Size(67, 19);
            this.SizeAverageButton.TabIndex = 1;
            this.SizeAverageButton.Text = "640x480";
            this.SizeAverageButton.UseVisualStyleBackColor = true;
            this.SizeAverageButton.CheckedChanged += this.SizeAverageButtonCheckedChanged;
            // 
            // SizeBigButton
            // 
            this.SizeBigButton.AutoSize = true;
            this.SizeBigButton.Location = new Point(332, 22);
            this.SizeBigButton.Margin = new Padding(4, 3, 4, 3);
            this.SizeBigButton.Name = "SizeBigButton";
            this.SizeBigButton.Size = new Size(67, 19);
            this.SizeBigButton.TabIndex = 2;
            this.SizeBigButton.Text = "800x600";
            this.SizeBigButton.UseVisualStyleBackColor = true;
            this.SizeBigButton.CheckedChanged += this.SizeBigButtonCheckedChanged;
            // 
            // ManualSelectionCheckBox
            // 
            this.ManualSelectionCheckBox.AutoSize = true;
            this.ManualSelectionCheckBox.CheckAlign = ContentAlignment.MiddleRight;
            this.ManualSelectionCheckBox.Location = new Point(40, 110);
            this.ManualSelectionCheckBox.Margin = new Padding(4, 3, 4, 3);
            this.ManualSelectionCheckBox.Name = "ManualSelectionCheckBox";
            this.ManualSelectionCheckBox.Size = new Size(187, 19);
            this.ManualSelectionCheckBox.TabIndex = 5;
            this.ManualSelectionCheckBox.Text = "Ручной выбор размера окна:";
            this.ManualSelectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new Point(248, 135);
            this.HeightTextBox.Margin = new Padding(4, 3, 4, 3);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new Size(116, 23);
            this.HeightTextBox.TabIndex = 6;
            this.HeightTextBox.Text = "320";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new Point(372, 135);
            this.WidthTextBox.Margin = new Padding(4, 3, 4, 3);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new Size(116, 23);
            this.WidthTextBox.TabIndex = 7;
            this.WidthTextBox.Text = "240";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new Point(248, 110);
            this.HeightLabel.Margin = new Padding(4, 0, 4, 0);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new Size(50, 15);
            this.HeightLabel.TabIndex = 8;
            this.HeightLabel.Text = "Высота:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new Point(372, 110);
            this.WidthLabel.Margin = new Padding(4, 0, 4, 0);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new Size(55, 15);
            this.WidthLabel.TabIndex = 9;
            this.WidthLabel.Text = "Ширина:";
            // 
            // OkButton
            // 
            this.OkButton.Location = new Point(40, 177);
            this.OkButton.Margin = new Padding(4, 3, 4, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new Size(88, 27);
            this.OkButton.TabIndex = 10;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += this.OkButtonClick;
            // 
            // DeclineButton
            // 
            this.DeclineButton.Location = new Point(401, 177);
            this.DeclineButton.Margin = new Padding(4, 3, 4, 3);
            this.DeclineButton.Name = "DeclineButton";
            this.DeclineButton.Size = new Size(88, 27);
            this.DeclineButton.TabIndex = 11;
            this.DeclineButton.Text = "Cancel";
            this.DeclineButton.UseVisualStyleBackColor = true;
            this.DeclineButton.Click += this.CancelButtonClick;
            // 
            // CreateCanvasGroupBox
            // 
            this.CreateCanvasGroupBox.Controls.Add(this.SizeSmallButton);
            this.CreateCanvasGroupBox.Controls.Add(this.SizeAverageButton);
            this.CreateCanvasGroupBox.Controls.Add(this.SizeBigButton);
            this.CreateCanvasGroupBox.Location = new Point(40, 36);
            this.CreateCanvasGroupBox.Margin = new Padding(4, 3, 4, 3);
            this.CreateCanvasGroupBox.Name = "CreateCanvasGroupBox";
            this.CreateCanvasGroupBox.Padding = new Padding(4, 3, 4, 3);
            this.CreateCanvasGroupBox.Size = new Size(449, 55);
            this.CreateCanvasGroupBox.TabIndex = 12;
            this.CreateCanvasGroupBox.TabStop = false;
            this.CreateCanvasGroupBox.Text = "Стандартные значения окон:";
            // 
            // UiCreateCanvas
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(550, 232);
            this.Controls.Add(this.CreateCanvasGroupBox);
            this.Controls.Add(this.DeclineButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.ManualSelectionCheckBox);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.Margin = new Padding(4, 3, 4, 3);
            this.Name = "UiCreateCanvas";
            this.Text = "Выбор размера окна";
            this.CreateCanvasGroupBox.ResumeLayout(false);
            this.CreateCanvasGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton SizeSmallButton;
        private System.Windows.Forms.RadioButton SizeAverageButton;
        private System.Windows.Forms.RadioButton SizeBigButton;
        private System.Windows.Forms.CheckBox ManualSelectionCheckBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button DeclineButton;
        private System.Windows.Forms.GroupBox CreateCanvasGroupBox;
    }
}
