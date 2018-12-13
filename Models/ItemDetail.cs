using System.ComponentModel.DataAnnotations;

namespace HandItDown.Models
{
    public class ItemDetail
    {
        [Key]
        public int ItemDetailId { get; set; }

        [Required]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Required]
        public int DetailId { get; set; }

        public Detail Detail { get; set; }

    }
}