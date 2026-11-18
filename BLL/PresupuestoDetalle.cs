using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class PresupuestoDetalle
    {
        mapPresupuestoDetalle mapper = new mapPresupuestoDetalle();

        public List<BE.cls36_PresupuestoDetalle> Listar(int idPresupuesto)
        {
            return mapper.Listar(idPresupuesto);
        }

        public void Guardar(int idPresupuesto, IEnumerable<BE.cls36_PresupuestoDetalle> renglones)
        {
            mapper.EliminarDePresupuesto(idPresupuesto);
            foreach (BE.cls36_PresupuestoDetalle d in renglones)
            {
                d.IdPresupuesto = idPresupuesto;
                mapper.Agregar(d);
            }
        }
    }
}
