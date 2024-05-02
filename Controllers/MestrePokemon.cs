
using ApiPokemons.DTO.MestrePokemonDTO;
using ApiPokemons.Models;
using ApiPokemons.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MestrePokemon : ControllerBase
    {
        private readonly IMestrePokemonInterface _mestrePokemonInterface;
        public MestrePokemon(IMestrePokemonInterface mestrePokemonInterface)
        {
            _mestrePokemonInterface = mestrePokemonInterface;   
        }
[HttpPost("CriarMestrePokemon")]
        public async Task<ActionResult<ResponseModel<List<MestrePokemonModel>>>> postMestrePokemon(MestrePokemonCriacaoDto mestrePokemonCriacaoDto)
        {
            var mestresPokemon = await _mestrePokemonInterface.postMestrePokemon(mestrePokemonCriacaoDto);
            return Ok(mestresPokemon);
        }

    }
}
