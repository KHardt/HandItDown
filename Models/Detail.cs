using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandItDown.Models
{
    public class Detail
    {
        [Key]
        public int DetailId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Detail:")]
        public string Label { get; set; }

        [NotMapped]
        public int Quantity { get; set; }

        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
    }
}
