using ApiAmazon.DTO;
using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using AutoMapper;

namespace ApiAmazon.Services
{
    public class HomeFurnishingService : IHomeFurnishingRepo
    {
        private readonly AmazonDbContext Db;
        IMapper mapper;
        public HomeFurnishingService(AmazonDbContext _Db, IMapper _mapper)
        {
            Db = _Db;
            mapper = _mapper;
        }
        public List<HomeFurnishingDto> GetAllList()
        {
            List<Homefurnishing> homefurnishings = Db.Furnishing.ToList();
            List<HomeFurnishingDto> furnishingDtos = mapper.Map<List<HomeFurnishingDto>>(homefurnishings);
            return furnishingDtos;
        }

        public HomeFurnishingDto InsertItems(HomeFurnishingDto HFDto)
        {
            Homefurnishing home = mapper.Map<Homefurnishing>(HFDto);
            Db.Add(home);
            Db.SaveChanges();
            HomeFurnishingDto home1= mapper.Map<HomeFurnishingDto>(home);
            return home1;   
        }
    }
}
