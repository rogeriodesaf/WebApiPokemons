using ApiPokemons.DTO.MestrePokemonDTO;
using ApiPokemons.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemons.Repositorios
{
    public interface IMestrePokemonInterface
    {
        public Task<ResponseModel<List<MestrePokemonModel>>> getMestrePokemon();

        public Task<ResponseModel<MestrePokemonModel>> getMestrePokemonById(int id);


        public Task<ResponseModel<List<MestrePokemonModel>>> getMestreokemonByPokemonId(int id);

        public Task<ResponseModel<List<MestrePokemonModel>>> postMestrePokemon(MestrePokemonCriacaoDto mestrePokemonCriacaoDto);

        public Task<ResponseModel<List<MestrePokemonModel>>> putMestrePokemon(MestrePokemonEdicaoDto mestrePokemonEdicaoDto);

        public Task<ResponseModel<List<MestrePokemonModel>>> deleteMestrePokemon(int id);

    }
}
