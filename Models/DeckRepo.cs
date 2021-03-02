using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MTGDeckBuilder.Models
{

    public class DeckRepo
    {
        private string _connString = ConfigurationManager.ConnectionStrings["DB_A6FB48_MTGDeckBuilderDBEntities2"].ConnectionString;

        public IEnumerable<DeckTB> GetDecks(int id)
        {
            var filteredList = new List<DeckTB>();
            if (_connString.ToLower().StartsWith("metadata="))
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(_connString);
                _connString = efBuilder.ProviderConnectionString;
            }
            //
            // Create a connection to the DB
            using (var con = new SqlConnection(_connString))
            {
                //
                // Set-up your SQL command
                var cmd = new SqlCommand("GetDecks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@playerId", id);
                //cmd.Parameters.AddWithValue("@eMail", eMail);
                //cmd.Parameters.AddWithValue("@birthDate", birthDate);
                //cmd.Parameters.AddWithValue("@showInActives", showInactive);

                //
                // Open your connection
                con.Open();
                //
                // Create your SQL Data Reader to execute your command and get your data
                SqlDataReader rdr = cmd.ExecuteReader();
                //
                // Loop through all
                while (rdr.Read())
                {
                    //
                    // Create your Student object
                    var deck = new DeckTB();
                    //
                    // Get all the values from your reader loaded into your object
                    deck.DeckId = Convert.ToInt32(rdr["DeckId"]);
                    deck.PlayerId = Convert.ToInt32(rdr["PlayerId"]);
                    deck.DeckName = rdr["DeckName"].ToString();
                    //stu.Birthdate = Convert.ToDateTime(rdr["BirthDate"]);
                    //stu.EMail = rdr["EMail"].ToString();
                    //stu.IsActive = Convert.ToBoolean(rdr["IsActive"]);
                    //
                    // Add your object to your list
                    filteredList.Add(deck);
                }
            }

            return filteredList;

        }
    }
}