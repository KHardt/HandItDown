using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{

        public class ToyType
        {
            [Key]
            public int ToyTypeId { get; set; }

            [Required]
            [StringLength(255)]
            [Display(Name = "Category:")]
            public string Label { get; set; }

            [NotMapped]
            public int Quantity { get; set; }

            [Required]
            public string UserId { get; set; }

            public virtual ICollection<Toy> Toys { get; set; }
        }

    }




