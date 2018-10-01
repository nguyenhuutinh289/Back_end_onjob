using System;

namespace Code.ModelsView
{
    public class TitleView
    {
        public TitleView(int id,  string code, string name,string content,
            string description,int edition,
            string isbn, string img,decimal price, 
            DateTime pubdate, int langid, int pubid)
        {
            this.ID = id;
            this.Name = name;
            this.TableOfContent = content;
            this.Code = code;
            this.Description = description;
            this.Edition = edition;
            this.ISBN = isbn;
            this.Image = img;
            this.Price = price;
            this.PublishingDate = pubdate;
            this.LanguageID = langid;
            this.PublisherID = pubid;
        }

        
        public int ID { get; set; }

        public int LanguageID { get; set; }

        public int PublisherID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string TableOfContent { get; set; }

        public string Description { get; set; }

        public int Edition { get; set; }

        public string ISBN { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishingDate { get; set; }
    }
}