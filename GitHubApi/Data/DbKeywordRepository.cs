using GitHubApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubApi.Data
{
    public class DbKeywordRepository
    {
        public static List<Keyword> GetKeyword(Context context)
        {
            return context.Keywords.ToList();
        }

        public static void AddKeyword(Context context, string query)
        {   
            context.Keywords.Add(new Keyword { Name = query });
            context.SaveChanges();
        }
    }
}
