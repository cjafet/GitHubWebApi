using GitHubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
    public class ApiRepoRepository
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<RepoItems> GetRepositories(string query)
        {
            var serializer = new DataContractJsonSerializer(typeof(RepoItems));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Awesome GitGub Api");

            try
            {
                var url = String.Format("https://api.github.com/search/repositories?q={0}&sort=stars&order=desc", query);
                var streamTask = client.GetStreamAsync(url);
                var repositories = serializer.ReadObject(await streamTask) as RepoItems;
                return repositories;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }

        }

        public static async Task<dynamic> GetRepositoriesById(int id)
        {
            var serializer = new DataContractJsonSerializer(typeof(Repo));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var url = String.Format("https://api.github.com/repositories/{0}", id);
            var streamTask = client.GetStreamAsync(url);
            var repositories = serializer.ReadObject(await streamTask) as Repo;

            return repositories;

        }
    }
}
