using ApiAmazon.DTO;
using ApiAmazon.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace ApiAmazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmazonController : ControllerBase
    {
        private readonly ICosmeticRepo cosmeticRepo;
        private readonly IHomeFurnishingRepo furnishingRepo;
        private readonly IBookRepo bookRepo;
        private readonly IClothesRepo clothesRepo;
        private readonly IJwelleryRepo jwelleryRepo;
        private readonly IKitchenRepo kitchenRepo;
        private readonly IHomeDecorRepo decorRepo;
        private readonly IGroceryRepo groceryRepo;
        private readonly IElectronicsRepo electronicsRepo;
        private readonly ResponseDto response;

        public AmazonController(ICosmeticRepo _cosmeticRepo, IHomeFurnishingRepo _furnishingRepo, IBookRepo _bookRepo, IClothesRepo _clothesRepo, IJwelleryRepo _jwelleryRepo, IKitchenRepo _kitchenRepo, IHomeDecorRepo _decorRepo, IGroceryRepo _groceryRepo, IElectronicsRepo _electronicsRepo)
        {
            cosmeticRepo = _cosmeticRepo;
            furnishingRepo = _furnishingRepo;
            bookRepo = _bookRepo;
            clothesRepo = _clothesRepo;
            jwelleryRepo = _jwelleryRepo;
            kitchenRepo = _kitchenRepo;
            decorRepo = _decorRepo;
            groceryRepo = _groceryRepo;
            response = new ResponseDto();
            electronicsRepo = _electronicsRepo;
        }

        [HttpGet("Cosmetics")]

        public ResponseDto GetAllCosmetics()
        {
            List<CosmeticsDto> CosDto = cosmeticRepo.GetAllList();
            response.Result= CosDto;
            return response;
        }

        [HttpPost("Cosmetics")]

        public ResponseDto InsertCosmetics([FromBody]CosmeticsDto dto) 
        {
            try
            {
                if(!string.IsNullOrEmpty(dto.ProductName)&& !string.IsNullOrEmpty(dto.Brand))
                {
                    CosmeticsDto cosmeticsDto = cosmeticRepo.InsertItem(dto);
                    response.Result= cosmeticsDto;
                }
                else
                {
                    response.Message = "Data Should Be Filled";
                }
            }
            catch (  Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("homeFurnishing")]

        public ResponseDto GetAllFurnishing()
        {
            List<HomeFurnishingDto> homes = furnishingRepo.GetAllList();
            response.Result = homes;
            return response;

        }

        [HttpPost("homefurnishing")]
        public ResponseDto InsertItems([FromBody]HomeFurnishingDto dto) 
        {
            try
            {
                if(!string.IsNullOrEmpty(dto.ProductName) && !string.IsNullOrEmpty(dto.Brand))
                {
                   HomeFurnishingDto homeFurnishing = furnishingRepo.InsertItems(dto);
                    response.Result= homeFurnishing;
                }
                else
                {
                    response.Message = "Data Should Be Filled";
                }
            }
            catch (Exception ex)
            {

                response.Result = false;
                response.Message = ex.Message;
            }
            return response;
        
        }

        [HttpGet("Books")]

        public ResponseDto GetAllBooks()
        {
            List<BooksDto> BD = bookRepo.GetBooks();
            response.Result = BD;
            return response;
        }

        [HttpGet("Bookbyid")]
        public ResponseDto GetBookByID(int id)
        {
            BooksDto books = bookRepo.GetBooksById(id);
            response.Result = books;
            return response;
        }

        [HttpPost("Books")]
        public ResponseDto InsertBooks([FromBody]BooksDto dto) 
        {
            try
            {
                if (!string.IsNullOrEmpty(dto.ProductName) && !string.IsNullOrEmpty(dto.Author))
                {
                    BooksDto BukDto = bookRepo.InsertItems(dto);
                    response.Result = BukDto;
                }
                else
                {
                    response.Message = "Data Should Be Field";
                }
            }
            catch (Exception ex)
            {

                response.Result = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("Clothes")]
        public ResponseDto GetAllClothes() 
        {
            List<ClothingDto> clothings = clothesRepo.GetAllList();
            response.Result= clothings;
            return response;
        
        }

        [HttpPost("Clothes")]

        public ResponseDto InseretClothes([FromBody] ClothingDto dto)
        {
            try
            {
                if(!string.IsNullOrEmpty(dto.ProductName)&& !string.IsNullOrEmpty(dto.Brand))
                {
                    ClothingDto clothingDto = clothesRepo.InsertItems(dto);
                    response.Result = clothingDto;
                }
            }
            catch (Exception ex)
            {

                response.Result= false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("Jwellery")]
        public ResponseDto GetJwellery()
        {
            List<JwelleryDto> jwelleries = jwelleryRepo.GetAllList();
            response.Result= jwelleries;
            return response;
        }

        [HttpPost("Jwellery")]
        public ResponseDto InsertJwellery([FromBody] JwelleryDto dto)
        {
            try
            {
                if(!string.IsNullOrEmpty(dto.ProductName)&& !string.IsNullOrEmpty(dto.Brand))
                {
                    JwelleryDto jwelleryDto = jwelleryRepo.InsertItems(dto);
                    response.Result=jwelleryDto;
                }
                else
                {
                    response.Message = "Data Should be Filed";
                }
            }
            catch (Exception ex)
            {

                response.Result= false; 
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("Kitchen")]
        public ResponseDto GetAllKitchen() 
        {
            List<KitchenDto> dtos = kitchenRepo.GetAllList();
            response.Result= dtos;
            return response;
        }

        [HttpPost("Kitchen")]

        public ResponseDto InsertKitchen([FromBody] KitchenDto dto)
        {
            try
            {
                if(!string.IsNullOrEmpty(dto.ProductName) && !string.IsNullOrEmpty(dto.Brand))
                {
                    KitchenDto kitchenDto1 = kitchenRepo.InsertItems(dto);
                    response.Result= kitchenDto1;
                }
            }
            catch (Exception ex)
            {

                response.Result = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("HomeDecore")]
        public ResponseDto GetAllHomeDecore()
        {
            List<HomeDecoreDto> decoreDtos = decorRepo.GetAllList();
            response.Result= decoreDtos;
            return response;
        }

        [HttpPost("HomeDecore")]

        public ResponseDto InsertHomeDecore([FromBody] HomeDecoreDto dto)
        {
            try
            {
                if(!string.IsNullOrEmpty(dto.ProductName)&& !string.IsNullOrEmpty(dto.Brand))
                {
                    HomeDecoreDto dto1 = decorRepo.InsertItems(dto);
                    response.Result= dto1;
                }
                else
                {
                    response.Message = "Data Should Be Filled";
                }
              
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Message = ex.Message;
            }
            return response;
        }
        
        [HttpGet("Grocery")]
        public ResponseDto GetAllgrocery()
        {
            List<GroceryDto> groceries1 = groceryRepo.GetAllGrocery();
            response.Result= groceries1;
            return response;
        }
        [HttpPost("Grocery")]
        public ResponseDto InsertGrocery([FromBody] GroceryDto dto)
        {
            try
            {
                if(!string.IsNullOrEmpty(dto.ProductName)&& !string.IsNullOrEmpty(dto.Brand))
                {
                    GroceryDto groceryDto1 = groceryRepo.InsertItems(dto);
                    response.Result= groceryDto1;
                }
                else
                {
                    response.Message = "Data Should be Filled";
                }
            }
            catch (Exception ex)
            {

                response.Result = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpGet("Electronics")]
        public ResponseDto GettAllElectronics()
        {
            List<ElectronicsDto> electronicsDtos = electronicsRepo.GetAllElectronics();
            response.Result= electronicsDtos;
            return response;
        }

        [HttpPost("Electronics")]
        public ResponseDto InsertElectronics([FromBody] ElectronicsDto dto)
        {
            try
            {
                if (!string.IsNullOrEmpty(dto.ProductName)&&!string.IsNullOrEmpty(dto.Brand))
                {
                    ElectronicsDto ElectDto = electronicsRepo.InsertElectronic(dto);
                    response.Result= ElectDto;
                }
            }
            catch (Exception ex)
            {

                response.Result = false;
                response.Message = ex.Message;
            }
            return response;
        }
      
    }
}
