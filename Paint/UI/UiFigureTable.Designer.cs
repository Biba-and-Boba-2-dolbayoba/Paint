namespace Paint {
    partial class UiFigureTable {
        private System.Windows.Forms.DataGridView dataGridView;

        private void InitializeComponent() {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridView
            // 
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ReadOnly = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Добавляем столбцы
            this.dataGridView.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn {
                HeaderText = "№",
                DataPropertyName = "Index",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            });
            this.dataGridView.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn {
                HeaderText = "Тип",
                DataPropertyName = "Type",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            });
            this.dataGridView.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn {
                HeaderText = "Координаты",
                DataPropertyName = "Coordinates",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            });
            this.dataGridView.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn {
                HeaderText = "Цвет пера",
                DataPropertyName = "PenColor",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            });
            this.dataGridView.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn {
                HeaderText = "Цвет заливки",
                DataPropertyName = "BrushColor",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            });

            // Добавляем столбцы для TextBoxWrapper
            this.dataGridView.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn {
                HeaderText = "Шрифт",
                DataPropertyName = "Font",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            });
            this.dataGridView.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn {
                HeaderText = "Размер шрифта",
                DataPropertyName = "FontSize",
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            });

            // 
            // UiFigureTable
            // 
            this.Controls.Add(this.dataGridView);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "UiFigureTable";
            this.Text = "Список фигур";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
