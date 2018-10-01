

using Code.JsonResult;
using Code.Models;
using Code.ModelsView;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("All")]
    public class TitleController : ConnectionContext
    {
        public TitleController(DemoContext context) : base(context)
        { // context dc khởi tạo trong Class ConnectionContext
        }

        // GET: .../Title/id
        [HttpGet("{id}", Name = "GetTitleViewAll")] // 
        public ActionResult<TitleViewAll> Get(int id)
        { // class TitleViewAll để định dạng dữ liệu file json trả về cho api
            // đc gọi khi t gửi id của title lên để get về  tile sử dụng để edit
            // Ctr + Click vao Class de xem danh sach property
            var titleView = _context.Titles.Where(x => x.ID == id)
                .Select(t => new TitleView(t.ID, t.Code, t.Name, t.TableOfContent, t.Description,
                           t.Edition, t.ISBN, t.Image, t.Price, t.PublishingDate, t.LanguageID, t.PublisherID)
                        ).FirstOrDefault();

            var categories = _context.CategoryTitles
                .Where(x => x.TitleID == id).Select(x => x.CategoryID).ToList(); // danh sach categoryID
            var authors = _context.AuthorTitles
                .Where(x => x.TitleID == id).Select(x => x.AuthorID).ToList(); // danh sach titleID

            return new TitleViewAll(titleView, categories, authors);
        }


        [HttpGet]
        public ActionResult<List<ViewTitleFullField>> Get()
        { // class TitleViewAll để định dạng dữ liệu file json trả về cho api
            // đc gọi khi t gửi id của title lên để get về chi tiết của tile
            // Ctr + Click vao Class de xem danh sach property

            var l = (from t in _context.Titles
                     select new ViewTitleFullField(

                      new TitleView(t.ID, t.Code, t.Name, t.TableOfContent,
                         t.Description, t.Edition, t.ISBN, t.Image, t.Price, t.PublishingDate,
                         t.LanguageID, t.PublisherID),

                         (from ct in _context.CategoryTitles
                          join c in _context.Categories
                          on ct.CategoryID equals c.ID
                          where ct.TitleID == t.ID
                          select c.Name).ToList(),

                         (from at in _context.AuthorTitles
                          join a in _context.Authors
                          on at.AuthorID equals a.ID
                          where at.TitleID == t.ID
                          select $"{a.FirstName} {a.LastName}").ToList()
                     )).ToList();
            return l;
          
        }


        [HttpGet("shorttitle")]
        // nghĩa là localhost:.../Title/shorttile
        public ActionResult<List<ShortTitle>> GetTitle()
        { 
            var list =  _context.Titles
                        .Select( t =>  new ShortTitle(){
                            ID = t.ID,
                            Name = t.Name,
                            Image = t.Image
                        }).ToList();
            return list;
        }

        [HttpPost]
        public IActionResult Post(ModelBindingTitleView model)
        {
            try
            {
                Title title = model.Title;
          
                _context.Titles.Add(title);
                _context.SaveChanges();

                AddAuthorTitles(title.ID, model.Authors);

                AddCategoryTitles(title.ID, model.Categories);

                return new ObjectResult("Thêm thành công");
            }
            catch (Exception ex)
            {
                return BadRequest("Error Occurred");
            }
        }

        public void AddAuthorTitles(int id, int[] authorsID)
        {
            // thêm data vào bảng authortitle
            List<AuthorTitle> authorTitles = new List<AuthorTitle>();
            foreach (var i in authorsID)
                authorTitles.Add(new AuthorTitle(i, id));
            _context.AuthorTitles.AddRange(authorTitles);
            _context.SaveChanges();
        }

        public void AddCategoryTitles(int id, int[] categoriesID)
        {
            // thêm data vào bảng categorytitle
            List<CategoryTitle> categoryTitles = new List<CategoryTitle>();
            foreach (var i in categoriesID)
                categoryTitles.Add(new CategoryTitle(i, id));
            _context.CategoryTitles.AddRange(categoryTitles);
            _context.SaveChanges();
        }

        public void RemoveOldData(int id)
        {
            _context.AuthorTitles
                    .RemoveRange(_context.AuthorTitles.Where(at => at.TitleID == id));
            _context.SaveChanges();
            _context.CategoryTitles
                .RemoveRange(_context.CategoryTitles.Where(ct => ct.TitleID == id));
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ModelBindingTitleView model)
        {
            var s = model;

            var titleUpdate = _context.Titles.Find(id);
            if (titleUpdate != null)
            {
                titleUpdate.LanguageID = model.Title.LanguageID;
                titleUpdate.PublisherID = model.Title.PublisherID;
                titleUpdate.Code = model.Title.Code;
                titleUpdate.Name = model.Title.Name;
                titleUpdate.TableOfContent = model.Title.TableOfContent;
                titleUpdate.Description = model.Title.Description;
                titleUpdate.Edition = model.Title.Edition;
                titleUpdate.ISBN = model.Title.ISBN;
                titleUpdate.Image = model.Title.Image;
                titleUpdate.Price = model.Title.Price;
                titleUpdate.PublishingDate = model.Title.PublishingDate;

                _context.Titles.Update(titleUpdate); // update title
                _context.SaveChanges();

                // xoá dữ liễu về id cần edit trong 2 bảng 
                // authortitle và ctegorytitle
                RemoveOldData(titleUpdate.ID);
                AddAuthorTitles(titleUpdate.ID, model.Authors); // thêm mới bảng authorstitle
                AddCategoryTitles(titleUpdate.ID, model.Categories); // thêm mới bảng categoriestitle

                return new OkObjectResult(new { messegge = "thay đổi thành công" });
            }
            return BadRequest("khong");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var title = _context.Titles.Find(id);
            if (title == null)
                return NotFound();
            _context.Titles.Remove(title);
            _context.SaveChanges();
            return NoContent();
        }
    }
}