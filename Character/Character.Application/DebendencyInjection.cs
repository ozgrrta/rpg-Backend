using CharacterApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CharacterApplication
{
	public static class DebendencyInjection
	{
		public static IServiceCollection AddCharacterApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddScoped<ICharacterService, CharacterService>();

			return services;
		}
	}
}
