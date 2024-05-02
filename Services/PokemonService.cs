using ApiPokemons.DTO;
using ApiPokemons.Models;

namespace ApiPokemons.Repositorios
{
    public class PokemonService : IPokemonInterface
    {
        public Task<ResponseModel<List<PokemonModel>>> deletePokemon(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<PokemonModel>>> getPokemon()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<PokemonModel>> getPokemonById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<PokemonModel>>> getPokemonByMestreId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<PokemonModel>>> postPokemon(PokemonCriacaoDto pokemonCriacaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<PokemonModel>>> putPokemon(PokemonEdicaoDto pokemonEdicaoDto)
        {
            throw new NotImplementedException();
        }
    }
}
