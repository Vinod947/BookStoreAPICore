using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Data.Models;
namespace BookStore.Data.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBook(int id);

        bool AddBook(Book book);

        bool RemoveBook(int id);

        List<Book> UpdateBook(int id, Book book);

        List<Book> GetBooksByAuthor(string name);

        string GetAuthorByID(int id);

        Book GetBookByAuthorandYear(string name, int year);


    }
}
