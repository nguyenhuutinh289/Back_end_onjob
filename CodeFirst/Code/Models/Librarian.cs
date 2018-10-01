using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code.Models
{
    [Table("Librarian")]
    public class Librarian
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public bool Status { get; set; }

        [MaxLength(11)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string Image { get; set; }

        public virtual ICollection<Receipt> Receipts  { get; set; }
    }
}