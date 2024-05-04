
using ApiPokemons.DTO.MestrePokemonDTO;
using ApiPokemons.Models;
using ApiPokemons.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPokemons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MestrePokemonController : ControllerBase
    {
        private readonly IMestrePokemonInterface _mestrePokemonInterface;
        public MestrePokemonController(IMestrePokemonInterface mestrePokemonInterface)
        {
            _mestrePokemonInterface = mestrePokemonInterface;
        }
        [HttpPost("CriarMestrePokemon")]
        public async Task<ActionResult<ResponseModel<List<MestrePokemonModel>>>> postMestrePokemon(MestrePokemonCriacaoDto mestrePokemonCriacaoDto)
        {
            var mestresPokemon = await _mestrePokemonInterface.postMestrePokemon(mestrePokemonCriacaoDto);
            return Ok(mestresPokemon);
        }

        [HttpGet("ListarTreinadores")]
        public async Task<ActionResult<ResponseModel<List<MestrePokemonModel>>>> getMestrePokemon()
        {
            var mestresPokemon = await _mestrePokemonInterface.getMestrePokemon();
            return Ok(mestresPokemon);
        }

        [HttpGet("PegarTreinadorPokemonPorId/{id}")]
        public async Task<ActionResult<ResponseModel<MestrePokemonModel>>> getMestrePokemonById(int id)
        {
            return Ok( await _mestrePokemonInterface.getMestrePokemonById(id));
            
           
        }

        [HttpPut("EditarTreinadorPokemon")]
        public async Task<ActionResult<ResponseModel<MestrePokemonModel>>> putMestrePokemon(MestrePokemonEdicaoDto mestrePokemonEdicaoDto)
        {
            var resposta = await _mestrePokemonInterface.putMestrePokemon(mestrePokemonEdicaoDto);
                if(resposta.Dados is null)
                {
                    return BadRequest(resposta.Mensagem);    
                }
            return Ok(await _mestrePokemonInterface.putMestrePokemon(mestrePokemonEdicaoDto));
        }


             
        }
      
        
       

    }

