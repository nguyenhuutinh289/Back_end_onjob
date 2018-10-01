using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    [Table("ReceiptDetails")]
    public class ReceiptDetail
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public int ReceiptID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public int BookID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime  ExpectReturn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AcctualReturn { get; set; }

        [ForeignKey("ReceiptID")]
        public virtual Receipt Receipt { get; set; }
        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }

    }
}
