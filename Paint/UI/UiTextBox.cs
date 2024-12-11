using System.Windows.Forms;
using System.Drawing;
using Paint.Figures;
using System.ComponentModel;

namespace Paint.UI;

internal class UiTextBox(TextBoxWrapper wrapper, UiCanvasWindow parent) : Control {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TextBox InputField { get; set; } = new TextBox();

    private Point TopPoint { get; set; } = wrapper.TopPoint;
    private Point BotPoint { get; set; } = wrapper.BotPoint;

    private Color PenColor { get; set; } = wrapper.PenColor;
    private string CurrentText { get; set; } = wrapper.Text;
    private Font TextFont { get; set; } = wrapper.TextFont;

    private UiCanvasWindow ParentReference { get; set; } = parent;

    public void CreateTextBox() {
        InputField.Parent = this.ParentReference;
        InputField.Font = this.TextFont;
        InputField.Multiline = true;
        InputField.ForeColor = this.PenColor;
        InputField.Location = this.TopPoint;
        InputField.Width = this.BotPoint.X - this.TopPoint.X;
        InputField.Height = this.BotPoint.Y - this.TopPoint.Y;
        InputField.Text = this.CurrentText;
    }
}
