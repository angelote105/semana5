using Microsoft.Extensions.Logging;
using semana5.Utils;

namespace semana5
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            string dbPath = FileAccessHelper.GetLocalFilePath("persona.db3");
            builder.Services.AddSingleton<PersonaRepositorio>(s=>
                                    ActivatorUtilities.CreateInstance<PersonaRepositorio>(s,dbPath));

            return builder.Build();
        }
    }
}
