using ApiAmazon.DTO;

namespace ApiAmazon.Repository
{
    public interface IKitchenRepo
    {
        List<KitchenDto> GetAllList();

        KitchenDto InsertItems(KitchenDto KitchDto);
    }
}
