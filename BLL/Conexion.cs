namespace BLL
{
    public static class Conexion
    {
        public static string Cadena { get { return DAL.clsAcceso.CadenaConexion; } }
        public static string BaseDeDatos { get { return DAL.clsAcceso.BaseDeDatos; } }
    }
}
