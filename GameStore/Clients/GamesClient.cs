
using GameStore.Models;

namespace GameStore.Clients;

public class GamesClient(HttpClient httpClient)
{
    // private readonly List<GameSummary> _games = [
    //     new () {
    //         Id = 1,
    //         Name = "The Legend of Zelda: Breath of the Wild",
    //         Genre = "Action-Adventure",
    //         Price = 59.99m,
    //         ReleaseDate = new DateOnly(2017, 3, 3) },
    //     new () {
    //         Id = 2,
    //         Name = "Red Dead Redemption 2",
    //         Genre = "Action-Adventure",
    //         Price = 59.99m,
    //         ReleaseDate = new DateOnly(2018, 10, 26) },
    //     new () {
    //         Id = 3,
    //         Name = "The Witcher 3: Wild Hunt",
    //         Genre = "Roleplaying",
    //         Price = 39.99m,
    //         ReleaseDate = new DateOnly(2015, 5, 19) },
    //     new () {
    //         Id = 4,
    //         Name = "Super Mario Odyssey",
    //         Genre = "Platformer",
    //         Price = 59.99m,
    //         ReleaseDate = new DateOnly(2017, 10, 27) },
    //     new () {
    //         Id = 5,
    //         Name = "God of War",
    //         Genre = "Action-Adventure",
    //         Price = 49.99m,
    //         ReleaseDate = new DateOnly(2018, 4, 20) }
    // ];

    // private readonly Genre[] _genres = new GenreClient(httpClient).GetGenres();

    public async Task<GameSummary[]> GetGamesAsync() => await
        httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

    // Route and payload
    public async Task AddGameAsync(GameDetails game) =>
        await httpClient.PostAsJsonAsync("games", game);

    public async Task<GameDetails> GetGameAsync(int id) =>
        await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Game not found");

    public async Task UpdateGameAsync(GameDetails updatedGame)
        => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);

    public async Task DeleteGameAsync(int id)
        => await httpClient.DeleteAsync($"games/{id}");

    // private async Task<GameSummary> GetGameSummaryById(int id)
    // {
    //     var game = _games.Find(game => game.Id == id);
    //     ArgumentNullException.ThrowIfNull(game);
    //     return game;
    // }

    // private async Task<Genre> GetGenreById(string? id)
    // {
    //     ArgumentException.ThrowIfNullOrEmpty(id);
    //     return _genres.Single(genre => genre.Id == int.Parse(id));
    // }


}
