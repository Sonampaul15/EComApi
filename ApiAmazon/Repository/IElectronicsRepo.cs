using ApiAmazon.DTO;
using ApiAmazon.Models;

namespace ApiAmazon.Repository
{
    public interface IElectronicsRepo
    {
        List<ElectronicsDto> GetAllElectronics();

        ElectronicsDto InsertElectronic(ElectronicsDto EleDto);
    }
}
