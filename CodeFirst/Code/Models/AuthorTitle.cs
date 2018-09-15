using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code.Models
{
    [Table("AuthorTitle")]
    public class AuthorTitle
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        public int AuthorID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public int TitleID { get; set; }

        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }

        [ForeignKey("TitleID")]
        public virtual Title Title { get; set; }
    }
}