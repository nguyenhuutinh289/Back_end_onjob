using System;
using System.Collections.Generic;

namespace Code.JsonResult
{
    public class TitleViewAll
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Description { get; set; }

        public int Edition { get; set; }

        public string ISBN { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string Language { get; set; }

        public string Publisher { get; set; }

        public List<string> Categories { get; set; }

        public List<string> Authors { get; set; }
    }
}