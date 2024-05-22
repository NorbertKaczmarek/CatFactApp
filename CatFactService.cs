using System.Net.Http.Json;

namespace CatFactApp
{
    internal interface ICatFactService
    {
        Task<CatFact> GetCatFactAsync(string url);
        Task SaveCatFactToFileAsync(string path, CatFact catFact);
    }

    internal class CatFactService : ICatFactService
    {
        private readonly HttpClient httpClient = new HttpClient();

        public async Task<CatFact> GetCatFactAsync(string url)
        {
            var response = await httpClient.GetAsync(url);

            if (response is null || response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await Console.Out.WriteLineAsync("CatFact not found.");
                return null;
            }

            var catFact = await response.Content.ReadFromJsonAsync<CatFact>();

            if (catFact is null)
            {
                await Console.Out.WriteLineAsync("CatFact could not be mapped");
                return null;
            }

            return catFact;
        }

        public async Task SaveCatFactToFileAsync(string path, CatFact catFact)
        {
            if (catFact is null) return;

            using (var sw = new StreamWriter(path, true))
            {
                await sw.WriteLineAsync(catFact.Fact);
            }

            await Console.Out.WriteLineAsync($"CatFact saved to file: {path}");
        }
    }
}
