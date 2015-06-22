using int422TestTwo.Models;
using int422TestTwo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace int422TestTwo.Controllers
{
    public class BookController : Controller
    {
        private BookManager m = new BookManager();
        // m is the Book Manager variable


        
        public ActionResult Index()
        {
            // this function will get ALL fetched Book from DB(Book Manager) and pass to View 
            return View(m.getAllBooks());
        }

        //[Authorize(Roles = "Admin")] // Set the authorized roles to access
        public ActionResult Create()
        {
            return View(); // This page will end it to Create.
        }

        // this function use HttpPost method
        [HttpPost]
        //[Authorize(Roles = "Admin")]// Set the authorized roles to access
        public ActionResult Create(AddBook newItem)
        {
            if (ModelState.IsValid) // if model state is valid
            {
                m.createBook(newItem); // will send Book infro to Book manager to save in DB
                return RedirectToAction("index"); // and redirect to view page
            }
            else
            {
                return View(newItem); // if state is not valide it ll just return to view page with Book info sented.
            }
        }


        
        public ActionResult Details(int id)
        {
            var fetchedBook = m.getBookById(id); // this is detail view page of Book ordered by ID
            // can access this viewpage by using Book number INCLUDED
            // this Details are same from LAB works ( does not need additional comments...)

            if (fetchedBook == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedBook);
            }
        }

        // GET: /Book/Delete/5
        [Authorize(Roles = "Administrator")]// Set the authorized roles to access
        public ActionResult Delete(int? id)
        {
            //this function will grant Authorized user to an use function of delete
            // this function are same from LAB work.
            BookBase delete = m.getBookById(id.GetValueOrDefault());

            if (delete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(delete);
            }
        }

        // POST: /Book/Delete/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]// Set the authorized roles to access
        public ActionResult Delete(int id)
        {
            //this function will grant Authorized user to an use function of delete
            // this function are same from LAB work.

            if (m.DeleteBookById(id))
            {
                // if delete was successful will send this message

                TempData["statusMessage"] = "This Book was deleted.";
            }
            else
            {
                // if delete was NOT successful will send this message
                TempData["statusMessage"] = "Unable to delete this Book.";
            }
            return RedirectToAction("details", new { id = id });
        }

        // GET: /Book/Edit/5
        [Authorize(Roles = "Administrator")]// Set the authorized roles to access
        public ActionResult Edit(int id)
        {
            // this function will grant Authorized user to use function of Edit Book
            // this function are same from LAB work.

            BookBase fetchedBook = m.getBookById(id);

            if (fetchedBook == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(fetchedBook);
            }
        }



        // POST: /Book/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]// Set the authorized roles to access
        public ActionResult Edit(int id, BookBase newItem)
        {
            // this function will grant Authorized user to use function of Edit Book
            if (ModelState.IsValid & id == newItem.Id)
            {
                BookBase editedItem = m.EditBook(newItem);

                if (editedItem == null)
                {
                    //  there was ERROR occured during edit
                    return View(newItem);
                }
                else
                {
                    // The Edit was successful, Book info has been edited.
                    TempData["statusMessage"] = "Edits have been saved.";
                    return RedirectToAction("details", new { id = editedItem.Id });
                }
            }
            else
            {

                return View(newItem);
            }
        }
    }
}