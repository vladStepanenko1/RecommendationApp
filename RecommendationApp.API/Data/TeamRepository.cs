using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using NpgsqlTypes;
using RecommendationApp.API.Helpers;
using RecommendationApp.API.Models;

namespace RecommendationApp.API.Data
{
    public class TeamRepository : ITeamRepository
    {
        private NpgsqlConnection _connection;

        public TeamRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public Team GetTeam(int id)
        {
            string sql = "select profile_id, name, about, country, rating from core.teams_data where profile_id = @teamId";
            Team team = null;
            _connection.Open();
            using(NpgsqlCommand command = new NpgsqlCommand(sql, _connection))
            {
                NpgsqlParameter parameter = new NpgsqlParameter
                {
                    ParameterName = "@teamId",
                    Value = id,
                    NpgsqlDbType = NpgsqlDbType.Integer
                };
                command.Parameters.Add(parameter);

                NpgsqlDataReader dataReader = command.ExecuteReader();

                int teamId;
                string name;
                string about;
                string country;
                double rating;

                while (dataReader.Read())
                {
                    teamId = Convert.ToInt32(dataReader["profile_id"]);
                    name = Convert.ToString(dataReader["name"]);
                    about = Convert.ToString(dataReader["about"]);
                    country = Convert.ToString(dataReader["country"]);
                    rating = Convert.ToDouble(dataReader["rating"]);
                    team = new Team(teamId, name, about, country, rating);
                }
                dataReader.Close();
            }
            _connection.Close();
            return team;
        }

        public PagedList<Team> GetTeams(TeamParams teamParams)
        {
            string sql = "select profile_id, name, about, country, rating from core.teams_data where rating > 0";
            List<Team> teamsFromDb = new List<Team>();
            _connection.Open();
            using (NpgsqlCommand command = new NpgsqlCommand(sql, _connection))
            {
                NpgsqlDataReader dataReader = command.ExecuteReader();
                int teamId;
                string name;
                string about;
                string country;
                double rating;
                while (dataReader.Read())
                {
                    teamId = Convert.ToInt32(dataReader["profile_id"]);
                    name = Convert.ToString(dataReader["name"]);
                    about = Convert.ToString(dataReader["about"]);
                    country = Convert.ToString(dataReader["country"]);
                    rating = Convert.ToDouble(dataReader["rating"]);
                    teamsFromDb.Add(new Team(teamId, name, about, country, rating));
                }
                dataReader.Close();
            }
            _connection.Close();

            IQueryable<Team> teams = teamsFromDb.AsQueryable();

            if(!string.IsNullOrEmpty(teamParams.Name))
            {
                teams = teams.Where(t => t.Name == teamParams.Name);
            }

            if(!string.IsNullOrEmpty(teamParams.Country))
            {
                teams = teams.Where(t => t.Country == teamParams.Country);
            }
            
            teams = teams.Where(t => t.Rating > teamParams.MinRating && t.Rating < teamParams.MaxRating);

            return PagedList<Team>.Create(teams, teamParams.PageNumber, teamParams.PageSize);
        }

        public IEnumerable<string> GetCountries()
        {
            string sql = "select distinct country from core.teams_data where rating > 0";
            List<string> countries = new List<string>();
            _connection.Open();
            using(NpgsqlCommand command = new NpgsqlCommand(sql, _connection))
            {
                NpgsqlDataReader reader = command.ExecuteReader();
                string countryName;
                while(reader.Read())
                {
                    countryName = Convert.ToString(reader["country"]);
                    countries.Add(countryName);
                }
                reader.Close();
            }
            _connection.Close();
            
            return countries;
        }
    }
}