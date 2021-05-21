using BookStore.Data.Interfaces;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Data.Repositories
{
    public class BookDatabase : IBookRepository
    {
        private BookStoreContext db;

        public BookDatabase(BookStoreContext _db)
        {
            this.db = _db;
        }

        public bool AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return true;
        }

        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public string GetAuthorByID(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id).Author;
        }

        public Book GetBook(int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }

        public Book GetBookByAuthorandYear(string name, int year)
        {
            return db.Books.FirstOrDefault(x => x.Author.Contains(name) && x.PublicationYear == year);
        }

        public List<Book> GetBooksByAuthor(string name)
        {
            return db.Books.Where(x => x.Author.Contains(name)).ToList();
        }

        public bool RemoveBook(int id)
        {
            var book = GetBook(id);
            if (book == null)
                return false;
            else
            {
                db.Books.Remove(book);
                db.SaveChanges();
                return true;

            }
        }

     

        public List<Book> UpdateBook(int id, Book book)
        {
            if(this.RemoveBook(id))
            {
                db.Books.Add(book);
                db.SaveChanges();
                
                   
            }

            return db.Books.ToList();

        }


    }
}
