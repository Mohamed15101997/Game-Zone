namespace GameZone.Models
{
    public class Game : BaseEntity
    {
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Cover { get; set; } = string.Empty;

        [ForeignKey("Category")]
        public int CategoryId { get; set; } 

        public Category Category { get; set; } = default!;
        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();
    }
}
