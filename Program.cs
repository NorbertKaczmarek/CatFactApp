using Microsoft.Extensions.DependencyInjection;

namespace CatFactApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                .AddSingleton<ICatFactService, CatFactService>()
                .BuildServiceProvider();
            
            var catFactService = serviceCollection.GetService<ICatFactService>();

            string url = "https://catfact.ninja/fact";
            string fileName = "CatFacts.txt";

            if (catFactService != null)
            {
                var catFact = await catFactService.GetCatFactAsync(url);
                await catFactService.SaveCatFactToFileAsync(fileName, catFact);
            }
        }
    }
}
