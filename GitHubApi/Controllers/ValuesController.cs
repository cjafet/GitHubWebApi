using GitHubApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace GitHubApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        // private RepoRepository _repoRepository = new RepoRepository();
        public bool HasWord;
        private Context _context = null;

        // Making sure we are creating just one instance of the context class
        public ValuesController()
        {
            _context = new Context();
        }


        // GET api/values
        [HttpGet]
        public ActionResult Index(string query = "Angular")
        {
            var repositories = ApiRepoRepository.GetRepositories(query).Result;


            var Keywords = DbKeywordRepository.GetKeyword(_context);

            foreach (var el in Keywords)
            {
                if (el.Name == query)
                {
                    HasWord = true;
                }

            }

            if (!HasWord)
            {
                DbKeywordRepository.AddKeyword(_context, query);
                DbRepoRepository.AddRepository(_context, repositories);
            }
          

            return View(repositories.Item);
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var repositories = ApiRepoRepository.GetRepositoriesById(id).Result;
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

        [HttpGet("search")]
        public ActionResult Search(string query)
        {

            var Repos = DbRepoRepository.GetRepositories(_context);
            return View(Repos);
            

        }

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {

            if (_disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;

            base.Dispose(disposing);
        }

    }
}
