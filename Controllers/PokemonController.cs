using ApiPokemons.DTO;
using ApiPokemons.Models;
using ApiPokemons.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonInterface _pokemonInterface;
        public PokemonController(IPokemonInterface pokemonInterface)
        {
            _pokemonInterface = pokemonInterface;
        }
        [HttpPost("CriarPokemon")]
        public async Task<ActionResult<List<ResponseModel<PokemonModel>>>> postPokemon(PokemonCriacaoDto pokemonCriacaoDto)
        {
            var pokemon = await _pokemonInterface.postPokemon(pokemonCriacaoDto);
            return Ok(pokemon);
        }

    }
}
