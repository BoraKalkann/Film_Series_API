using Film_Dizi_API.Models;
namespace Film_Dizi_API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
