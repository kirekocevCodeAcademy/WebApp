using System.Collections.Generic;
using System.Linq;
using Core.Library;

namespace DomainData.Library.InMemoryData
{
    public class BookDataInMemory : IBookData
    {
        private List<Book> books;

        public BookDataInMemory()
        {
            books = new List<Book>();
        }

        public Book Create(Book book)
        {
            book.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            books.Add(book);

            return book;
        }

        public Book GetBookById(int bookId)
        {
            return books.SingleOrDefault(b => b.Id == bookId);
        }

        public Book Update(Book book)
        {
            var tempBook = books.SingleOrDefault(b => b.Id == book.Id);
            if (tempBook != null)
            {
                tempBook.Author = book.Author;
                tempBook.PersonId = book.PersonId;
                tempBook.Title = book.Title;
            }

            return tempBook;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Book> GetBooksByTitle(string searchTerm = null)
        {
            return books
                .Where(r => string.IsNullOrEmpty(searchTerm) || r.Title.ToLower().StartsWith(searchTerm.ToLower()))
                .OrderBy(r => r.Title);
        }

        public IEnumerable<Book> GetBooks(string authorName = null, string bookTitle = null)
        {
            var result = new List<Book>();
            foreach (var book in books)
            {
                if ((string.IsNullOrEmpty(bookTitle) || book.Title.StartsWith(bookTitle))
                    && (string.IsNullOrEmpty(authorName) || book.Author.FirstName.StartsWith(authorName) || book.Author.LastName.StartsWith(authorName)))
                {
                    result.Add(book);
                }
            }

            return result;
        }
    }
}
