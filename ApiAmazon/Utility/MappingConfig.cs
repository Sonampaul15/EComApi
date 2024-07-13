using ApiAmazon.DTO;
using ApiAmazon.Models;
using AutoMapper;

namespace ApiAmazon.Utility
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
         var mappingConfig = new MapperConfiguration(Config =>
         {
             Config.CreateMap<Cosmetics,CosmeticsDto>().ReverseMap();
             Config.CreateMap<Jwellery,JwelleryDto>().ReverseMap();
             Config.CreateMap<Books,BooksDto>().ReverseMap();
             Config.CreateMap<Clothing,ClothingDto>().ReverseMap();
             Config.CreateMap<HomeDecore,HomeDecoreDto>().ReverseMap();
             Config.CreateMap<Homefurnishing,HomeFurnishingDto>().ReverseMap();
             Config.CreateMap<Kitchen,KitchenDto>().ReverseMap();
             Config.CreateMap<Electronics,ElectronicsDto>().ReverseMap();
             Config.CreateMap<Grocery,GroceryDto>().ReverseMap();
         });
            return mappingConfig;
        }
    }
}
