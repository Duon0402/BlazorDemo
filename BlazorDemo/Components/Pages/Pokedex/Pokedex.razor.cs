using Microsoft.AspNetCore.Components;
using BlazorDemo.Service;

namespace BlazorDemo.Components.Pages.Pokedex
{
    public partial class Pokedex : ComponentBase
    {
        [Inject]
        private PokemonService PokemonService { get; set; }

        public List<Pokemon> Pokemons { get; set; } = new();
        public int Offset { get; set; } = 0;
        public bool IsLoading { get; set; } = false;

        private const int PageSize = 27;

        protected override async Task OnInitializedAsync()
        {
            await LoadPokemons();
        }

        private async Task LoadPokemons()
        {
            IsLoading = true;
            Pokemons = await PokemonService.GetPokemonsAsync(PageSize, Offset);
            IsLoading = false;
        }

        public async Task LoadNextPage()
        {
            Offset += PageSize;
            await LoadPokemons();
        }

        public async Task LoadPreviousPage()
        {
            if (Offset > 0)
            {
                Offset -= PageSize;
                await LoadPokemons();
            }
        }
    }
}
