using GitHubApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace GitHubApi.Data
{
    public class Context: DbContext
    {
        //private IConfiguration configuration;
        //private DbContextOptions<Context> _options;
        public DbSet<Repo> Repos { get; set; }
        public DbSet<Keyword> Keywords { get; set; } 

        public Context(DbContextOptions options) : base(options)
        {

        }

        //public Context()
        //{
        //    //var options = new DbContextOptionsBuilder<Context>();
        //    //options.UseSqlServer(Configuration.GetConnectionStringSecureValue("DefaultConnection"));
        //    this.Context(this);
        //    //ApplicationDbContext context = new ApplicationDbContext(options);
        //}

        //public Context() : base("Repo")
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Context"].ConnectionString);
        //        //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RepoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //        //optionsBuilder.UseSqlServer(@"Server=tcp:githubserver1.database.windows.net,1433;Initial Catalog=MSSQLLocalDB;Persist Security Info=False;User ID=adminu;Password=DBuser123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    }
        //}

    }
}
