using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("All")]
    [ApiController]
   
    public class LibrarianController : ConnectionContext
    {
        public LibrarianController(DemoContext context) : base(context)
        { // context dc khởi tạo trong Class ConnectionContext
        }
        // GET: api/Librarian
        [HttpGet]
        public ActionResult<List<Librarian>> Get()
        {
            return  _context.Librarians.ToList();
        }

        // GET: api/Librarian/5
        [HttpGet("{id}", Name = "GetLibrarian")]
        public ActionResult<Librarian> Get(int id)
        {
            var lib = _context.Librarians.Find(id);
            
            if (lib == null)
            {
                return NotFound();
            }
            return Ok(lib);
        }

        // POST: api/Librarian
        [HttpPost]
        public IActionResult Post(Librarian lib)
        {
            _context.Librarians.Add(lib);
            _context.SaveChanges();
            return CreatedAtRoute("GetLibrarian", new { id = lib.ID},lib);
        }

        // PUT: api/Librarian/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Librarian lib)
        {
            var _lib = _context.Librarians.Find(id);
            if (_lib == null)
            {
                return NotFound();
            }
            _lib.FirstName = lib.FirstName;
            _lib.LastName = lib.LastName;
            _lib.Gender = lib.Gender;
            _lib.Status = lib.Status;
            _lib.Email = lib.Email;
            _lib.Phone = lib.Phone;
            _context.Update(_lib);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // ở đây mình k cho delete các cậu có thể làm delete nếu thích
            return new NotFoundObjectResult( new { messege = "you don't have permission" });
        }

    }
}
