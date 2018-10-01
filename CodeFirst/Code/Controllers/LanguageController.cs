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
    public class LanguageController : ConnectionContext
    {
        public LanguageController(DemoContext context) : base(context)
        { // context dc khởi tạo trong Class ConnectionContext
        }
        // GET: api/langlisher
        [HttpGet]
        public ActionResult<List<LanguageView>> Get()
        {
            return _context.Languages.Select(x=> new LanguageView {
                ID = x.ID,
                Name = x.Name
            }).ToList();

        }

        // GET: api/langlisher/5
        [HttpGet("{id}", Name = "GetLanguage")]
        public ActionResult<Language> Get(int id)
        {
            var lang = _context.Languages.Find(id);

            if (lang == null)
            {
                return NotFound();
            }
            return Ok(lang);
        }

        // POST: api/langlisher
        [HttpPost]
        public IActionResult Post(Language lang)
        {
            _context.Languages.Add(lang);
            _context.SaveChanges();
            return CreatedAtRoute("GetLanguage", new { id = lang.ID }, lang);
        }

        // PUT: api/langlisher/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Language lang)
        {

            var _lang = _context.Languages.Find(id);

            if (_lang == null)
            {
                return NotFound();
            }
            _lang.Name = lang.Name;
            _context.Update(_lang);
            _context.SaveChanges();
            return NoContent();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var lang = _context.Languages.Find(id);

            if (lang == null)
                return NotFound();
            _context.Languages.Remove(lang);
            _context.SaveChanges();
            return new OkObjectResult(new { Status = "Xong" });
        }


    }
}
