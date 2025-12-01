

public class Usuario
{
    public Usuario(int idUsuario, string nombre, string user, string pass, string rol)
    {
        IdUsuario = idUsuario;
        Nombre = nombre;
        User = user;
        Pass = pass;
        Rol = rol;
    }

    public int IdUsuario {get;set;}
    public string Nombre {get;set;}
    public string User {get;set;}
    public string Pass {get;set;}
    public string Rol{get;set;}
}