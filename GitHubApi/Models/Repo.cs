using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GitHubApi.Models
{
    [DataContract(Name = "repo")]
    public class Repo
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        [MaxLength(40)]
        public string Description { get; set; }

        [DataMember(Name = "forks")]
        public string Forks { get; set; }

        [DataMember(Name = "stargazers_count")]
        public string Stars { get; set; }
    }
}
