using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code.Models
{
    [Table("Titles")]
    public class Title
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int LanguageID { get; set; }

        public int PublisherID { get; set; }

        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string TableOfContent { get; set; }

        public string Description { get; set; }

        public int Edition { get; set; }

        [Column(TypeName = "char(50)")]
        public string ISBN { get; set; }

        public string Image { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime PublishingDate { get; set; }

        [ForeignKey("LanguageID")]
        public virtual Language Language { get; set; }

        [ForeignKey("PublisherID")]
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<CategoryTitle> CategoryTitles { get; set; }
        public virtual ICollection<AuthorTitle> AuthorTitles { get; set; }
    }
}