﻿using Models;

using Microsoft.EntityFrameworkCore;
using books_api.Exceptions;

namespace books_api.Data.Repositories.Impl
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                                 .Include(b=> b.Author)
                                 .Include(b => b.Genre)
                                 .ToListAsync();
        }

        public async Task<Book> FindAsync(Guid id)
        {
            return await _context.Books
                                  .Include(b => b.Author)
                                  .Include(b => b.Genre)
                                  .FirstOrDefaultAsync(b => b.Id == id)
                        ?? throw new EntityNotFoundException($"Book with id: '{id}' not found.");
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsTitleAndAuthorAsync(Book book)
        {
            return await _context.Books
                .AnyAsync(b => b.Title == book.Title && b.AuthorId == book.AuthorId);
        }
    }
}
