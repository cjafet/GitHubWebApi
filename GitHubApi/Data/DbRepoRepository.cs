using GitHubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
    public class DbRepoRepository
    {
        public static List<Repo> GetRepositories(Context context)
        {

            return context.Repos.ToList();
          
        }

        public static void AddRepository(Context context, RepoItems repositories)
        {
            
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
}
