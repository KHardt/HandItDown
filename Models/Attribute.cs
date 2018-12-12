using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandItDown.Models
{
    public class Attribute
    {
        [Key]
        public int AttributeId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Category:")]
        public string Label { get; set; }

        [NotMapped]
        public int Quantity { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
