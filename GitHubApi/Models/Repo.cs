using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace GitHubApi.Models
{
    [DataContract(Name = "repo")]
    [Table("Repo")]
    public class Repo
    {
        [Key]
        public int RepoID { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [DataMember(Name = "forks")]
        public int Forks { get; set; }

        [DataMember(Name = "stargazers_count")]
        public int Stars { get; set; }

        [DataMember(Name = "html_url")]
        public string Url { get; set; }
    }
}
