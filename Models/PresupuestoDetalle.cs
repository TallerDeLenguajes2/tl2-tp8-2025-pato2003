using System.Text.Json.Serialization;
using Microsoft.AspNetCore.SignalR;
using producto;

namespace presupuestoDetalle
{
    public class PresupuestoDetalle
    {
        public PresupuestoDetalle(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        public Producto Producto{get;set;}
        public int Cantidad{get;set;}
    }
}