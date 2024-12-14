namespace Paint {
    partial class FigureTableForm {
        private System.Windows.Forms.DataGridView dataGridView;

        private void InitializeComponent() {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)this.dataGridView).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(850, 450);
            this.dataGridView.TabIndex = 0;
            // 
            // UiFigureTable
            // 
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.dataGridView);
            this.Name = "UiFigureTable";
            this.Text = "Список фигур";
            this.Load += this.OnLoad;
            ((System.ComponentModel.ISupportInitialize)this.dataGridView).EndInit();
            this.ResumeLayout(false);
        }
    }
}
