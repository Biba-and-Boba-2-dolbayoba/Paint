using Paint.Figures;
using Paint.States;
using System.ComponentModel;

namespace Paint.UI;

internal partial class UiTextBoxPlaceholder : TextBox {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TextBoxWrapper? Wrapper { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public BufferedGraphics? GraphicsBuffer { get; set; }

    public UiTextBoxPlaceholder() {
        this.InitializeComponent();
    }

    private void OnKeyDown(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Enter && this.Wrapper is not null && this.GraphicsBuffer is not null) {
            Graphics graphics = this.GraphicsBuffer.Graphics;
            this.Wrapper.Text = this.Text;
            this.Wrapper.Draw(graphics);

            if (this.Parent is UiCanvasWindow parent && parent.State is DrawState state) {
                state.Figures.Add(this.Wrapper);
            }

            this.Dispose();
        }
    }
}