using GameZone.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace GameZone.ViewModels
{
	public class CreateGameViewModel : GameFormViewModel
    {
		[AllowedExtensions(FileSettings.AllowedExtensions)]
		[MaxSizeFile(FileSettings.MaxFileSizeInBytes)]
		public IFormFile Cover { get; set; } = default!;
	}
}
