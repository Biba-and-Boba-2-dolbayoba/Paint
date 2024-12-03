using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Figures;
internal interface ITextBox {
    public Font TextFont {  get; set; }
    public string Text {  get; set; }
}
