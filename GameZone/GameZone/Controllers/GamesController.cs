using GameZone.Models;
using GameZone.Services;

namespace GameZone.Controllers
{
	public class GamesController : Controller
	{
		private readonly ICategoriesService _categoriesService;
		private readonly IDevicesService _devicesService;
		private readonly IGameService _gamesService;

		public GamesController(ICategoriesService categoriesService , IDevicesService devicesService , IGameService gamesService)
        {
			_categoriesService = categoriesService;
			_devicesService = devicesService;
			_gamesService = gamesService;
		}
        public IActionResult Index()
        {
			
            return View(_gamesService.GetAll());
        }
        public IActionResult Details(int id)
        {
			var game = _gamesService.GetById(id);
			if (game == null)
				return NotFound();
			return View("Details", game);
        }
        public IActionResult Create()
		{
			CreateGameViewModel createGameView = new CreateGameViewModel
			{
				Categories = _categoriesService.GetSelectList(),
				devices = _devicesService.GetSelectList()
			};
			return View("Create" , createGameView);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateGameViewModel model) 
		{
			if (!ModelState.IsValid)
			{
				model.Categories = _categoriesService.GetSelectList();
				model.devices = _devicesService.GetSelectList();
				return View(model);
			}
			// Model State Valid 
			// 1) Save Game in DB 
			// 2) Save Cover in Server
			await _gamesService.Create(model);
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Edit(int id) 
		{
			var game = _gamesService.GetById(id);
			if (game == null)
				return NotFound();
			EditGameFormViewModel model = new EditGameFormViewModel()
			{
				Id = id,
				Name = game.Name,
				Description = game.Description,
				CategoryId = game.CategoryId,
				SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
				CoverName = game.Cover,
				Categories = _categoriesService.GetSelectList(), 
				devices = _devicesService.GetSelectList()
				
			};
			return View("Edit", model);
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditGameFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = _categoriesService.GetSelectList();
				model.devices = _devicesService.GetSelectList();
				return View(model);
			}

			var game = await _gamesService.Update(model);
			if (game == null)
				return BadRequest();

			return RedirectToAction(nameof(Index));
		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var isDeleted = _gamesService.Delete(id);
			if (!isDeleted)
				return BadRequest();
			return Ok();
		}

	}
}
