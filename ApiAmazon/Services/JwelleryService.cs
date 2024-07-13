using ApiAmazon.DTO;
using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using AutoMapper;

namespace ApiAmazon.Services
{
    public class JwelleryService : IJwelleryRepo
    {
        private readonly AmazonDbContext DB;
        IMapper Mapper;
        public JwelleryService(AmazonDbContext db, IMapper mapper)
        {
            DB = db;
            Mapper = mapper;
        }
        public List<JwelleryDto> GetAllList()
        {
            List<Jwellery> jwelleries = DB.Jwellery.ToList();
            List<JwelleryDto> jwelleryDtos = Mapper.Map<List<JwelleryDto>>(jwelleries);
            return jwelleryDtos;
        }

        public JwelleryDto InsertItems(JwelleryDto JwellDto)
        {
            Jwellery jwellery = Mapper.Map<Jwellery>(JwellDto);
            DB.Jwellery.Add(jwellery);
            DB.SaveChanges();
            JwelleryDto jwelleryDto = Mapper.Map<JwelleryDto>(jwellery);
            return jwelleryDto;
        }
    }
}
