using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandItDown.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public Book Book { get; set; }
        public List<Book> Books { get; set; }

        public Toy Toy { get; set; }
        public List<Toy> Toys { get; set; }

        public Clothing Clothing { get; set; }
        public List<Clothing> Clothings { get; set; }

        public Misc Misc { get; set; }
        public List<Misc> Miscs { get; set; }

        public ClothingType ClothingType { get; set; }
        public List<ClothingType> ClothingTypes { get; set; }

        public ToyType ToyType { get; set; }
        public List<ToyType> ToyTypes { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Category:")]
        public string Label { get; set; }


      







    }
}
