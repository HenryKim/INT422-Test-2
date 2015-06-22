using int422TestTwo.Models;
using int422TestTwo.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace int422TestTwo.Controllers
{
    public class BookManager
    {
        private DataContext ds = new DataContext();

        // This function will create new Book
        public Book createBook(AddBook newItem)
        {
            //using auto mapper to create new Book from AddBook view
            Book book = Mapper.Map<Book>(newItem);

            ds.Book.Add(book);
            ds.SaveChanges();

            return book;
        }

        public BookBase getBookById(int Id)
        {
            //fetch ONE Book from collection
            // if Book id is null . function will return null
            // other wise fine matching id from collection and return my using auto mapping
            var fetchedBook = ds.Book.Find(Id);

            if (fetchedBook == null)
            {
                return null;
            }
            else
            {
                return Mapper.Map<BookBase>(fetchedBook);
            }
        }
        public IEnumerable<BookList> getAllBooks()
        {
            //fetch ALL Book from collection
            //return collection of Book by using auto mapper
            var fetchedBook = ds.Book.ToList();
            return Mapper.Map<IEnumerable<BookList>>(fetchedBook);
        }
        public bool DeleteBookById(int id)
        {
            /*
             * This fuction will find mathing id from collection
             * if there is matching id in DB
             * function will remove that Book from DB and return true
             * other wise it will return flase
             * this function will only return ture / or false
             */
            var fetchedBook = ds.Book.Find(id);

            if (fetchedBook == null)
            {
                return false;
            }
            else
            {
                ds.Book.Remove(fetchedBook);
                ds.SaveChanges();

                return true;
            }
        }


        public BookBase EditBook(BookBase newItem)
        {
            /*
             * this function will grant user to a edit Book's info from DB
             * this function receive a BookBase file and find matching Book 
             * Info from DB by matching id
             * if their is no matching Book in DB it will return null
             * other wise DB take new BookBase and saved and over write Book info at DB
             * by using auto mapper.
             */
            var fetchedBook = ds.Book.Find(newItem.Id);

            if (fetchedBook == null)
            {
                return null;
            }
            else
            {
                ds.Entry(fetchedBook).CurrentValues.SetValues(newItem);
                ds.SaveChanges();

                return Mapper.Map<BookBase>(fetchedBook);
            }
        }
    }
}