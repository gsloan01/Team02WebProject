using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MTGDeckBuilder.Models
{
    public class CardsInDeckRepo
    {
        private string _connString = ConfigurationManager.ConnectionStrings["DB_A6FB48_MTGDeckBuilderDBEntities3"].ConnectionString;

        public IEnumerable<CustomCardTB> GetCardsInDeck(int deckId/*, int cardId*/)
        {
            var filteredList = new List<CustomCardTB>();
            if (_connString.ToLower().StartsWith("metadata="))
            {
                System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(_connString);
                _connString = efBuilder.ProviderConnectionString;
            }

            using (var con = new SqlConnection(_connString))
            {
                var cmd = new SqlCommand("GetCardsInDeck", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@deckId", deckId);
                //cmd.Parameters.AddWithValue("@cardId", cardId);

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