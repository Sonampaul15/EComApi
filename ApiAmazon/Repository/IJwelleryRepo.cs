using ApiAmazon.DTO;

namespace ApiAmazon.Repository
{
    public interface IJwelleryRepo
    {
        List<JwelleryDto> GetAllList();

        JwelleryDto InsertItems(JwelleryDto JwellDto);
    }
}
