using Microsoft.Data.Sqlite;
using tl2_tp8_2025_pato2003.Models;
using tl2_tp8_2025_pato2003.Interfaces;

namespace tl2_tp8_2025_pato2003.Repositorios;

public class PresupuestoRepository : IPresupuestoRepository
{
    private string connectionString = "Data Source=DB/Tienda_final.db;";
    public void AltaPresupuesto(Presupuesto presupuestoNuevo)
    {
        string fecha = presupuestoNuevo.FechaCreacion.Year.ToString() + '-' + presupuestoNuevo.FechaCreacion.Month.ToString() + '-' + presupuestoNuevo.FechaCreacion.Day.ToString();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string sql = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@nombre, @fecha);SELECT last_insert_rowid();INSERT INTO PresupuestoDetalle (idPresupuesto, idProducto, Cantidad) VALUES (@idPres, @idProd, @cant)";

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@nombre", presupuestoNuevo.NombreDestinatario);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void EliminarPresupuesto(int idPresupuesto)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();   
            string sql = "DELETE FROM Presupuestos WHERE idPresupuesto = @idPres;";
            using(var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@idPres", idPresupuesto);
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
        return;
    }


    public List<Presupuesto> GetPresupuestos()
    {
        List<Presupuesto> listaPresupuestos = new List<Presupuesto>();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT * FROM Presupuestos;";
            var command = new SqliteCommand(sql, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listaPresupuestos.Add(new Presupuesto(Convert.ToInt32(reader["idPresupuesto"]),
                                                        reader["NombreDestinatario"].ToString(),
                                                        DateOnly.Parse(reader["FechaCreacion"].ToString())
                                                        ));
                }
            }

            connection.Close();
        }
        return listaPresupuestos;
    }

    public Presupuesto GetPresupuestoById(int idPresupuesto)
    {
        Presupuesto presupuesto = null;
        List<PresupuestoDetalle> listaDetalles = new List<PresupuestoDetalle>();
        var repoProducto = new ProductoRepository();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            string sqlDetalle = "SELECT * FROM PresupuestosDetalle WHERE idPresupuesto = @idPres";

            using(var command = new SqliteCommand(sqlDetalle, connection))
            {
                command.Parameters.AddWithValue("@idPres", idPresupuesto);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaDetalles.Add(new PresupuestoDetalle(repoProducto.GetProductoById(Convert.ToInt32(reader["idProducto"])),
                                                                 Convert.ToInt32(reader["Cantidad"])));
                    }
                }
            }        

            string sqlPresupuesto = "SELECT * FROM Presupuestos WHERE idPresupuesto = @idPres;";
            using(var command = new SqliteCommand(sqlPresupuesto, connection))
            {
                command.Parameters.AddWithValue("@idPres", idPresupuesto);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        presupuesto = new Presupuesto(Convert.ToInt32(reader["idPresupuesto"]),
                                                    reader["NombreDestinatario"].ToString(),
                                                    DateOnly.Parse(reader["FechaCreacion"].ToString()),
                                                    listaDetalles);
                    }
                }
            }
            connection.Close();
        }
        return presupuesto;
    }

    public void ModificarPresupuesto(Presupuesto presupuestoModificado)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();   

            string sql = "UPDATE Presupuestos SET NombreDestinatario = @nombre, FechaCreacion = @fecha WHERE idPresupuesto = @idPres;";
            using(var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@nombre", presupuestoModificado.NombreDestinatario);
                command.Parameters.AddWithValue("@precio", presupuestoModificado.FechaCreacion);
                command.Parameters.AddWithValue("@idPres", presupuestoModificado.IdPresupuesto);
                command.ExecuteNonQuery();

            }
            connection.Close();
        }
        return;
    }
}