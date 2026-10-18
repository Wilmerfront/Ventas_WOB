namespace BlazorApp1.modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Stock { get; set; } = 100; // Stock inicial de ejemplo
    }

    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioVentaReal { get; set; }
        public decimal PrecioCompraReal { get; set; }
        
        // Ganancia de esta venta específica
        public decimal GananciaBruta => (PrecioVentaReal - PrecioCompraReal) * Cantidad;
    }

    public class Gasto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
    }
}