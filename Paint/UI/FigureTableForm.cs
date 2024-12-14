using Paint.Figures;
using Paint.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint;
internal partial class FigureTableForm : Form {
    private List<IDrawable> Figures { get; set; }
    public FigureTableForm(List<IDrawable> figuresInfo) {
        this.Figures = figuresInfo;
        this.InitializeComponent();

    }

    private void OnLoad(object sender, System.EventArgs e) {
        this.SetupDataGridView();
        this.SetupData();
    }

    private void SetupData() {

        int counter = 0;
        var figureEnum = new Dictionary<FigureTypes, string>() {
            { FigureTypes.Rectangle,"Прямоугольник" },
            { FigureTypes.Ellipse,"Эллипс" },
            { FigureTypes.StraightLine,"Прямая линия" },
            { FigureTypes.CurveLine,"Кривая линия" },
            { FigureTypes.TextBox,"Текст" },

    };
        foreach (IDrawable figure in this.Figures) {
            string figureType = figureEnum[figure.FigureType];
            string[] row = {
                $"{counter}", figureType,$"{figure.TopPoint.X }, {figure.TopPoint.Y}",figure.PenColor.Name, figure.BrushColor.Name,"",""
            };
            if (figure is TextBoxWrapper textBox) {
                row[5] = textBox.TextFont.Name;
                row[6] = $"{textBox.TextFont.SizeInPoints}";
            }

            ++counter;
            _ = this.dataGridView.Rows.Add(row);
        }

        this.dataGridView.Columns[0].DisplayIndex = 0;
        this.dataGridView.Columns[1].DisplayIndex = 1;
        this.dataGridView.Columns[2].DisplayIndex = 2;
        this.dataGridView.Columns[3].DisplayIndex = 3;
        this.dataGridView.Columns[4].DisplayIndex = 4;
        this.dataGridView.Columns[5].DisplayIndex = 5;
        this.dataGridView.Columns[6].DisplayIndex = 6;

    }
    private void SetupDataGridView() {
        this.Controls.Add(this.dataGridView);

        this.dataGridView.ColumnCount = 7;

        this.dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
        this.dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        this.dataGridView.ColumnHeadersDefaultCellStyle.Font =
            new Font(this.dataGridView.Font, FontStyle.Bold);

        this.dataGridView.Name = "songsDataGridView";
        this.dataGridView.Location = new Point(8, 8);
        this.dataGridView.Size = new Size(500, 250);
        this.dataGridView.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        this.dataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.Single;
        this.dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        this.dataGridView.GridColor = Color.Black;
        this.dataGridView.RowHeadersVisible = false;

        this.dataGridView.Columns[0].Name = "Id";
        this.dataGridView.Columns[1].Name = "Тип фигуры";
        this.dataGridView.Columns[2].Name = "Координаты";
        this.dataGridView.Columns[3].Name = "Цвет пера";
        this.dataGridView.Columns[4].Name = "Цвет заливки";
        this.dataGridView.Columns[5].Name = "Шрифт";
        this.dataGridView.Columns[6].Name = "Размер шрифта";

        this.dataGridView.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
        this.dataGridView.MultiSelect = false;
        this.dataGridView.Dock = DockStyle.Fill;

    }
}