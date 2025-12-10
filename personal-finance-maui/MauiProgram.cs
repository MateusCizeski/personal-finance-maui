using LiteDB;
using Microsoft.Extensions.Logging;
using personal_finance_maui.Repositories;

namespace personal_finance_maui
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
                })
                .RegisterDatabaseRepositories();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterDatabaseRepositories(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LiteDatabase>(options => {
                return new LiteDatabase($"Filename={AppSettings.DatabasePath};Connection=Shared;");
            });

            mauiAppBuilder.Services.AddTransient<ITransactionRepository, TransactionRepository>();

            return mauiAppBuilder;
        }
    }
}
