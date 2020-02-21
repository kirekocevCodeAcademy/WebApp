using Core.Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainData.Library.SqlData
{
    public class BookDataSql : IBookData
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookDataSql(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public Book Create(Book book)
        {
            libraryDbContext.Book.Add(book);
            return book;
        }

        public Book GetBookById(int bookId)
        {
            return libraryDbContext.Book
                .Include(b => b.Author)
                .SingleOrDefault(b => b.Id == bookId);
        }

        public Book Update(Book book)
        {
            libraryDbContext.Entry(book).State = EntityState.Modified;
            return book;
        }

        public int Commit()
        {
            return libraryDbContext.SaveChanges();
        }

        public IEnumerable<Book> GetBooksByTitle(string searchTerm = null)
        {
            return libraryDbContext.Book
                .Include(b => b.Author)
                .Where(r => string.IsNullOrEmpty(searchTerm) || r.Title.ToLower().StartsWith(searchTerm.ToLower()))
                .OrderBy(r => r.Title);
        }

        public IEnumerable<Book> GetBooks(string authorName = null, string bookTitle = null)
        {
            return libraryDbContext.Book
                .Include(b => b.Author)
                .Where(b =>
                        (string.IsNullOrEmpty(bookTitle) || b.Title.ToLower().StartsWith(bookTitle.ToLower()))
                        && (string.IsNullOrEmpty(authorName) || b.Author.FirstName.StartsWith(authorName) || b.Author.LastName.StartsWith(authorName)))
                .OrderBy(b => b.Title)
                .ToList();
        }
    }
}
