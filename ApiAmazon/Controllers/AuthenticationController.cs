using ApiAmazon.DTO;
using ApiAmazon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAmazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthRepository Auth;
        protected ResponseDto Response;

        public AuthenticationController(IAuthRepository _Auth)
        {
            Auth = _Auth;
            Response = new ResponseDto();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequestDto registration)
        {
            var message = await Auth.RegisterAsync(registration); 
            if(!string.IsNullOrEmpty(message))
            {
                Response.IsSuccess = false;
                Response.Message = message;
                return BadRequest(message);
            }
            return Ok(Response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AsignRole([FromBody]RegistrationRequestDto regdto)
        {
            var assignRoleSuccessful = await Auth.AssignRoleAsync(regdto.Role, regdto.Email);
            if(!assignRoleSuccessful)
            {
                Response.IsSuccess=false;
                Response.Message = "Error has been encounter";
                return BadRequest(Response);
            }
            return Ok(Response);
           
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequestDto loginDto)
        {
            var loginResponse= await Auth.LoginAsync(loginDto);
            if(loginResponse.User== null)
            {
                Response.IsSuccess=false;
                Response.Message = "";
                return BadRequest(Response);
            }
            Response.Result = loginResponse;
            return Ok(Response);
        }
    }
}
