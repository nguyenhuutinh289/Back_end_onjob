using Code.JsonResult;
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
        [HttpGet("fullname")]
        public ActionResult<List<AuthorFullNameView>> GetFullName()
        {
            var query = (from author in _context.Authors
                         select new AuthorFullNameView()
                         {
                             ID = author.ID,
                             FullName = $"{author.FirstName} {author.LastName}"
                         }
                         ).ToList();
            return query;
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
            var au = _context.Authors.Find(id);

            if (au == null)
                return NotFound();
            _context.Authors.Remove(au);
            _context.SaveChanges();
            return new OkObjectResult(new { Status = "Xong" });
        }
    }
}