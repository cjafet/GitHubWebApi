using GitHubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GitHubApi
{
    public class Context: DbContext
    {
        public DbSet<Repo> Repos { get; set; }

        //public Context(DbContextOptions options) : base(options)
        //{
        //}

        //public Context() : base("Repo")
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RepoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

    }
}
