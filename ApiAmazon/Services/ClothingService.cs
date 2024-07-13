using ApiAmazon.DTO;
using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using AutoMapper;

namespace ApiAmazon.Services
{
    public class ClothingService : IClothesRepo
    {
        private readonly AmazonDbContext DB;
        IMapper Mapper;
        public ClothingService(AmazonDbContext _DB, IMapper _Mapper)
        {
            DB = _DB;
            Mapper = _Mapper;
        }
        public List<ClothingDto> GetAllList()
        {
            List<Clothing> Clothe = DB.Clothes.ToList();
            List<ClothingDto> Clothe_ = Mapper.Map<List<ClothingDto>>(Clothe);
            return Clothe_;
        }

        public ClothingDto InsertItems(ClothingDto clothingDto)
        {
            Clothing clothing = Mapper.Map<Clothing>(clothingDto);
            DB.Clothes.Add(clothing);
            DB.SaveChanges();
            ClothingDto clothingDto1 = Mapper.Map<ClothingDto>(clothing);
            return clothingDto1;
        }

    }
}
