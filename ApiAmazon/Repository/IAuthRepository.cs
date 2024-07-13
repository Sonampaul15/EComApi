using ApiAmazon.DTO;

namespace ApiAmazon.Repository
{
    public interface IAuthRepository
    {
        Task<string> RegisterAsync(RegistrationRequestDto RegiDto);

        Task<LoginResponseDto> LoginAsync(LoginRequestDto RequestDto);

        Task<bool> AssignRoleAsync(string email, string rolename);
    }
}
