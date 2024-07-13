using ApiAmazon.DTO;
using ApiAmazon.Models;
using ApiAmazon.Repository;
using ApiAmazon.Utility;
using AutoMapper;

namespace ApiAmazon.Services
{
    public class BookService : IBookRepo
    {
        private readonly AmazonDbContext DB;
        IMapper Mapper;

        public BookService(AmazonDbContext _DB, IMapper _Mapper)
        {
            DB = _DB;
            Mapper = _Mapper;
        }
        public List<BooksDto> GetBooks()
        {
            List<Books> books = DB.books.ToList();
            List<BooksDto> booksDtos = Mapper.Map<List<BooksDto>>(books);
            return booksDtos;
        }

        
        public BooksDto GetBooksById(int Id)
        {
           Books dto = DB.books.First(x=>x.Id==Id);
           BooksDto dto1 = Mapper.Map<BooksDto>(dto);
           return dto1;
        }

        public BooksDto InsertItems(BooksDto booksDto)
        {
            Books books1 = Mapper.Map<Books>(booksDto);
            DB.books.Add(books1); 
            DB.SaveChanges();
            BooksDto booksDto1 = Mapper.Map<BooksDto>(books1);
            return booksDto1;
        }
    }
}
