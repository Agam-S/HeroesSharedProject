using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace API
{

    public class ActionsDatabaseHandler:DatabaseHandler
    {
    public static List<Actions> GetActions() {

     List<Actions> a = new List<Actions>();
     using (SqlConnection conn = new SqlConnection(GetConnectionString()))
     {
         try {
          conn.Open();
          using (SqlCommand command = new SqlCommand("SELECT * FROM ACTIONS", conn))
          {
               using (SqlDataReader reader = command.ExecuteReader())
               {
                   while (reader.Read())
                   { 
                         a.Add(new Actions(){HID = reader.GetInt32(0), VILLAINID = reader.GetInt32(1),
                        GAMEID = reader.GetInt32(2), TURNCOUNTER = reader.GetInt32(3), HITPOINTS = reader.GetInt32(4)});
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
        return a;
        
        }
      }

      public static Actions GetIDActions(int HID, int VILLAINID, int GAMEID, int TURNCOUNTER)
        {
            Actions a = new Actions();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try {
                conn.Open();
                using (SqlCommand command = new SqlCommand(string.Format("SELECT * FROM ACTIONS WHERE HID = \'{0}\' AND VILLAINID = \'{0}\' AND GAMEID = \'{0}\' AND TURNCOUNTER = \'{0}\'", HID, VILLAINID, GAMEID, TURNCOUNTER), conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            a.HID = reader.GetInt32(0);
                            a.VILLAINID = reader.GetInt32(1);
                            a.GAMEID = reader.GetInt32(2);
                            a.TURNCOUNTER = reader.GetInt32(3);
                            a.HITPOINTS = reader.GetInt32(4);
                        
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
            return a;
            }
        }
    }
}