
namespace tl2_tp8_2025_pato2003.Models;


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
