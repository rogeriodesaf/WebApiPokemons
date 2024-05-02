namespace ApiPokemons.Models
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public string Nome  { get; set; }

        public string Tipo { get; set; }

        public MestrePokemonModel MestrePokemon { get; set; }   
    }
}
