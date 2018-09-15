using Code.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("All")]
    public class AuthorController : ConnectionContext
    {
        public AuthorController(DemoContext context) : base(context)
        { // context dc khởi tạo trong Class ConnectionContext
        }

        // GET: api/Author
        [HttpGet]
        public ActionResult<List<Author>> Get()
        {
            return _context.Authors.ToList();
        }

        // GET: api/Author/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public ActionResult<Author> Get(int id)
        {
            var au = _context.Authors.Find(id);

            if (au == null)
            {
                return NotFound();
            }
            return Ok(au);
        }

        // POST: api/Author
        [HttpPost]
        public IActionResult Post(Author au)
        {
            _context.Authors.Add(au);
            _context.SaveChanges();
            return CreatedAtRoute("GetAuthor", new { id = au.ID }, au);
        }

        // PUT: api/Author/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Author au)
        {
            var _au = _context.Authors.Find(id);

            if (_au == null)
            {
                return NotFound();
            }
            _au.FirstName = au.FirstName;
            _au.LastName = au.LastName;
            _context.Update(_au);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // ở đây mình k cho delete các cậu có thể làm delete nếu thích
            return new NotFoundObjectResult(new { messege = "you don't have permission" });
        }
    }
}