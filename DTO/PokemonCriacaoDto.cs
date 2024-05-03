using ApiPokemons.Models;

namespace ApiPokemons.DTO
{
    public class PokemonCriacaoDto
    {
        public string Nome { get; set; }

        public string Tipo { get; set; }

        public MestreVinculoDto MestrePokemon { get; set; }
    }
}
