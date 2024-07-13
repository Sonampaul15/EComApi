using ApiAmazon.DTO;
using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using AutoMapper;

namespace ApiAmazon.Services
{
    public class GroceryService : IGroceryRepo
    {
        private readonly AmazonDbContext DB;
        IMapper Mapper;
        public GroceryService(AmazonDbContext db, IMapper mapper) 
        {
            DB = db;
            Mapper = mapper;
        }
        public List<GroceryDto> GetAllGrocery()
        {
            List<Grocery> groceries = DB.Grocery.ToList();
            List<GroceryDto> groceries_ = Mapper.Map<List<GroceryDto>>(groceries);
            return groceries_;
        }

        public GroceryDto InsertItems(GroceryDto GrocDto)
        {
            Grocery grocery = Mapper.Map<Grocery>(GrocDto);
            DB.Grocery.Add(grocery);
            DB.SaveChanges();
            GroceryDto groceryDto = Mapper.Map<GroceryDto>(grocery);
            return groceryDto;
        }
    }
}
