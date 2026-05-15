
using GameStore.Models;

namespace GameStore.Clients;

public class GenreClient(HttpClient httpClient)
{
    // private readonly List<Genre> _genres = [
    //     new () { Id = 1, Name = "Fighting" },
    //     new () { Id = 2, Name = "Roleplaying" },
    //     new () { Id = 3, Name = "Sports" },
    //     new () { Id = 4, Name = "Racing" },
    //     new () { Id = 5, Name = "Kids and Family" },
    //     new () { Id = 6, Name = "Action-Adventure" },
    //     new () { Id = 7, Name = "Platformer" },
    // ];

    public async Task<Genre[]> GetGenresAsync()
        => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
}
