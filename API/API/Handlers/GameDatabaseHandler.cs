using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace API
{

    public class GameDatabaseHandler:DatabaseHandler
    {
    public static List<Game> GetGames() {

     List<Game> g = new List<Game>();
     using (SqlConnection conn = new SqlConnection(GetConnectionString()))
     {
         try {
          conn.Open();
          using (SqlCommand command = new SqlCommand("SELECT * FROM GAME", conn))
          {
               using (SqlDataReader reader = command.ExecuteReader())
               {
                   while (reader.Read())
                   { 
                         g.Add(new Game(){GAMEID = reader.GetInt32(0),
                        GAMETIME = reader.GetDateTime(1),
                        WHOWON = reader.GetString(2)});
                  }
             }
        }
        }
        catch (Exception e)
        {
          throw new Exception("Error in GetAllDemoFromDB() " + e.Message);
        }
        finally {
        conn.Close();
        }
        return g;
        
        }
      }

     public static Game GetIDGame(int GameID)
        {
            Game g = new Game();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try {
                conn.Open();
                using (SqlCommand command = new SqlCommand(string.Format("SELECT * FROM GAME WHERE GAMEID = \'{0}\'", GameID), conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            g.GAMEID = reader.GetInt32(0);
                            g.GAMETIME = reader.GetDateTime(1);
                            g.WHOWON = reader.GetString(2);
                        
                        }
                    }
                }
                }
            catch (Exception e)
            {
                throw new Exception("Error in GetAllDemoFromDB() " + e.Message);
            }
            finally
            {
                conn.Close();
            }
            return g;
            }
        }

        
        public static string PostGame(Game g)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("POST_GAME", conn))
                {
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@pGAMEID", g.GAMEID);
               command.Parameters.AddWithValue("@pGAMETIME", g.GAMETIME);
               command.Parameters.AddWithValue("@pWHOWON", g.WHOWON);

               int results = command.ExecuteNonQuery();
                    conn.Close();

                    if (results >= 1)
                    {
                        return "SUCCESSSS)";
                    }
                    else
                    {
                        return "ACTIONS POST FAILED!!!";
                    }
                }
            }
            
        }


    }
}