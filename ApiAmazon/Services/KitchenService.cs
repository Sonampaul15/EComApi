using ApiAmazon.DTO;
using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using AutoMapper;

namespace ApiAmazon.Services
{
    public class KitchenService : IKitchenRepo
    {
        private readonly AmazonDbContext DB;
        IMapper Mapper;
        public KitchenService(AmazonDbContext _DB, IMapper _Mapper)
        {
            DB= _DB;
            Mapper= _Mapper;
        }
        public List<KitchenDto> GetAllList()
        {
            List<Kitchen> kitch = DB.Kitchens.ToList();
            List<KitchenDto> kitchenDtos= Mapper.Map<List<KitchenDto>>(kitch);
            return kitchenDtos;
            
        }

        public KitchenDto InsertItems(KitchenDto KitchDto)
        {
            Kitchen kitchen1 = Mapper.Map<Kitchen>(KitchDto);
            DB.Kitchens.Add(kitchen1);
            DB.SaveChanges();
            KitchenDto kitchenDto1 = Mapper.Map<KitchenDto>(kitchen1 );
            return kitchenDto1;
        }
    }
}
