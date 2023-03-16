using Catalog.Core.DTOs;
using Catalog.Core.Models;
using System.Threading.Tasks;

namespace Catalog.Core.Services.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
        Task<string> CreateRefreshToken();
        Task<TokenRequest> VerifyRefreshToken(TokenRequest request);
    }
}
