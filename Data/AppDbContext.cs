using ApiPokemons.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPokemons.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PokemonModel> Pokemons { get; set; }
        public DbSet<MestrePokemonModel> MestrePokemon { get; set; }
    }
}
