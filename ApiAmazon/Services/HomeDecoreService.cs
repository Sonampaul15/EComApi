using ApiAmazon.DTO;
using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using AutoMapper;

namespace ApiAmazon.Services
{
    public class HomeDecoreService : IHomeDecorRepo
    {
        private readonly AmazonDbContext DB;
        IMapper Mapper;
        public HomeDecoreService(AmazonDbContext _DB, IMapper _Mapper)
        {
            DB = _DB;
            Mapper = _Mapper;
        }
        public List<HomeDecoreDto> GetAllList()
        {
           List<HomeDecore> homes= DB.homeDecores.ToList();
           List<HomeDecoreDto> homesdto = Mapper.Map<List<HomeDecoreDto>>(homes);
           return homesdto;
        }

        public HomeDecoreDto InsertItems(HomeDecoreDto HdDto)
        {
            HomeDecore homeDecore = Mapper.Map<HomeDecore>(HdDto);
            DB.homeDecores.Add(homeDecore);
            DB.SaveChanges();
            HomeDecoreDto homeDecoreDto = Mapper.Map<HomeDecoreDto>(homeDecore);
            return homeDecoreDto;
        }
    }
}
