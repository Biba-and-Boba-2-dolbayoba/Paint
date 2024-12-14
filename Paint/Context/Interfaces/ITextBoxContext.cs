using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint.Context.Interfaces;

//TODO: Move somewhere
internal class TextBoxTemplate {
    private void OnKeyDown(object? sender, KeyEventArgs e) {
        throw new NotImplementedException();
    }

    public TextBox GetTextBox() {
        throw new NotImplementedException();
    }
}

internal interface ITextBoxContext {
    public string Text { get; set; }
    public Font TextFont { get; set; }
    public TextBoxTemplate Template { get; set; }
}
