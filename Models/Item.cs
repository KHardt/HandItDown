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
        [StringLength(55, ErrorMessage = "Please shorten the item name to 55 characters")]
        public string Name { get; set; }


        [Required]
        public int Quantity { get; set; }

        [Required]
        public string UserId { get; set; }

        public string ImagePath { get; set; }


        [Required]
        public ApplicationUser User { get; set; }

       public virtual ICollection<ItemDetail> ItemDetails { get; set; }

    }
}







