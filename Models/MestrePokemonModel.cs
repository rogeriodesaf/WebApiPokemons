using System.Text.Json.Serialization;

namespace ApiPokemons.Models
{
    public class MestrePokemonModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Ginasio { get; set; }

        [JsonIgnore]
        public ICollection<PokemonModel> Pokemons { get; set; }
    }
}
