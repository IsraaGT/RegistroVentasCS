using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TiendaCS
{
    public partial class Form2 : Form
    {
        private ListaVentasCircularDoble ventasLista;

        public Form2(ListaVentasCircularDoble ventasLista)
        {
            InitializeComponent();
            this.ventasLista = ventasLista;

            if (dgvVentas.Columns.Count == 0)
            {
                dgvVentas.Columns.Add("ID", "ID");
                dgvVentas.Columns.Add("Fecha", "Fecha");
                dgvVentas.Columns.Add("Producto", "Producto");
                dgvVentas.Columns.Add("Costo", "Costo");
                dgvVentas.Columns.Add("Cantidad", "Cantidad");
                dgvVentas.Columns.Add("Total", "Total");
            }

            CargarVentas();
        }

        private void CargarVentas()
        {
            var ventas = GestorArchivo.CargarVentas();

            foreach (var venta in ventas)
            {
                if (!ventasLista.ListarVentas().Any(v => v.Fecha == venta.Fecha && v.Producto == venta.Producto && v.Costo == venta.Costo))
                {
                    ventasLista.AgregarVenta(venta);
                }
            }

            var nuevasVentas = ventas.Where(v =>
                !dgvVentas.Rows.Cast<DataGridViewRow>().Any(r =>
                (r.Cells[0].Value?.ToString() ?? string.Empty) == v.ID.ToString() &&
                (r.Cells[1].Value?.ToString() ?? string.Empty) == v.Fecha.ToString("dd/MM/yyyy") &&
                (r.Cells[2].Value?.ToString() ?? string.Empty) == v.Producto &&
                (r.Cells[3].Value?.ToString() ?? string.Empty) == v.Costo.ToString() &&
                (r.Cells[4].Value?.ToString() ?? string.Empty) == v.Cantidad.ToString() &&
                (r.Cells[5].Value?.ToString() ?? string.Empty) == v.Total.ToString()
                )
            );

            foreach (var venta in nuevasVentas)
            {
                dgvVentas.Rows.Add(venta.ID, venta.Fecha.ToString("dd/MM/yyyy"), venta.Producto, venta.Costo, venta.Cantidad, venta.Total);
            }
        }

        private void btnModificarVenta_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                var row = dgvVentas.SelectedRows[0];
                int idVenta = int.Parse(row.Cells[0].Value?.ToString() ?? "0");

                if (idVenta == 0)
                {
                    MessageBox.Show("El ID de la venta no es válido.");
                    return;
                }

                var ventaOriginal = ventasLista.BuscarVenta(idVenta);
                if (ventaOriginal == null)
                {
                    MessageBox.Show("No se encontró la venta seleccionada.");
                    return;
                }

                var nuevaVenta = new Venta(
                    id: idVenta, 
                    fecha: DateTime.Parse(row.Cells[1].Value?.ToString() ?? DateTime.Now.ToString("dd/MM/yyyy")),
                    producto: row.Cells[2].Value?.ToString() ?? string.Empty,
                    costo: decimal.Parse(row.Cells[3].Value?.ToString() ?? "0"),
                    cantidad: int.Parse(row.Cells[4].Value?.ToString() ?? "0")
                );

                if (ventasLista.EliminarVenta(idVenta))
                {
                    ventasLista.AgregarVenta(nuevaVenta);

                    dgvVentas.Rows.Clear();
                    foreach (var venta in ventasLista.ListarVentas())
                    {
                        dgvVentas.Rows.Add(venta.ID, venta.Fecha.ToString("dd/MM/yyyy"), venta.Producto, venta.Costo, venta.Cantidad, venta.Total);
                    }

                    GestorArchivo.GuardarVentas(ventasLista.ListarVentas());

                    MessageBox.Show("Venta modificada correctamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo modificar la venta.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una venta para modificar.");
            }
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                var row = dgvVentas.SelectedRows[0];
                int idVenta = int.Parse(row.Cells[0].Value?.ToString() ?? "0");

                if (idVenta == 0)
                {
                    MessageBox.Show("El ID de la venta no es válido.");
                    return;
                }

                if (ventasLista.EliminarVenta(idVenta))
                {
                    MessageBox.Show("Venta eliminada exitosamente.");

                    var ventas = ventasLista.ListarVentas();

                    GestorArchivo.GuardarVentas(ventas);

                    CargarVentas();
                }

                else
                {
                    MessageBox.Show("No se pudo eliminar la venta.");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOrdenar_Click_1(object sender, EventArgs e)
        {
            if (ventasLista.ListarVentas().Count == 0)
            {
                MessageBox.Show("No hay ventas para ordenar.");
                return;
            }

            if (rbAscendente.Checked)
            {
                ventasLista.OrdenarVentasAscendente();
                MessageBox.Show("Ventas ordenadas de manera ascendente por ID.");
            }
            else if (rbDescendente.Checked)
            {
                ventasLista.OrdenarVentasDescendente();
                MessageBox.Show("Ventas ordenadas de manera descendente por ID.");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un orden para las ventas.");
                return;
            }

            dgvVentas.Rows.Clear();

           
            foreach (var venta in ventasLista.ListarVentas())
            {
                dgvVentas.Rows.Add(venta.ID, venta.Fecha.ToString("dd/MM/yyyy"), venta.Producto, venta.Costo, venta.Cantidad, venta.Total);
            }
        }
    }
}
