using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    [Table("Books")]
    public class Book
    {
        public Book(bool type, int page, bool status, int shelveID, int titleID)
        {
            Type = type;
            Page = page;
            Status = status;
            ShelveID = shelveID;
            TitleID = titleID;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "char(9)")]
        public string BarCode { get; set; }
        public bool Type { get; set; }

        public int Page { get; set; }

        public bool Status { get; set; }
        [NotMapped]
        public int Quantity { get; set; }

        public int ShelveID { get; set; }
        public int TitleID { get; set; }

        [ForeignKey("ShelveID")]
        public virtual Shelve Shelve { get; set; }

        [ForeignKey("TitleID")]
        public virtual Title Title { get; set; }

      
    }
}
