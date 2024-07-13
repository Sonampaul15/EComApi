using ApiAmazon.DTO;

namespace ApiAmazon.Repository
{
    public interface IGroceryRepo
    {
        List<GroceryDto> GetAllGrocery();

        GroceryDto InsertItems (GroceryDto GrocDto);
    }
}
