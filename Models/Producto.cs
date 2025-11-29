
namespace tl2_tp8_2025_pato2003.Models;



public class Producto
{
    public Producto(int idProducto, string descripcion, int precio)
    {
        IdProducto = idProducto;
        Descripcion = descripcion;
        Precio = precio;
    }

    public Producto(){}

    public int IdProducto { get; set; }
    public string Descripcion { get; set; }
    public int Precio { get; set; }

}