namespace BE
{
    public class cls36_PresupuestoDetalle
    {
        public int IdDetalle { get; set; }
        public int IdPresupuesto { get; set; }
        public int IdCatalogo { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }
        public int Subtotal { get { return Cantidad * PrecioUnitario; } }
        public int IdStock { get; set; }
    }
}
