using System.ComponentModel.DataAnnotations;

namespace ApiAmazon.DTO
{
    public class BooksDto
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }=string.Empty;
        [Required]
        public string Description { get; set; }= string.Empty;
        [Required]
        public string Price { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
    }
}
