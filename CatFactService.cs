﻿using System.Net.Http.Json;

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
            try
            {
                var response = await httpClient.GetAsync(url);

                if (response is null || response.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception("CatFact not found.");

                var catFact = await response.Content.ReadFromJsonAsync<CatFact>();

                if (catFact is null || catFact.Fact is null) throw new Exception("CatFact could not be mapped.");

                return catFact;
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                await Console.Out.WriteLineAsync("Invalid url");
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.ToString());
            }

            return null;
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
