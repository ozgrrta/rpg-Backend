using Character.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Character.Application
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
