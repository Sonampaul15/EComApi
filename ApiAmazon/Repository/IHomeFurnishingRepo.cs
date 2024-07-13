using ApiAmazon.DTO;

namespace ApiAmazon.Repository
{
    public interface IHomeFurnishingRepo
    {
        List<HomeFurnishingDto> GetAllList();

        HomeFurnishingDto InsertItems(HomeFurnishingDto HFDto);
    }
}
