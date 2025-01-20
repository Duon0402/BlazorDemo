namespace BlazorDemo.Service
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Pokemon>> GetPokemonsAsync(int limit = 20, int offset = 0)
        {
            var response = await _httpClient.GetFromJsonAsync<PokemonResponse>($"https://pokeapi.co/api/v2/pokemon?limit={limit}&offset={offset}");

            return response?.Results ?? new List<Pokemon>();
        }
    }

    public class PokemonResponse
    {
        public List<Pokemon> Results { get; set; } = new List<Pokemon>();
    }

    public class Pokemon
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public int Id
        {
            get
            {
                var segments = Url.TrimEnd('/').Split('/');
                return int.Parse(segments[^1]);
            }
        }

        public string GetPokemonImageUrl()
        {
            return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{Id}.png";
        }
    }
}
