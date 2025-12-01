namespace tl2_tp8_2025_pato2003.Interfaces;


public interface IAuthenticationService
{
    bool Login(string username, string password);
    void Logout();
    bool IsAuthentiicated();
    bool HasAccessLevel(string requiredAccessLevel);
}