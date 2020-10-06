using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCore.BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCore.BookStore.Controllers
{
    public class BookController : Controller, IDisposable
    {
        ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(context.Books.ToList());
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = context.Books.FirstOrDefault(b => b.Id == id);
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Details(int id, Book book, string borrow, string retrieve)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            if (!string.IsNullOrEmpty(borrow))
            {
                if (book.CopiesNumber == book.BorrowedCopies)
                {
                    ErrorViewModel evm = new ErrorViewModel
                    {
                        RequestId = "No Copies to Borrow for this Book."
                    };
                    return View("Error", evm);
                }

                book.BorrowedCopies++;
                book.CopiesLeft--;
            }
            if (!string.IsNullOrEmpty(retrieve))
            {
                if (book.CopiesLeft == book.CopiesNumber)
                {
                    ErrorViewModel evm = new ErrorViewModel
                    {
                        RequestId = $"This Copy Doesn't Belong to Us. We Have The Whole Set Of Our Copies In The Library"
                    };
                    return View("Error", evm);
                }

                book.CopiesLeft++;
                book.BorrowedCopies--;
            }
            context.Books.Update(book);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public new void Dispose()
        {
            context = null;
            base.Dispose();
        }
    }
}
