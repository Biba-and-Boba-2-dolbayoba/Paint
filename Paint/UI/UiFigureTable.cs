using Paint.Figures;
using Paint.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using static Paint.UiFigureTable;

namespace Paint {
    public partial class UiFigureTable : Form {
        public UiFigureTable(List<FigureInfo> figureInfos) {
            InitializeComponent();
           
        }


        public void LoadFigures(List<FigureInfo> figureInfos) {
            
            this.dataGridView.DataSource = null; 
            this.dataGridView.DataSource = figureInfos; 
        }

        public class FigureInfo {
            public int Number { get; set; }  
            public string Type { get; set; } = string.Empty;  
            public string PenColor { get; set; } = string.Empty;  
            public string BrushColor { get; set; } = string.Empty;  
            public string TopPoint { get; set; } = string.Empty;   
            public string Font { get; set; } = string.Empty;  
            public string FontSize { get; set; } = string.Empty;
            public int Index { get; internal set; }
        }
    }
}