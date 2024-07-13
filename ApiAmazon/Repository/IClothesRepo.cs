using ApiAmazon.DTO;

namespace ApiAmazon.Repository
{
    public interface IClothesRepo
    {
        List<ClothingDto> GetAllList();

        ClothingDto InsertItems(ClothingDto clothingDto);
    }
}
