using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class Competitions : Core.Disposable
    {

        public List<Entities.Competitions> getClubHistoryCompetitions(int ClubHistroyID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@ClubHistroyID", Value =  ClubHistroyID },

            };
            return DAL2.ExecuteReader<Entities.Competitions>("spGetClubHistoryCompetitions");
        }
        public List<Entities.Competitions> getCompetitionByID(int CompetitionID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@CompetitionID", Value =  CompetitionID },

            };
            return DAL2.ExecuteReader<Entities.Competitions>("spGetCompetitionByID");
        }


        public List<Entities.CompetitionsTeams> getFirstThreePlacesInCompetionByID(int CompetitionID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@CompetitionID", Value =  CompetitionID },

            };
             
            var result = DAL2.ExecuteReader<Entities.CompetitionsTeamMembers>("spGetFirstThreePlacesInCompetionByID");
            var sortedListDescending = result.OrderBy(item => item.Place);
            var FirstSecondThird = new List<CompetitionsTeams>();
            var FirstPlaceTeam = new List<CompetitionsTeamMembers>();
            var SecondPlaceTeam = new List<CompetitionsTeamMembers>();
            var ThirdPlaceTeam = new List<CompetitionsTeamMembers>();
            foreach (var i in sortedListDescending)
            {
                if (i.Place == 1)
                {
                    FirstPlaceTeam.Add(i);
                }
                else if (i.Place == 2)
                {
                    SecondPlaceTeam.Add(i);
                }
                else if (i.Place == 3)
                {
                    ThirdPlaceTeam.Add(i);
                }
            }
            FirstSecondThird.Add(new CompetitionsTeams(FirstPlaceTeam));
            FirstSecondThird.Add(new CompetitionsTeams(SecondPlaceTeam));
            FirstSecondThird.Add(new CompetitionsTeams(ThirdPlaceTeam));





            return FirstSecondThird;
        }


    }
}

