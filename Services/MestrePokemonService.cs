using ApiPokemons.Data;
using ApiPokemons.DTO;
using ApiPokemons.DTO.MestrePokemonDTO;
using ApiPokemons.Models;

namespace ApiPokemons.Repositorios
{
    public class MestrePokemonService : IMestrePokemonInterface

        
    {
        private readonly AppDbContext _context;
        public MestrePokemonService(AppDbContext context)
        {
            _context = context;
        }
        public Task<ResponseModel<List<MestrePokemonModel>>> deleteMestrePokemon(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<MestrePokemonModel>>> getMestreokemonByPokemonId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<MestrePokemonModel>>> getMestrePokemon()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<MestrePokemonModel>> getMestrePokemonById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<MestrePokemonModel>>> postMestrePokemon(MestrePokemonCriacaoDto mestrePokemonCriacaoDto)
        {
          ResponseModel<List<MestrePokemonModel>> resposta = new ResponseModel<List<MestrePokemonModel>>();

            try
            {
               
                 var mestrePokemon = new MestrePokemonModel();
                 {
                   mestrePokemon.Nome = mestrePokemonCriacaoDto.Nome;
                  mestrePokemon.Ginasio = mestrePokemonCriacaoDto.Ginasio;
                 }
                if (mestrePokemon == null)
                {
                    resposta.Mensagem = "Não foi possivel criar o mestre Pokemom";
                    resposta.Status = false;
                    return resposta;
                }
                _context.MestrePokemon.Add(mestrePokemon);
                await _context.SaveChangesAsync();
                resposta.Dados =  _context.MestrePokemon.ToList();
                resposta.Mensagem = "Mestre Pokemon adicionado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<List<MestrePokemonModel>>> putPokemon(MestrePokemonEdicaoDto mestrePokemonEdicaoDto)
        {
            throw new NotImplementedException();
        }
    }
}
