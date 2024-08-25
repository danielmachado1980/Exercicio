using Newtonsoft.Json;

namespace Questao2.Domain.Models
{
    public class FootballMatchesResponse
    {
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int ItemsPerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages{get; set;}

        [JsonProperty("data")]
        public List<MatchData>? MatcheData { get; set; }
    }
}
