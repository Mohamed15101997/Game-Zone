namespace GameZone.Services
{
	public interface IGameService
	{
		IEnumerable<Game> GetAll();
		Game? GetById(int id);
		Task Create(CreateGameViewModel model);
		Task<Game?> Update(EditGameFormViewModel model);
		bool Delete(int id);
	}
}
