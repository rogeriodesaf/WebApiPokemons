namespace ApiPokemons.DTO
{
    public class PokemonEdicaoDto
    {
        public int Id { get; set; }
        public string Nome  { get; set; }
        public string Tipo { get; set; }

        public MestreVinculoDto MestrePokemon { get; set; }
    }
}
