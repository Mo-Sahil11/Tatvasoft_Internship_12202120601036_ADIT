using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.DataAccess.Models;
using Books.DataAccess;
using Books.DataAccess.Repositories;

namespace Books.Services.Services
{
    public class BooksService
    {
        private readonly BooksRepository _booksRepository;

        public BooksService(BooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public List<Book> GetBooks()
        {
            return _booksRepository.GetBooks();
        }

        public Book GetBookById(int id)
        {
            return _booksRepository.GetBookById(id);
        }

        public void AddBook(Book book)
        {
            _booksRepository.AddBook(book);
        }

        public int UpdateBook(Book book)
        {
            return _booksRepository.UpdateBook(book);
        }

        public int DeleteBook(int id)
        {
            return _booksRepository.DeleteBook(id);
        }

        public List<Book> GetFilteredBooks(string genre)
        {
            return _booksRepository.GetFilteredBooks(genre);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _booksRepository.GetAllAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _booksRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
            return book;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            book.CreatedAt = DateTime.UtcNow;
            return await _booksRepository.AddAsync(book);
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var existingBook = await _booksRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            // Update properties
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.Description = book.Description;
            existingBook.PageCount = book.PageCount;
            existingBook.PublicationDate = book.PublicationDate;
            existingBook.ISBN = book.ISBN;
            existingBook.Price = book.Price;
            existingBook.IsAvailable = book.IsAvailable;
            existingBook.UpdatedAt = DateTime.UtcNow;

            return await _booksRepository.UpdateAsync(existingBook);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _booksRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            await _booksRepository.DeleteAsync(book);
        }
    }
}
