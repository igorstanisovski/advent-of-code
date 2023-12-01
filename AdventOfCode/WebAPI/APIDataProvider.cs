using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.WebAPI.Abstract;

namespace AdventOfCode.WebAPI
{
    public class APIDataProvider : IAPIDataProvider
    {
        private readonly HttpClient _client;
        public APIDataProvider(string? token)
        {
            var uri = new Uri("https://adventofcode.com");
            var cookies = new CookieContainer();
            cookies.Add(uri, new Cookie("session", token));
            var handler = new HttpClientHandler() { CookieContainer = cookies };
            _client = new HttpClient(handler) { BaseAddress = uri };
        }

        public async Task<string> GetDayInput(int year, int day)
        {
            using var result = await _client.GetAsync($"/{year}/day/{day}/input");
            if (!result.IsSuccessStatusCode)
            {
                Console.WriteLine("Something went wrong while fetching input data...");
                return await Task.FromResult<string>(string.Empty);
            }
            return await result.Content.ReadAsStringAsync();
        }
    }
}
