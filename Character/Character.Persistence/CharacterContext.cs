using CharacterDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterPersistence
{
	public class CharacterContext : DbContext
	{
		public CharacterContext(DbContextOptions<CharacterContext> options) : base(options)
		{

		}

		public DbSet<Character> Characters => Set<Character>();
	}
}
