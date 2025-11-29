using tl2_tp8_2025_pato2003.Models;

namespace tl2_tp8_2025_pato2003.Interfaces;


public interface IProductoRepository
{
    Producto GetProductoById(int idProducto);
    List<Producto> GetProductos();
    void AltaProducto(Producto productoNuevo);
    void ModificarProducto(Producto productoModificado);
    void EliminarProducto(int idProducto);

}