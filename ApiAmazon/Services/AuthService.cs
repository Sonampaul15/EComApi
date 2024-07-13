using ApiAmazon.DTO;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace ApiAmazon.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly AmazonDbContext DbContext;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly IJwtTokenGenerator JwtTokenGenerator;

        public AuthService(AmazonDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator _JwtTokenGenerator) 
        {
            DbContext = dbContext;
            UserManager = userManager;
            RoleManager = roleManager;
            JwtTokenGenerator = _JwtTokenGenerator;
        
        }

        public async Task<bool> AssignRoleAsync(string rolename, string email)
        {
            var user = DbContext.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if(!RoleManager.RoleExistsAsync(rolename).GetAwaiter().GetResult())
                {
                    RoleManager.CreateAsync(new IdentityRole(rolename)).GetAwaiter().GetResult();
                }
                await UserManager.AddToRoleAsync(user, rolename);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto RequestDto)
        {
            var user = DbContext.Users.FirstOrDefault(x => x.UserName.ToLower() == RequestDto.Username.ToLower());
            bool isValid = await UserManager.CheckPasswordAsync(user, RequestDto.Password);
            if (user == null || isValid== false)
            {
                return new LoginResponseDto()
                {
                    User = null,
                    Token = "",
                };
            }
            var roles = await UserManager.GetRolesAsync(user);
            var token = JwtTokenGenerator.TokenGenerator(user, roles);

            UserDto dto = new UserDto()
            {
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                PhoneNumber = user.PhoneNumber,
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = dto,
                Token = token,
            };
            return loginResponseDto;
        }

        public async Task<string> RegisterAsync(RegistrationRequestDto RegiDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = RegiDto.FirstName,
                LastName = RegiDto.LastName,
                Gender = RegiDto.Gender,
                UserName= RegiDto.Email,
                Email = RegiDto.Email,
                NormalizedEmail = RegiDto.Email,
                PhoneNumber= RegiDto.PhoneNumber,
            };
            try
            {
                var result= await UserManager.CreateAsync(user,RegiDto.Password);
                if(result.Succeeded)
                {
                    var returnUserData = DbContext.Users.First(x=> x.Email== RegiDto.Email);
                    UserDto dto = new UserDto()
                    {
                        Email = returnUserData.Email,
                        Id = returnUserData.Id,
                        FirstName = returnUserData.FirstName,
                        PhoneNumber= returnUserData.PhoneNumber,
                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
