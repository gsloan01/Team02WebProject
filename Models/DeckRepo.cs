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

            using (var con = new SqlConnection(_connString))
            {

                var cmd = new SqlCommand("GetDecks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@playerId", id);

                con.Open();
               
                SqlDataReader rdr = cmd.ExecuteReader();
                //
                // Loop through all
                while (rdr.Read())
                {
 
                    var deck = new DeckTB();
                    
                    deck.DeckId = Convert.ToInt32(rdr["DeckId"]);
                    deck.PlayerId = Convert.ToInt32(rdr["PlayerId"]);
                    deck.DeckName = rdr["DeckName"].ToString();

                    filteredList.Add(deck);
                }
            }

            return filteredList;

        }
    }
}