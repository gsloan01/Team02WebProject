using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MTGDeckBuilder.Models
{
    public class CustomCardRepo
    {
        private string _connString = ConfigurationManager.ConnectionStrings["DB_A6FB48_MTGDeckBuilderDBEntities3"].ConnectionString;

        public IEnumerable<CustomCardTB> GetCustomCards(int id)
        {
            var filteredList = new List<CustomCardTB>();
            if (_connString.ToLower().StartsWith("metadata="))
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(_connString);
                _connString = efBuilder.ProviderConnectionString;
            }

            using (var con = new SqlConnection(_connString))
            {
                var cmd = new SqlCommand("GetCustomCards", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@playerId", id);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var customCard = new CustomCardTB();

                    customCard.Id = Convert.ToInt32(rdr["Id"]);
                    customCard.Name = rdr["Name"].ToString();
                    customCard.Description = rdr["Description"].ToString();
                    customCard.Power = rdr["Power"].ToString();
                    customCard.Tough = rdr["Tough"].ToString();
                    customCard.Image = rdr["Image"].ToString();
                    customCard.PlayerId = Convert.ToInt32(rdr["PlayerId"]);

                    filteredList.Add(customCard);
                }
            }

            return filteredList;

        }

        public IEnumerable<CustomCardTB> SearchCustomCard(string name)
        {
            var filteredList = new List<CustomCardTB>();
            if (_connString.ToLower().StartsWith("metadata="))
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(_connString);
                _connString = efBuilder.ProviderConnectionString;
            }

            using (var con = new SqlConnection(_connString))
            {

                var cmd = new SqlCommand("SearchCustomCard", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", name);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var customCard = new CustomCardTB();

                    customCard.Id = Convert.ToInt32(rdr["Id"]);
                    customCard.Name = rdr["Name"].ToString();
                    customCard.Description = rdr["Description"].ToString();
                    customCard.Power = rdr["Power"].ToString();
                    customCard.Tough = rdr["Tough"].ToString();
                    customCard.Image = rdr["Image"].ToString();
                    customCard.PlayerId = Convert.ToInt32(rdr["PlayerId"]);

                    filteredList.Add(customCard);
                }
            }
            return filteredList;
        }

        public IEnumerable<CustomCardTB> SearchUserCustomCard(string name, int playerId)
        {
            var filteredList = new List<CustomCardTB>();
            if (_connString.ToLower().StartsWith("metadata="))
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(_connString);
                _connString = efBuilder.ProviderConnectionString;
            }

            using (var con = new SqlConnection(_connString))
            {

                var cmd = new SqlCommand("SearchUserCustomCard", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@PlayerId", playerId);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var customCard = new CustomCardTB();

                    customCard.Id = Convert.ToInt32(rdr["Id"]);
                    customCard.Name = rdr["Name"].ToString();
                    customCard.Description = rdr["Description"].ToString();
                    customCard.Power = rdr["Power"].ToString();
                    customCard.Tough = rdr["Tough"].ToString();
                    customCard.Image = rdr["Image"].ToString();
                    customCard.PlayerId = Convert.ToInt32(rdr["PlayerId"]);

                    filteredList.Add(customCard);
                }
            }
            return filteredList;
        }
    }
}