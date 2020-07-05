namespace c__async_io
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            var now = Stopwatch.StartNew();
            ICollection<Task<JsonDocument>> gets = new List<Task<JsonDocument>>();
            for (var id = 1; id <= 100; id++)
            {
                var get = GetTodo(client, id);
                gets.Add(get);
            }
            await Task.WhenAll(gets);
            now.Stop();
            Console.WriteLine($"Elapsed: {now.Elapsed.TotalSeconds} seconds");
            Console.WriteLine($"Result: {(await gets.Last()).RootElement.ToString()}");
        }

        private static async Task<JsonDocument> GetTodo(HttpClient client, int id)
        {
            const string Base = "https://jsonplaceholder.typicode.com/todos";
            var address = $"{Base}/{id}";
            var response = await client.GetAsync(address);
            var contentStream = await response.Content.ReadAsStreamAsync();
            return await JsonDocument.ParseAsync(contentStream);
        }
    }
}
