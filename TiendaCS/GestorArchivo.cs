using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TiendaCS
{
    public static class GestorArchivo
    {
        private const string RutaArchivo = "registro.json"; 

        public static void GuardarVentas(List<Venta> ventas)
        {
            string json = JsonConvert.SerializeObject(ventas, Formatting.Indented);

            File.WriteAllText(RutaArchivo, json);
        }

        // Método para cargar las ventas desde el archivo JSON
        public static List<Venta> CargarVentas()
        {
            var ventas = new List<Venta>();

            if (File.Exists(RutaArchivo))
            {
                string json = File.ReadAllText(RutaArchivo);

                ventas = JsonConvert.DeserializeObject<List<Venta>>(json);
            }

            return ventas;
        }
    }
}
