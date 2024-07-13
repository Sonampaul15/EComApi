using ApiAmazon.DTO;

namespace ApiAmazon.Repository
{
    public interface ICosmeticRepo
    {
        List<CosmeticsDto> GetAllList();

        CosmeticsDto InsertItem(CosmeticsDto cosDto);
    }
}
