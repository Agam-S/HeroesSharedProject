using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace API
{
    public class HeroDatabaseHandler:DatabaseHandler
    {
        public static List<Hero> GetHero(){

     List<Hero> h = new List<Hero>();
     using (SqlConnection conn = new SqlConnection(GetConnectionString()))
     {
         try {
          conn.Open();
          using (SqlCommand command = new SqlCommand("SELECT * FROM HERO", conn))
          {
               using (SqlDataReader reader = command.ExecuteReader())
               {
                   while (reader.Read())
                   { 
                         h.Add(new Hero(){HID = reader.GetInt32(0),
                         HNAME = reader.GetString(1), MINVALUE = reader.GetInt32(2),
                         MAXVALUE = reader.GetInt32(3), USES = reader.GetInt32(4)});
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
     return h;
    }
    }


    public static Hero GetIDHero(int HID)
        {
            Hero hero = new Hero();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try {
                conn.Open();
                using (SqlCommand command = new SqlCommand(string.Format("SELECT * FROM HERO WHERE HID = \'{0}\'", HID), conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            hero.HID = reader.GetInt32(0);
                            hero.HNAME = reader.GetString(1);
                            hero.MINVALUE = reader.GetInt32(2);
                            hero.MAXVALUE = reader.GetInt32(3);
                            hero.USES = reader.GetInt32(4);
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
            return hero;
            }
        }


        public static string PostHero(Hero h)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("POST_HERO", conn))
                {
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@pHID", h.HID);
               command.Parameters.AddWithValue("@pHNAME", h.HNAME);
               command.Parameters.AddWithValue("@pMINVALUE", h.MINVALUE);
               command.Parameters.AddWithValue("@pMAXVALUE", h.MAXVALUE);
               command.Parameters.AddWithValue("@pUSES", h.USES);

               int results = command.ExecuteNonQuery();

                    conn.Close();
                    if (results >= 1)
                    {
                        return "SUCCESSSS)";
                    }
                    else
                    {
                        return "HERO DOESNT WORK!!!";
                    }
                }
            }
            }
            
        

        public static string PutHero(Hero h)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("PUT_HERO", conn))
                {
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@pHID", h.HID);
               command.Parameters.AddWithValue("@pHNAME", h.HNAME);
               command.Parameters.AddWithValue("@pMINVALUE", h.MINVALUE);
               command.Parameters.AddWithValue("@pMAXVALUE", h.MAXVALUE);
               command.Parameters.AddWithValue("@pUSES", h.USES);
               int results = command.ExecuteNonQuery();
                    conn.Close();

                    if (results >= 1)
                    {
                        return "SUCCESSSS)";
                    }
                    else
                    {
                        return "HERO DOESNT WORK!!!";
                    }
                }
            }
            
        }

          public static string DeleteHero(int HID) 
          {
          using (SqlConnection conn = new SqlConnection(GetConnectionString()))
               {
               conn.Open();
               using (SqlCommand command = new SqlCommand("DELETE_HERO", conn))
               {
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@pHID", HID);   
               int results = command.ExecuteNonQuery();
               conn.Close();
               
               if (results >= 1) 
                    {
                        return "SUCCESSS";
                    }
                    else
                    {
                        return "HERO DOESNT WORK!!!";
                    }

               }
               }

          }
    }
}
