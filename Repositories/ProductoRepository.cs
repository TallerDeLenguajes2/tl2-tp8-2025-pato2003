using Microsoft.Data.Sqlite;
using producto;

public class ProductoRepository : IProductoRepository
{
    private string connectionString = "Data Source=DB/Tienda_final.db;";

    public void AltaProducto(Producto productoNuevo)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO Productos (Descripcion, Precio) VALUES (@desc, @precio);SELECT last_insert_rowid();";

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@desc", productoNuevo.Descripcion);
                command.Parameters.AddWithValue("@precio", productoNuevo.Precio);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void EliminarProducto(int idProducto)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();   

            string sql = "DELETE FROM Productos WHERE idProducto = @idProd;";
            using(var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@idProd", idProducto);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        return;
    }

    public Producto GetProductoById(int idProducto)
    {
        Producto producto = null;
        
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();   

            string sql = "SELECT * FROM Productos WHERE idProducto = @idProd;";
            using(var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@idProd", idProducto);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        producto = new Producto(Convert.ToInt32(reader["idProducto"]),
                                                        reader["Descripcion"].ToString(),
                                                        Convert.ToInt32(reader["Precio"]));
                    }

                }
            }
            connection.Close();
        }
        return producto;
    }

    public List<Producto> GetProductos()
    {
        List<Producto> listaProductos = new List<Producto>();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM Productos;";
            var command = new SqliteCommand(sql, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listaProductos.Add(new Producto(Convert.ToInt32(reader["idProducto"]),
                                                    reader["Descripcion"].ToString(),
                                                    Convert.ToInt32(reader["Precio"])));
                }
            }

            connection.Close();
        }
        return listaProductos;
    }

    public void ModificarProducto(Producto productoModificado)
    {
        
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();   

            string sql = "UPDATE Productos SET Descripcion = @desc, Precio = @precio WHERE idProducto = @idProd;";
            using(var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@desc", productoModificado.Descripcion);
                command.Parameters.AddWithValue("@precio", productoModificado.Precio);
                command.Parameters.AddWithValue("@idProd", productoModificado.IdProducto);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        return;
    }
}