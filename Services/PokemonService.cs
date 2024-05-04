using ApiPokemons.Data;
using ApiPokemons.DTO;
using ApiPokemons.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemons.Repositorios
{
    public class PokemonService : IPokemonInterface
    {
        private readonly AppDbContext _context;
        public PokemonService(AppDbContext context)
        {
            _context = context;
        }
        public Task<ResponseModel<List<PokemonModel>>> deletePokemon(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<PokemonModel>>> getPokemon()
        {
            ResponseModel<List<PokemonModel>> resposta = new ResponseModel<List<PokemonModel>>();
            try
            {
              var pokemons = await _context.Pokemons.ToListAsync();
                if(pokemons is null)
                {
                    resposta.Mensagem = "nenhum pokemon encontrado";
                    resposta.Status = false;
                    return resposta;
                }


                resposta.Dados = await _context.Pokemons.Include(a=>a.MestrePokemon).ToListAsync();
                resposta.Mensagem = "Lista de pokemons retornada com sucesso";
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            return resposta;
        }

        public async  Task<ResponseModel<PokemonModel>> getPokemonById(int id)
        {
            ResponseModel<PokemonModel> resposta = new ResponseModel<PokemonModel>();
            try
            {
                var pokemon = await _context.Pokemons.FirstOrDefaultAsync(a => a.Id == id);
                if(pokemon == null)
                {
                    resposta.Mensagem = "Não foram encontrados pokemons com esse Id";
                    resposta.Status=false;
                    return resposta;
                }

                resposta.Dados = pokemon;
                resposta.Mensagem = "Pokemon encontrado com sucesso!";
               
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            return resposta;
        }

        public Task<ResponseModel<List<PokemonModel>>> getPokemonByMestreId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<PokemonModel>>> postPokemon(PokemonCriacaoDto pokemonCriacaoDto)
        {
            ResponseModel<List<PokemonModel>> resposta = new ResponseModel<List<PokemonModel>>();

            try
            {
                var treinador = await _context.MestrePokemon.FirstOrDefaultAsync(a => a.Id == pokemonCriacaoDto.MestrePokemon.Id);
               
                if(treinador == null)
                {
                    resposta.Mensagem = "Não foi encontrado nenhum treinador pokemon";
                    resposta.Status = false;
                    return resposta;
                }

                var pokemon = new PokemonModel();
                {
                    pokemon.Nome = pokemonCriacaoDto.Nome;
                    pokemon.Tipo = pokemonCriacaoDto.Tipo;
                    pokemon.MestrePokemon = treinador;
                

                };

                _context.Pokemons.Add(pokemon); 
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Pokemons.ToListAsync();
                resposta.Mensagem = "Pokemon Criado com sucesso";

              
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

            return resposta;
        }

        public Task<ResponseModel<List<PokemonModel>>> putPokemon(PokemonEdicaoDto pokemonEdicaoDto)
        {
            throw new NotImplementedException();
        }
    }
}
