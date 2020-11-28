using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public record Category
    {
        [Key]
        public int Id { get; init; }
        
        [Required]

        public string Name { get; init; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Display Order for category must be greather than 0.")]

        public int DisplayOrder { get; init; }
    }

}
