using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Code.Common;
using Code.JsonResult;
using Code.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("All")]
    public class BookController : ConnectionContext
    {
        public BookController(DemoContext context) : base(context)
        { 
        }

        [HttpGet("GetBookByTitle/{id}", Name = "GetBookByTitle")]
        public ActionResult<List<BookView>> GetAll(int id)
        {
            var book = _context.Books.Include(b => b.Title)
                .Where(b => b.TitleID == id)
                .Select(b => new BookView()
                {
                    ID = b.ID,
                    BarCode = b.BarCode,
                    Type = b.Type,
                    Page = b.Page,
                    Status = b.Status,
                    ShelveID = b.ShelveID
                })
                .ToList();
            return book;
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> Get(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/Book
        [HttpPost]
        public IActionResult Post(Book book)
        {
            int number = book.Quantity;
            string oldBarCode = _context.Books.Where(x => x.TitleID == book.TitleID).Select(x => x.BarCode).LastOrDefault();
          
            string[] getBarCode = GenerateBarCode.Generate(oldBarCode, book.TitleID, book.Type);

            string barCodeKey = getBarCode[0];
            string barCodeID = getBarCode[1];

            for (int i = 1; i <= number; i++) // sinh ra barcode tiếp theo
            {
                barCodeID = (int.Parse(barCodeID) + 1).ToString();
               
                Book b = new Book(book.Type, book.Page,book.Status,book.ShelveID,book.TitleID);
                b.BarCode = GenerateBarCode.CustomBarCodeID(barCodeKey, barCodeID);
                _context.Add(b);
                _context.SaveChanges();
            }
            return NoContent();
        }



        // PUT: api/Book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,Book book)
        {
            var b = _context.Books.Find(id);
            if (b != null)
            {
                b.Page = book.Page;
                b.ShelveID = book.ShelveID;
                b.Type = book.Type;
                b.Status = book.Status;
                _context.Books.Update(b);
                _context.SaveChanges();
                return new OkObjectResult(new { messegge = "thay đổi thành công" });
            }
            return BadRequest("khong");

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var b = _context.Books.Find(id);
            if (b != null)
            {
                _context.Books.Remove(b);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
