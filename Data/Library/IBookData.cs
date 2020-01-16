using System.Collections.Generic;
using Core.Library;

namespace DomainData.Library
{
    public interface IBookData
    {
        Book Create(Book book);
        Book GetBookById(int bookId);
        Book Update(Book book);
        int Commit();
        IEnumerable<Book> GetBooksByTitle(string searchTerm = null);
        IEnumerable<Book> GetBooks(string authorName = null, string bookTitle = null);

    }
}
