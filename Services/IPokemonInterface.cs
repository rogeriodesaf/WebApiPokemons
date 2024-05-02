using ApiPokemons.DTO;
using ApiPokemons.Models;

namespace ApiPokemons.Repositorios
{
    public interface IPokemonInterface
    {
        public Task<ResponseModel<List<PokemonModel>>> getPokemon();

        public Task<ResponseModel<PokemonModel>> getPokemonById(int id);


        public Task<ResponseModel<List<PokemonModel>>> getPokemonByMestreId(int id);

        public Task<ResponseModel<List<PokemonModel>>> postPokemon(PokemonCriacaoDto pokemonCriacaoDto);

        public Task<ResponseModel<List<PokemonModel>>> putPokemon(PokemonEdicaoDto pokemonEdicaoDto);

        public Task<ResponseModel<List<PokemonModel>>> deletePokemon(int id);
       
    }
}
