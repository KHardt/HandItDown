using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{
    public class Clothing
    {

        [Key]
        public int ClothingId { get; set; }


        [Required]
        [StringLength(255)]
        public string Description { get; set; }


        [Required]
        public int Quantity { get; set; }


        [Required]
        public int Size { get; set; }


        [Required]
        public int Color { get; set; }


        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public int StatusId { get; set; }

        public Status Status { get; set; }



        [Required]
        [Display(Name = "Clothing Category")]
        public int ClothingTypeId { get; set; }

        public ClothingType ClothingType { get; set; }

      
    }
}





