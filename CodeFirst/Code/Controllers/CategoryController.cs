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
    [ApiController]
    [EnableCors("All")]
    public class CategoryController : ConnectionContext
    {
        public CategoryController(DemoContext context) : base(context)
        { // context dc khởi tạo trong Class ConnectionContext
        }

        // GET: api/catethor
        [HttpGet]
        public ActionResult<List<Category>> Get()
        {
            return _context.Categories.ToList();
        }

        // GET: api/catethor/5
        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<Category> Get(int id)
        {
            var cate = _context.Categories.Find(id);

            if (cate == null)
            {
                return NotFound();
            }
            return Ok(cate);
        }

        // POST: api/catethor
        [HttpPost]
        public IActionResult Post(Category cate)
        {
            _context.Categories.Add(cate);
            _context.SaveChanges();
            return CreatedAtRoute("GetCategory", new { id = cate.ID }, cate);
        }

        // PUT: api/catethor/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Category cate)
        {
            var _cate = _context.Categories.Find(id);

            if (_cate == null)
            {
                return NotFound();
            }
            _cate.Name = cate.Name;
            _cate.Description = cate.Description;
            _context.Update(_cate);
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
