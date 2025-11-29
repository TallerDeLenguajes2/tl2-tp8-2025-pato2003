using presupuestoDetalle;

namespace presupuesto
{
    public class Presupuesto
    {
        public Presupuesto(int idPresupuesto, string nombreDestinatario, DateOnly fechaCreacion, List<PresupuestoDetalle> detalle)
        {
            IdPresupuesto = idPresupuesto;
            NombreDestinatario = nombreDestinatario;
            FechaCreacion = fechaCreacion;
            Detalle = detalle;
        }
        public Presupuesto(int idPresupuesto, string nombreDestinatario, DateOnly fechaCreacion)
        {
            IdPresupuesto = idPresupuesto;
            NombreDestinatario = nombreDestinatario;
            FechaCreacion = fechaCreacion;
        }

        public Presupuesto()
        {
            Detalle = new List<PresupuestoDetalle>();
        }

        public int IdPresupuesto{ get; set; }
        public string NombreDestinatario{ get; set; }
        public DateOnly FechaCreacion{ get; set; }
        public List<PresupuestoDetalle> Detalle { get; set; }

        public double MontoPresupuesto()
        {
            double montoFinal = 0;
            foreach (var item in Detalle     )
            {
                montoFinal+=item.Producto.Precio * item.Cantidad;
            }
            return montoFinal;
        }

        public double MontoPresupuestoConIva()
        {
            return MontoPresupuesto()*1.21;
        }

        public int CantidadProductos()
        {
            int cant = 0;
            foreach (var item in Detalle)
            {
                cant+=item.Cantidad;
            }
            return cant;
        }
    }
}
