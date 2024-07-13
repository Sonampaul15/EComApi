using ApiAmazon.Utility;

namespace ApiAmazon.Repository
{
    public interface IJwtTokenGenerator
    {
        string TokenGenerator (ApplicationUser applicationUser,IEnumerable<string> roles);
    }
}
