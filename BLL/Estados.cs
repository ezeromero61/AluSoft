namespace BLL
{
    public static class Estados
    {
        public static readonly string[] Produccion = { "Pendiente", "En corte", "En armado", "En vidriado", "Control de calidad", "Terminado", "Entregado", "Cancelado" };
        public static readonly string[] Presupuesto = { "Pendiente", "Aprobado", "Rechazado", "Vencido" };
        public static readonly string[] Pedido = { "Confirmado", "En producción", "Listo", "Entregado" };
        public static readonly string[] Factura = { "Pendiente", "Pagada", "Anulada" };
        public static readonly string[] Cobro = { "Pendiente", "Cobrado", "Anulado" };
        public static readonly string[] Reaprovisionamiento = { "Pendiente", "Enviado al proveedor", "Comprado", "Recibido", "Cancelado" };
        public static readonly string[] FormaPago = { "Efectivo", "Tarjeta", "Cheque", "Transferencia" };
        public static readonly string[] Genero = { "Femenino", "Masculino", "Prefiero no decirlo" };
        public static readonly string[] Prioridad = { "Alta", "Media", "Baja" };
        public static readonly string[] Remito = { "Recibido", "Pendiente de entrega", "Con faltantes" };
    }
}
