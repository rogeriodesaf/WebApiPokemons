using ApiPokemons.Data;
using ApiPokemons.DTO;
using ApiPokemons.DTO.MestrePokemonDTO;
using ApiPokemons.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ResponseModel<List<MestrePokemonModel>>> getMestrePokemon()
        {
            ResponseModel<List<MestrePokemonModel>> resposta = new ResponseModel<List<MestrePokemonModel>>();
            try
            {
                var treinadores =  _context.MestrePokemon.ToList();
                if(treinadores is null)
                {
                    resposta.Mensagem = "Nenhum treinador encontrado";
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Dados =  _context.MestrePokemon.ToList();
                resposta.Mensagem = "Dados retornados com sucesso";
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            return resposta;
        }   

        public async Task<ResponseModel<MestrePokemonModel>> getMestrePokemonById(int id)
        {
            ResponseModel<MestrePokemonModel> resposta = new ResponseModel<MestrePokemonModel>();

            try
            {
                var treinador =  _context.MestrePokemon.FirstOrDefault(a => a.Id == id);
                if(treinador is null)
                {
                    resposta.Mensagem = "Nenhum treinador pokemon encontrado!";
                    resposta.Status=false;
                    return resposta;
                }

                resposta.Dados = treinador;
                resposta.Mensagem = "Treinador Pokemon encontrado com sucesso!";
               

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            return resposta;
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

        public async Task<ResponseModel<List<MestrePokemonModel>>> putMestrePokemon(MestrePokemonEdicaoDto mestrePokemonEdicaoDto)
        {
            ResponseModel<List<MestrePokemonModel>> resposta = new ResponseModel<List<MestrePokemonModel>>();
            try
            {
                var treinador = await _context.MestrePokemon
                    .FirstOrDefaultAsync(a => a.Id == mestrePokemonEdicaoDto.Id);
                if(treinador == null)
                {
                    resposta.Mensagem = "Treinador não encontrado!";
                    resposta.Status=false;
                    return resposta;
                }

                treinador.Nome = mestrePokemonEdicaoDto.Nome;
                treinador.Ginasio = mestrePokemonEdicaoDto.Ginasio;


                _context.Update(treinador);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.MestrePokemon.ToListAsync();
                resposta.Mensagem = "Treinador editado com sucesso!";
                
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status= false;
                return resposta;
            }
            return resposta;
        }
    }
}
