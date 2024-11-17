namespace GameZone.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(200)]
        public string Icon { get; set; } = string.Empty;
    }
}
