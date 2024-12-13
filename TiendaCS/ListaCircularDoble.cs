using System;
using System.Collections.Generic;
using System.Linq;

namespace TiendaCS
{
    public class ListaVentasCircularDoble
    {
        private NodoVenta _cabeza;

        public void AgregarVenta(Venta nuevaVenta)
        {
            var nuevoNodo = new NodoVenta(nuevaVenta);

            if (_cabeza == null)
            {
                _cabeza = nuevoNodo;
                nuevoNodo.Siguiente = _cabeza;
                nuevoNodo.Anterior = _cabeza;
            }
            else
            {
                var ultimo = _cabeza.Anterior;

                ultimo.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = ultimo;

                nuevoNodo.Siguiente = _cabeza;
                _cabeza.Anterior = nuevoNodo;
            }
        }

        public bool EliminarVenta(int id)
        {
            if (_cabeza == null) return false;

            var actual = _cabeza;
            do
            {
                if (actual.Venta.ID == id) 
                {
                    if (actual == _cabeza && _cabeza.Siguiente == _cabeza)
                    {
                        _cabeza = null;
                    }
                    else
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = actual.Anterior;

                        if (actual == _cabeza) _cabeza = actual.Siguiente;
                    }
                    return true;
                }
                actual = actual.Siguiente;
            } while (actual != _cabeza);

            return false;
        }

        public List<Venta> ListarVentas()
        {
            var ventas = new List<Venta>();
            if (_cabeza == null) return ventas;

            var actual = _cabeza;
            do
            {
                ventas.Add(actual.Venta);
                actual = actual.Siguiente;
            } while (actual != _cabeza);

            return ventas;
        }

        
        public bool ModificarVenta(int id, Venta nuevaVenta)
        {
            if (_cabeza == null) return false;

            if (EliminarVenta(id))
            {
                AgregarVenta(nuevaVenta);
                return true;
            }

            return false;
        }

       
        public Venta BuscarVenta(int id)
        {
            if (_cabeza == null) return null;

            var actual = _cabeza;
            do
            {
                if (actual.Venta.ID == id) 
                {
                    return actual.Venta;
                }
                actual = actual.Siguiente;
            } while (actual != _cabeza);

            return null;
        }
        public void OrdenarVentasAscendente()
        {
            if (_cabeza == null || _cabeza.Siguiente == _cabeza) return; // Si la lista está vacía o tiene un solo elemento.

            bool intercambiado;
            do
            {
                intercambiado = false;
                var actual = _cabeza;
                do
                {
                    if (actual.Venta.ID > actual.Siguiente.Venta.ID)
                    {
                        // Intercambiar las ventas
                        Venta temp = actual.Venta;
                        actual.Venta = actual.Siguiente.Venta;
                        actual.Siguiente.Venta = temp;

                        intercambiado = true;
                    }
                    actual = actual.Siguiente;
                } while (actual.Siguiente != _cabeza);
            } while (intercambiado);
        }

        public void OrdenarVentasDescendente()
        {
            if (_cabeza == null || _cabeza.Siguiente == _cabeza) return; // Si la lista está vacía o tiene un solo elemento.

            bool intercambiado;
            do
            {
                intercambiado = false;
                var actual = _cabeza;
                do
                {
                    if (actual.Venta.ID < actual.Siguiente.Venta.ID)
                    {
                        // Intercambiar las ventas
                        Venta temp = actual.Venta;
                        actual.Venta = actual.Siguiente.Venta;
                        actual.Siguiente.Venta = temp;

                        intercambiado = true;
                    }
                    actual = actual.Siguiente;
                } while (actual.Siguiente != _cabeza);
            } while (intercambiado);
        }


    }
}
