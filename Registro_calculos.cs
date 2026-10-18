using BlazorApp1.modelos;

namespace BlazorApp1.servicios
{
    public class InventarioService
    {
        public List<Producto> Productos { get; set; }
        public List<Venta> Ventas { get; set; } = new List<Venta>();
        public List<Gasto> Gastos { get; set; } = new List<Gasto>();

        public InventarioService()
        {
            // Inicializamos la lista con tus productos reales
            Productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Pan", PrecioVenta = 50, PrecioCompra = 38 },
                new Producto { Id = 2, Nombre = "Galletas de pan", PrecioVenta = 50, PrecioCompra = 40 },
                new Producto { Id = 3, Nombre = "Dolly", PrecioVenta = 200, PrecioCompra = 175 },
                new Producto { Id = 4, Nombre = "Mantecado", PrecioVenta = 125, PrecioCompra = 100 },
                new Producto { Id = 5, Nombre = "Cortado", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 6, Nombre = "Ojadra", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 7, Nombre = "Galletas de ajo", PrecioVenta = 200, PrecioCompra = 180 },
                new Producto { Id = 8, Nombre = "Rabito", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 9, Nombre = "Dulce de Leche", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 10, Nombre = "Suspiro", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 11, Nombre = "Palito de ajo", PrecioVenta = 125, PrecioCompra = 100 },
                new Producto { Id = 12, Nombre = "Pastelitos", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 13, Nombre = "Coquito", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 14, Nombre = "Torta amarilla", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 15, Nombre = "Cocada", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 16, Nombre = "Azucarada", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 17, Nombre = "Mofin", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 18, Nombre = "Pisina", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 19, Nombre = "Polvorín", PrecioVenta = 100, PrecioCompra = 85 },
                new Producto { Id = 20, Nombre = "Pudín", PrecioVenta = 50, PrecioCompra = 40 }
            };
        }

        // Método para registrar una venta
        public void RegistrarVenta(int productoId, int cantidad)
        {
            var producto = Productos.FirstOrDefault(p => p.Id == productoId);
            if (producto != null && producto.Stock >= cantidad)
            {
                producto.Stock -= cantidad; // Restar del inventario
                
                Ventas.Add(new Venta
                {
                    Id = Ventas.Count + 1,
                    ProductoId = producto.Id,
                    NombreProducto = producto.Nombre,
                    Cantidad = cantidad,
                    PrecioVentaReal = producto.PrecioVenta,
                    PrecioCompraReal = producto.PrecioCompra,
                    Fecha = DateTime.Now
                });
            }
        }

        // Reportes: Ganancia Bruta (Ventas - Costo de productos)
        public decimal ObtenerGananciaBrutaDiaria(DateTime fecha) =>
            Ventas.Where(v => v.Fecha.Date == fecha.Date).Sum(v => v.GananciaBruta);

        public decimal ObtenerGananciaBrutaMensual(int mes, int año) =>
            Ventas.Where(v => v.Fecha.Month == mes && v.Fecha.Year == año).Sum(v => v.GananciaBruta);

        // Reportes: Ganancia Neta / Limpia (Ganancia Bruta - Gastos)
        public decimal ObtenerGananciaNetaDiaria(DateTime fecha)
        {
            var bruta = ObtenerGananciaBrutaDiaria(fecha);
            var gastos = Gastos.Where(g => g.Fecha.Date == fecha.Date).Sum(g => g.Monto);
            return bruta - gastos;
        }

        public decimal ObtenerGananciaNetaMensual(int mes, int año)
        {
            var bruta = ObtenerGananciaBrutaMensual(mes, año);
            var gastos = Gastos.Where(g => g.Fecha.Month == mes && g.Fecha.Year == año).Sum(g => g.Monto);
            return bruta - gastos;
        }
    }
}