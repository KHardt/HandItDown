using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public string Label { get; set; }

        public virtual ICollection<Clothing> Clothing { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Toy> Toys { get; set; }
        public virtual ICollection<Misc> Miscs { get; set; }

    }
}
