using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{
    public class Toy
    {

        [Key]
        public int ToyId { get; set; }


        [Required]
        [StringLength(255)]
        public string Description { get; set; }


        [Required]
        public int Quantity { get; set; }

        public string Color { get; set; }


        [Required]
        public string UserId { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public int StatusId { get; set; }

        public Status Status { get; set; }

        [Required]
        public ApplicationUser User { get; set; }


        [Required]
        [Display(Name = "Toy Category")]
        public int ToyTypeId { get; set; }

        public ToyType ToyType { get; set; }


    }
}

    }
}
