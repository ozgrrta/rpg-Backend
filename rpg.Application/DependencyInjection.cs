using Microsoft.Extensions.DependencyInjection;
using rpg.Application.Interfaces;
using rpg.Application.Services;

namespace rpg.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddCharacterApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddScoped<ICharacterService, CharacterService>();

			return services;
		}
	}
}
