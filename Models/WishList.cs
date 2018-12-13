using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{
    public class WishList
    {

        [Key]
        public int WishListId { get; set; }

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

        public string City { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Item Attributes")]
        public int AttributeId { get; set; }

        public Attribute Attribute { get; set; }

        // public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}







