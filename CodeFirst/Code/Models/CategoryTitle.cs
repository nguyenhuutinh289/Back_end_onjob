using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Models
{
    [Table("CategoryTitles")]
    public class CategoryTitle
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public int TitleID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("TitleID")]
        public virtual Title Title { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
