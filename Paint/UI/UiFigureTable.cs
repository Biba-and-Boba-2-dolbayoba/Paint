using Paint.Figures;
using Paint.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Paint {
    internal partial class UiFigureTable : Form {
        private List<IDrawable> Figures { get; set; }
        public UiFigureTable( List<IDrawable> figuresInfo) {
            this.Figures = figuresInfo;
            InitializeComponent();

        }

        private void OnLoad(object sender, System.EventArgs e) {
            this.SetupDataGridView();
            this.SetupData();
        }

        private void SetupData() {
            
            int counter = 0;
            Dictionary<FiguresEnum, string> figureEnum = new Dictionary<FiguresEnum, string>() {
                { FiguresEnum.Rectangle,"Прямоугольник" },
                { FiguresEnum.Ellipse,"Эллипс" },
                { FiguresEnum.StraightLine,"Прямая линия" },
                { FiguresEnum.CurveLine,"Кривая линия" },
                { FiguresEnum.TextBox,"Текст" },

        };
            foreach (var figure in this.Figures) {
                var figureType = figureEnum[figure.FigureType];
                string[] row = {
                    $"{counter}", figureType,$"{figure.TopPoint.X }, {figure.TopPoint.Y}",figure.PenColor.Name, figure.BrushColor.Name,"",""
                };
                if (figure is TextBoxWrapper textBox) {
                    row[5] = textBox.TextFont.Name;
                    row[6] = $"{textBox.TextFont.SizeInPoints}";
                }
                ++counter;
                this.dataGridView.Rows.Add(row);
            }
            dataGridView.Columns[0].DisplayIndex = 0;
            dataGridView.Columns[1].DisplayIndex = 1;
            dataGridView.Columns[2].DisplayIndex = 2;
            dataGridView.Columns[3].DisplayIndex = 3;
            dataGridView.Columns[4].DisplayIndex = 4;
            dataGridView.Columns[5].DisplayIndex = 5;
            dataGridView.Columns[6].DisplayIndex = 6;

        }
        private void SetupDataGridView() {
            this.Controls.Add(dataGridView);

            dataGridView.ColumnCount = 7;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);

            dataGridView.Name = "songsDataGridView";
            dataGridView.Location = new Point(8, 8);
            dataGridView.Size = new Size(500, 250);
            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.GridColor = Color.Black;
            dataGridView.RowHeadersVisible = false;

            dataGridView.Columns[0].Name = "Id";
            dataGridView.Columns[1].Name = "Тип фигуры";
            dataGridView.Columns[2].Name = "Координаты";
            dataGridView.Columns[3].Name = "Цвет пера";
            dataGridView.Columns[4].Name = "Цвет заливки";
            dataGridView.Columns[5].Name = "Шрифт";
            dataGridView.Columns[6].Name = "Размер шрифта";

            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.Dock = DockStyle.Fill;


        }
    }
}