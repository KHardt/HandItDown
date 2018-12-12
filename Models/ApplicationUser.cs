using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HandItDown.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

      



        // Set up PK -> FK relationships to other objects
        // public virtual ICollection<Product> Products { get; set; }

        // public virtual ICollection<Order> Orders { get; set; }

        // public virtual ICollection<PaymentType> PaymentTypes { get; set; }
    }
}