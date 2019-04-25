﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using GitHubApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GitHubApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        public bool HasWord;


        // GET api/values
        [HttpGet]
        public ActionResult Index(string query = "Angular")
        {
            var repositories = ProcessRepositories(query).Result;


            using (var context = new Context())
            {
                var Keywords = context.Keywords.ToList();

                foreach (var el in Keywords)
                {
                    if (el.Name == query)
                    {
                        HasWord = true;
                    }

                }

                if (!HasWord)
                {
                    context.Keywords.Add(new Keyword { Name = query });
                    context.SaveChanges();
                    foreach (Repo element in repositories.Item)
                    {
                        context.Repos.Add(new Repo()
                        {
                            Name = element.Name,
                            Description = element.Description,
                            Forks = element.Forks,
                            Stars = element.Stars,
                            Id = element.Id,
                            Url = element.Url
                        });
                        context.SaveChanges();
                    }

                }
          
            }


            return View(repositories.Item);
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var repositories = ProcessRepositoriesById(id).Result;
            return View(repositories);
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static async Task<RepoItems> ProcessRepositories(string query)
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
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }

        }

        private static async Task<dynamic> ProcessRepositoriesById(int id)
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

        [HttpGet("search")]
        public ActionResult Search(string query)
        {
            using (var context = new Context())
            {
                var Repos = context.Repos.ToList();
                return View(Repos);
            }

        }

    }
}
