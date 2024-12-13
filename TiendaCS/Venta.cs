using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaCS
{
    public class Venta
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Producto { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public decimal Total => Costo * Cantidad; 

        public Venta(int id ,DateTime fecha, string producto, decimal costo, int cantidad)
        {
            ID = id;
            Fecha = fecha;
            Producto = producto;
            Costo = costo;
            Cantidad = cantidad;
        }

        public override string ToString()
        {
            return $"{ID}-{Fecha:dd/MM/yyyy} - {Producto}: {Cantidad} x {Costo:C} = {Total:C}";
        }
    }
}
