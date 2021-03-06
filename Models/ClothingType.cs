﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{
    public class ClothingType
    {
        [Key]
        public int ClothingTypeId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Category:")]
        public string Label { get; set; }

        [NotMapped]
        public int Quantity { get; set; }


        public virtual ICollection<Clothing> Clothing { get; set; }
    }

}



