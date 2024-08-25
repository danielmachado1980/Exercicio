
using Questao2.Client;
using Questao2.Domain.Models;

namespace Questao2.Services
{
    public class FootballMatchesService
    {
        private readonly FootballMatchesApiClient _footballMatchesApiClient = new();

        public int GetTotalGoalsByTeamAndYear(string team, int year)
        {
            int? totalGoals;

            FootballMatchesResponse response = _footballMatchesApiClient.GetByTeam1AndYear(team, year);

            totalGoals = response.MatcheData?.Sum(x => x.Team1Goals);

            while ((response.Page != response.TotalPages) && response.TotalPages>0)
            {
                response = _footballMatchesApiClient.GetByTeam1AndYear(team, year, response.Page+1);
                totalGoals += response.MatcheData?.Sum(x => x.Team1Goals);
            }

            response = _footballMatchesApiClient.GetByTeam2AndYear(team, year);

            totalGoals += response.MatcheData?.Sum(x => x.Team2Goals);

            while ((response.Page != response.TotalPages) && response.TotalPages > 0)
            {
                response = _footballMatchesApiClient.GetByTeam2AndYear(team, year, response.Page + 1);
                totalGoals += response.MatcheData?.Sum(x => x.Team2Goals);
            }

            return totalGoals ?? 0;
        }
    }
}
