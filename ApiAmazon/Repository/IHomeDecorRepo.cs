using ApiAmazon.DTO;

namespace ApiAmazon.Repository
{
    public interface IHomeDecorRepo
    {
        List<HomeDecoreDto> GetAllList();

        HomeDecoreDto InsertItems(HomeDecoreDto HdDto);
    }
}
