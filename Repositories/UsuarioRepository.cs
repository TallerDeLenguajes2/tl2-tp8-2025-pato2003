using Microsoft.Data.Sqlite;
using tl2_tp8_2025_pato2003.Interfaces;
namespace tl2_tp8_2025_pato2003.Repositorios;

public class UsuarioRepository : IUserRepository
{
    private string connectionString = "Data Source=DB/Tienda_final.db;";

    public Usuario GetUser(string username, string password)
    {
        Usuario user = null; 
        //Consulta SQL que busca por Usuario Y Contrasena 
        const string sql = @" 
                        SELECT Id, Nombre, User, Pass, Rol 
                        FROM Usuarios 
                        WHERE User = @Usuario AND Pass = @Contrasena"; 
        using var conexion = new SqliteConnection(connectionString); 
        conexion.Open(); 
        using var comando = new SqliteCommand(sql, conexion); 
        // Se usan parámetros para prevenir inyección SQL 
        comando.Parameters.AddWithValue("@Usuario", username);
        comando.Parameters.AddWithValue("@Contrasena", password);
        using var reader = comando.ExecuteReader();
        if (reader.Read())
        {
            user = new Usuario(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2), 
                reader.GetString(3), 
                reader.GetString(4)  
                );
        }
        return user;
    }
}