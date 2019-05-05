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

        public PagedList<Team> GetTeams(UserParams userParams)
        {
            string sql = "select profile_id, name, about, country, rating from core.teams_data where rating > 0";
            List<Team> teams = new List<Team>();
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
                    teams.Add(new Team(teamId, name, about, country, rating));
                }
                dataReader.Close();
            }
            _connection.Close();
            return PagedList<Team>.Create(teams.AsQueryable(), userParams.PageNumber, userParams.PageSize);
        }
    }
}