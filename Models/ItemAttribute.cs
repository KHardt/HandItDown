using System.ComponentModel.DataAnnotations;

namespace HandItDown.Models
{
    public class ItemAttribute
    {
        [Key]
        public int ItemAttributeId { get; set; }

        [Required]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Required]
        public int AttributeId { get; set; }

        public Attribute Attribute { get; set; }

    }
}