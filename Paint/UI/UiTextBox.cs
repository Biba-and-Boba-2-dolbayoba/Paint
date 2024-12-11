using Paint.Figures;
using Paint.Interfaces;
using Paint.States;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.UI;

internal class UiTextBox(TextBoxWrapper wrapper, UiCanvasWindow parent) : Control {
    private TextBox InputField { get; set; } = new TextBox();

    private Point TopPoint { get; set; } = wrapper.TopPoint;
    private Point BotPoint { get; set; } = wrapper.BotPoint;

    private Color PenColor { get; set; } = wrapper.PenColor;
    private string CurrentText { get; set; } = wrapper.Text;
    private Font TextFont { get; set; } = wrapper.TextFont;

    private UiCanvasWindow ParentReference { get; set; } = parent;

    public Task<KeyEventArgs> WaitForKeyDown() {
        var result = new TaskCompletionSource<KeyEventArgs>();

        void handler(object? sender, KeyEventArgs e) {
            _ = result.TrySetResult(e);
            this.InputField.KeyDown -= handler;
        }

        this.InputField.KeyDown += handler;

        return result.Task;
    }

    public void CreateTextBox() {
        this.InputField.Parent = this.ParentReference;
        this.InputField.Font = this.TextFont;
        this.InputField.Multiline = true;
        this.InputField.ForeColor = this.PenColor;
        this.InputField.Location = this.TopPoint;
        this.InputField.Width = this.BotPoint.X - this.TopPoint.X;
        this.InputField.Height = this.BotPoint.Y - this.TopPoint.Y;
        this.InputField.Text = this.CurrentText;
    }
}
