using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.JsonResult;
using Code.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("All")]
    public class PublisherController : ConnectionContext
    {
        public PublisherController(DemoContext context) : base(context)
        { // context dc khởi tạo trong Class ConnectionContext
        }
        // GET: api/Publisher
        [HttpGet]
        public ActionResult<List<Publisher>> Get()
        {
            return _context.Publishers.ToList();
        }
        [HttpGet("shortpublisher")]
        public ActionResult<List<ShortPublisherView>> GetShortPublisher()
        {
            return _context.Publishers
                .Select(    x=> new ShortPublisherView() {
                ID = x.ID,
                Name = x.Name
            } ).ToList();

        }

        // GET: api/Publisher/5
        [HttpGet("{id}", Name = "GetPublisher")]
        public ActionResult<Publisher> Get(int id)
        {
            var pub = _context.Publishers.Find(id);

            if (pub == null)
            {
                return NotFound();
            }
            return Ok(pub);
        }

        // POST: api/Publisher
        [HttpPost]
        public IActionResult Post(Publisher pub)
        {
            _context.Publishers.Add(pub);
            _context.SaveChanges();
            return CreatedAtRoute("GetPublisher", new { id = pub.ID }, pub);
        }

        // PUT: api/Publisher/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Publisher pub)
        {
            var _pub = _context.Publishers.Find(id);

            if (_pub == null)
            {
                return NotFound();
            }
            _pub.Name = pub.Name;
            _pub.Email = pub.Email;
            _pub.Address = pub.Address;

            _context.Update(_pub);
            _context.SaveChanges();
            return NoContent();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pub = _context.Publishers.Find(id);

            if (pub == null)
                return NotFound();
            _context.Publishers.Remove(pub);
            _context.SaveChanges();
            return new OkObjectResult(new { Status = "Xong" });
        }

    }
}
