using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.JsonResult
{
    public class BookView
    {
        public int ID { get; set; }
        public string BarCode { get; set; }
        public bool Type { get; set; }
        public int Page { get; set; }
        public bool Status { get; set; }
        public int ShelveID { get; set; }
    }
}
