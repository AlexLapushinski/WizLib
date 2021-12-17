﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;
using WizLib_Model.ViewModels;

namespace WizLib.Controllers
{
    public class BookController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ApplicationDBContext _db;

        public BookController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Book> objList = _db.Books.Include(u => u.Publisher).ToList(); // best way including Publishers
            //foreach(var obj in objList)
            //{
            //    // not good way, many selects to DB
            //    //obj.Publisher = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == obj.Publisher_id);

            //    // better way with less ways to DB:
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();
            //}
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM obj = new BookVM();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });
            if (id == null)
            {
                return View(obj);
            }
            obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM obj)
        {
            if (obj.Book.Book_Id == 0)
            {
                // create
                _db.Books.Add(obj.Book);
            }
            else
            {
                // update
                _db.Books.Update(obj.Book);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            BookVM obj = new BookVM();
            
            if (id == null)
            {
                return View(obj);
            }
            // for edit
            obj.Book = _db.Books.Include(u => u.BookDetail).FirstOrDefault(u => u.Book_Id == id);
            //obj.Book.BookDetail = _db.BookDetails.FirstOrDefault(u => u.BookDetail_Id == obj.Book.BookDetail_id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookVM obj)
        {
            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                // create
                _db.BookDetails.Add(obj.Book.BookDetail);
                _db.SaveChanges();
                var BookFromDB = _db.Books.FirstOrDefault(u => u.Book_Id == obj.Book.Book_Id);
                BookFromDB.BookDetail_id = obj.Book.BookDetail.BookDetail_Id;
                _db.SaveChanges();
            }
            else
            {
                // update
                _db.BookDetails.Update(obj.Book.BookDetail);
                _db.SaveChanges();
            }
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {            
            var obj = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            _db.Books.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PlayGround()
        {
            var bookTemp = _db.Books.FirstOrDefault();
            bookTemp.Price = 100;

            var bookCollection = _db.Books;
            double totalPrice = 0;

            foreach (var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            var bookList = _db.Books.ToList();
            foreach (var book in bookList)
            {
                totalPrice += book.Price;
            }

            var bookCollection2 = _db.Books;
            var bookCount1 = bookCollection2.Count();

            var bookCount2 = _db.Books.Count();

            IEnumerable<Book> BookList1 = _db.Books; // IEnumerable filtering on client side
            var FilteredBooks1 = BookList1.Where(b => b.Price > 500).ToList();

            IQueryable<Book> BookList2 = _db.Books; // IQueryable filtering on server side
            var FilteredBooks2 = BookList2.Where(b => b.Price > 500).ToList();

            var category = _db.Categories.FirstOrDefault();
            _db.Entry(category).State = EntityState.Modified;  // update state manually
            _db.SaveChanges();

            // update related data
            var BookTemp1 = _db.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Book_Id == 2);
            BookTemp1.BookDetail.NumberOfChapters = 23423;
            _db.Update(BookTemp1);
            _db.SaveChanges();

            var BookTemp2 = _db.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Book_Id == 2);
            BookTemp2.BookDetail.Weight = 22;
            _db.Attach(BookTemp2);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
