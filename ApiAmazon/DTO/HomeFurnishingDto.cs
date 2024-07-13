using System.ComponentModel.DataAnnotations;

namespace ApiAmazon.DTO
{
    public class HomeFurnishingDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;
       
        public string Description { get; set; } = string.Empty;
       
        public string Price { get; set; } = string.Empty;
        
        public string Brand { get; set; } = string.Empty;
    }
}
