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

        public virtual ICollection<Item> Items { get; set; }

    }
}
