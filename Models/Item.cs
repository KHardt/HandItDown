using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{
    public class Item
    {

        [Key]
        public int ItemId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }


        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please shorten the item name to 30 characters")]
        public string Name { get; set; }


        [Required]
        public int Quantity { get; set; }

        [Required]
        public string UserId { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public int StatusId { get; set; }

        public Status Status { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Item Category")]
        public int ItemTypeId { get; set; }

        public ItemType ItemType { get; set; }

      
    }
}





