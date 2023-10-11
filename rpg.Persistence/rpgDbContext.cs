using Microsoft.EntityFrameworkCore;
using rpg.Domain.Models;

namespace rpg.Persistence
{
	public class rpgDbContext : DbContext
	{
		public rpgDbContext(DbContextOptions<rpgDbContext> options) : base(options)
		{

		}

		public DbSet<Character> Characters => Set<Character>();
		public DbSet<User> Users => Set<User>();
	}
}
