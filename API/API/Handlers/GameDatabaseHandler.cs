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
                        GAMETIME = reader.GetDateTime(1)});
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
    }
}