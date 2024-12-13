namespace TiendaCS
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvVentas = new DataGridView();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnCerrar = new Button();
            rbAscendente = new RadioButton();
            rbDescendente = new RadioButton();
            btnOrdenar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // dgvVentas
            // 
            dgvVentas.BackgroundColor = Color.FromArgb(240, 240, 240);
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Font = new Font("Arial", 10F);
            dgvVentas.Location = new Point(12, 31);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(839, 309);
            dgvVentas.TabIndex = 0;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(0, 192, 255);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(12, 358);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 40);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificarVenta_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 0, 0);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(138, 358);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 40);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminarVenta_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(0, 128, 0);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(711, 358);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(120, 40);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // rbAscendente
            // 
            rbAscendente.AutoSize = true;
            rbAscendente.Location = new Point(406, 363);
            rbAscendente.Name = "rbAscendente";
            rbAscendente.Size = new Size(134, 27);
            rbAscendente.TabIndex = 5;
            rbAscendente.TabStop = true;
            rbAscendente.Text = "Ascendente";
            rbAscendente.UseVisualStyleBackColor = true;
            // 
            // rbDescendente
            // 
            rbDescendente.AutoSize = true;
            rbDescendente.Location = new Point(546, 363);
            rbDescendente.Name = "rbDescendente";
            rbDescendente.Size = new Size(146, 27);
            rbDescendente.TabIndex = 6;
            rbDescendente.TabStop = true;
            rbDescendente.Text = "Descendente";
            rbDescendente.UseVisualStyleBackColor = true;
            // 
            // btnOrdenar
            // 
            btnOrdenar.BackColor = Color.Blue;
            btnOrdenar.FlatAppearance.BorderSize = 0;
            btnOrdenar.FlatStyle = FlatStyle.Flat;
            btnOrdenar.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnOrdenar.ForeColor = Color.White;
            btnOrdenar.Location = new Point(264, 358);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(120, 40);
            btnOrdenar.TabIndex = 7;
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = false;
            btnOrdenar.Click += btnOrdenar_Click_1;
            // 
            // Form2
            // 
            BackColor = Color.FromArgb(255, 255, 255);
            ClientSize = new Size(863, 400);
            Controls.Add(btnOrdenar);
            Controls.Add(rbDescendente);
            Controls.Add(rbAscendente);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(dgvVentas);
            Font = new Font("Arial", 12F);
            Name = "Form2";
            Text = "Gestión de Ventas";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
        private RadioButton rbAscendente;
        private RadioButton rbDescendente;
        private Button btnOrdenar;
    }
}
