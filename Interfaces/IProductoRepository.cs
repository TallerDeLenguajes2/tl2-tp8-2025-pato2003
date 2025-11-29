using producto;
public interface IProductoRepository
{
    Producto GetProductoById(int idProducto);
    List<Producto> GetProductos();
    void AltaProducto(Producto productoNuevo);
    void ModificarProducto(Producto productoModificado);
    void EliminarProducto(int idProducto);

}