using tl2_tp8_2025_pato2003.Interfaces;

namespace tl2_tp8_2025_pato2003.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository; 
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public bool HasAccessLevel(string requiredAccessLevel)
    {
        var context = _httpContextAccessor.HttpContext; 
        if (context == null) 
        { 
            throw new InvalidOperationException("HttpContext no está disponible."); 
        } 
        return context.Session.GetString("Rol") == requiredAccessLevel; 
    }

    public bool IsAuthentiicated()
    {
        var context = _httpContextAccessor.HttpContext; 
        if (context == null) 
        { 
            throw new InvalidOperationException("HttpContext no está disponible."); 
        } 
        return context.Session.GetString("IsAuthenticated") == "true";
    }

    public bool Login(string username, string password)
    {
        var context = _httpContextAccessor.HttpContext; 
        var user = _userRepository.GetUser(username,password); 
        if (user != null) 
        { 
            if (context == null) 
            { 
                throw new InvalidOperationException("HttpContext no está disponible."); 
            } 
            context.Session.SetString("IsAuthenticated", "true"); 
            context.Session.SetString("User", user.User); 
            context.Session.SetString("UserNombre", user.Nombre); 
            context.Session.SetString("Rol", user.Rol); 
            //es el tipo de acceso/rol admin o cliente 
            return true; 
        } 
        return false;
    }

    public void Logout()
    {
        var context = _httpContextAccessor.HttpContext; 
        if (context == null) 
        { 
            throw new InvalidOperationException("HttpContext no está disponible."); 
        } 
        /* context.Session.Remove("IsAuthenticated"); 
        context.Session.Remove("User"); 
        context.Session.Remove("UserNombre"); 
        context.Session.Remove("Rol"); 
        */ 
        context.Session.Clear();
    }
}