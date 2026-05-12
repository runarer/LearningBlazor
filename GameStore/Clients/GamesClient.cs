
using GameStore.Models;

namespace GameStore.Clients;

public class GamesClient
{
    private readonly List<GameSummary> _games = [
        new () {
            Id = 1,
            Name = "The Legend of Zelda: Breath of the Wild",
            Genre = "Action-Adventure",
            Price = 59.99m,
            ReleaseDate = new DateOnly(2017, 3, 3) },
        new () {
            Id = 2,
            Name = "Red Dead Redemption 2",
            Genre = "Action-Adventure",
            Price = 59.99m,
            ReleaseDate = new DateOnly(2018, 10, 26) },
        new () {
            Id = 3,
            Name = "The Witcher 3: Wild Hunt",
            Genre = "Roleplaying",
            Price = 39.99m,
            ReleaseDate = new DateOnly(2015, 5, 19) },
        new () {
            Id = 4,
            Name = "Super Mario Odyssey",
            Genre = "Platformer",
            Price = 59.99m,
            ReleaseDate = new DateOnly(2017, 10, 27) },
        new () {
            Id = 5,
            Name = "God of War",
            Genre = "Action-Adventure",
            Price = 49.99m,
            ReleaseDate = new DateOnly(2018, 4, 20) }
    ];

    private readonly Genre[] _genres = new GenreClient().GetGenres();

    public GameSummary[] GetGames() => [.. _games];
    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);

        var newGame = new GameSummary
        {
            Id = _games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        _games.Add(newGame);
    }



    public GameDetails GetGame(int id)
    {
        GameSummary? game = GetGameSummaryById(id);

        var genre = _genres.Single(genre => string.Equals(
            genre.Name,
            game.Genre,
            StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var game = GetGameSummaryById(updatedGame.Id);
        var genre = GetGenreById(updatedGame.GenreId);

        game.Name = updatedGame.Name;
        game.Genre = genre.Name;
        game.Price = updatedGame.Price;
        game.ReleaseDate = updatedGame.ReleaseDate;
    }

    private GameSummary GetGameSummaryById(int id)
    {
        var game = _games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        return _genres.Single(genre => genre.Id == int.Parse(id));
    }
}
