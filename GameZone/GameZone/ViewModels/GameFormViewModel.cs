namespace GameZone.ViewModels
{
    public class GameFormViewModel
    {
        [MaxLength(250, ErrorMessage = "The Max Size is 250 Character")]
        [MinLength(3, ErrorMessage = "The Min Size is 3 Character")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000, ErrorMessage = "The Max Size is 1000 Character")]
        [MinLength(10, ErrorMessage = "The Min Size is 10 Character")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Selected Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> devices { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
