using ApiAmazon.DTO;
using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using AutoMapper;

namespace ApiAmazon.Services
{
    public class ElectronicService : IElectronicsRepo
    {
        private readonly AmazonDbContext DB;
        IMapper Mapper;
        public ElectronicService(AmazonDbContext _DB, IMapper _Mapper)
        {
            DB = _DB;
            Mapper = _Mapper;
        }
        public List<ElectronicsDto> GetAllElectronics()
        {
           List<Electronics> Elect =DB.Electronics.ToList();
           List<ElectronicsDto> ElectDto = Mapper.Map<List<ElectronicsDto>>(Elect);
           return ElectDto;
        }

        public ElectronicsDto InsertElectronic(ElectronicsDto EleDto)
        {
            Electronics electronics = Mapper.Map<Electronics>(EleDto);
            DB.Electronics.Add(electronics);
            DB.SaveChanges();
            ElectronicsDto electronics1 = Mapper.Map<ElectronicsDto>(EleDto);
            return electronics1;
        }
    }
}
