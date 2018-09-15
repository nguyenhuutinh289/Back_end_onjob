

using Code.JsonResult;
using Code.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ConnectionContext
    {
        public TitleController(DemoContext context) : base(context)
        { // context dc khởi tạo trong Class ConnectionContext
        }

        // GET: .../Title/id
        [HttpGet("{id}")]
        public ActionResult<List<TitleViewAll>> Get(int id)
        { // class TitleViewAll để định dạng dữ liệu file json trả về cho api
            // đc gọi khi t gửi id của title lên để get về chi tiết của tile
            // Ctr + Click vao Class de xem danh sach property
            var list = (from t in _context.Titles
                        where t.ID == id
                        select new TitleViewAll()
                        {
                            ID = t.ID,
                            Code = t.Code,
                            Name = t.Name,
                            Content = t.TableOfContent,
                            Description = t.Description,
                            Edition = t.Edition,
                            ISBN = t.ISBN,
                            Image = t.Image,
                            Price = t.Price,
                            PublishDate = t.PublishingDate,

                            Language = (from l in _context.Languages
                                        where t.LanguageID == l.ID
                                        select l.Name).FirstOrDefault(),
                            Publisher = (from p in _context.Publishers
                                         where t.LanguageID == p.ID
                                         select p.Name).FirstOrDefault(),
                            Categories = (from ct in _context.CategoryTitles
                                          join c in _context.Categories 
                                          on ct.CategoryID equals c.ID
                                          where t.ID == ct.TitleID
                                          select c.Name
                                    ).ToList(), // danh sach category

                            Authors = (from at in _context.AuthorTitles
                                       join a in _context.Authors
                                       on at.AuthorID equals a.ID
                                       where t.ID == at.TitleID
                                       select ($"{a.FirstName} {a.LastName}")
                                    ).ToList(), // danh sach tac gia
                        }).ToList();

            return list;
        }

       
        [HttpGet("shorttitle")]
        // nghĩa là localhost:.../Title/shorttile
        public ActionResult<List<ShortTitle>> GetTitle()
        { // dùng để get 3 trường của bảng title để đọc sách ra trang User
            var list = (from t in _context.Titles
                        select new ShortTitle()
                        {
                            ID = t.ID,
                            Name = t.Name,
                            Image = t.Image
                        }).ToList();
            return list;
        }

        // POST: api/Title
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Title/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}