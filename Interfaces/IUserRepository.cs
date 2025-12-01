namespace tl2_tp8_2025_pato2003.Interfaces;
public interface IUserRepository
{
    Usuario GetUser(string username, string password);
}