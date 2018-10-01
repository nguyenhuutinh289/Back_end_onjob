using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    [Table("Receipts")]
    public class Receipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  ID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime IssueDate { get; set; }
        
        public int BorrowerID { get; set; }
       
        public int LibrarianID { get; set; }

        [ForeignKey("LibrarianID")]
        public virtual Librarian Librarian { get; set; }
    }
}
