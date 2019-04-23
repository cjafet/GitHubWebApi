using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GitHubApi.Models
{
    [DataContract(Name = "RepoItems")]
    public class RepoItems
    {
        [DataMember(Name = "items")]
        public List<Repo> Item { get; set; }

        [DataMember(Name = "total_count")]
        public int Total { get; set; }
    }
}
