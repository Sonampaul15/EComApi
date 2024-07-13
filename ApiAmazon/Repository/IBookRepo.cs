using ApiAmazon.DTO;

namespace ApiAmazon.Repository
{
    public interface IBookRepo
    {
        List<BooksDto> GetBooks();

        BooksDto GetBooksById(int Id);

        BooksDto InsertItems(BooksDto booksDto);
    }
}
