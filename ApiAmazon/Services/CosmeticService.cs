using ApiAmazon.DTO;
using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using AutoMapper;

namespace ApiAmazon.Services
{
    public class CosmeticService : ICosmeticRepo
    {
        private readonly AmazonDbContext DB;
        IMapper Mapper;

        public CosmeticService(AmazonDbContext db, IMapper mapper)
        {
            DB= db;
            Mapper = mapper;
        }
        public List<CosmeticsDto> GetAllList()
        {
            List<Cosmetics> cosmetic = DB.cosmetics.ToList();
            List<CosmeticsDto> cosmeticdto=Mapper.Map<List<CosmeticsDto>>(cosmetic);
            return cosmeticdto;
        }

        public CosmeticsDto InsertItem(CosmeticsDto cosDto)
        {
            Cosmetics Cos=Mapper.Map<Cosmetics>(cosDto);
            DB.cosmetics.Add(Cos);
            DB.SaveChanges();
            CosmeticsDto dto = Mapper.Map<CosmeticsDto>(Cos);
            return dto;
        }
    }
}
