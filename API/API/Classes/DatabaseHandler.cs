using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace API
{
    public static class DatabaseHandler
    {
        // ========================== Connecting to the Database ================================================
    static string GetConnectionString() {
    try{
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "prg-database.c7ksa2nabbvq.us-east-1.rds.amazonaws.com";
        builder.UserID = "admin";
        builder.Password = "12345678";
        builder.InitialCatalog = "DemoDataDBS";
        return builder.ConnectionString;
    }   
     catch (Exception e){
        throw new Exception("Error in GetConnectionString() :" + e.Message);
    }    
}
   // ========================== Hero Section ================================================
    public static List<Hero> GetHero(){

     List<Hero> h = new List<Hero>();
     using (SqlConnection conn = new SqlConnection(GetConnectionString()))
     {
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
        conn.Close();
        }
        return h;
        
        }

 public static Hero GetIDHero(int HID)
        {
            Hero hero = new Hero();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
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
                conn.Close();
            }
            return hero;
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

        // ========================== Villain Section ================================================

    public static List<Villain> GetVillains(){

     List<Villain> v = new List<Villain>();
     using (SqlConnection conn = new SqlConnection(GetConnectionString()))
     {
          conn.Open();
          using (SqlCommand command = new SqlCommand("SELECT * FROM VILLAIN", conn))
          {
               using (SqlDataReader reader = command.ExecuteReader())
               {
                   while (reader.Read())
                   { 
                         v.Add(new Villain(){VillainID = reader.GetInt32(0),
                         VName = reader.GetString(1), HitPoints = reader.GetInt32(2)});
                  }
             }
        }
        conn.Close();
        }
        return v;
        
        }

        public static Villain GetIDVillain(int VillainID)
        {
            Villain v = new Villain();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(string.Format("SELECT * FROM VILLAIN WHERE VillainID = \'{0}\'", VillainID), conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            v.VillainID = reader.GetInt32(0);
                            v.VName = reader.GetString(1);
                            v.HitPoints = reader.GetInt32(2);
                           
                        }
                    }
                }
                conn.Close();
            }
            return v;
        }

        public static string PostVillain(Villain v)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("POST_VILLAIN", conn))
                {
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@pVillainID", v.VillainID);
               command.Parameters.AddWithValue("@pVName", v.VName);
               command.Parameters.AddWithValue("@pHitPoints", v.HitPoints);

               int results = command.ExecuteNonQuery();
                    conn.Close();

                    if (results >= 1)
                    {
                        return "SUCCESSSS)";
                    }
                    else
                    {
                        return "VILLAIN DOESNT WORK!!!";
                    }
                }
            }
            
        }

        public static string PutVillain(Villain v)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("PutVillain", conn))
                {
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@pVillainID", v.VillainID);
               command.Parameters.AddWithValue("@pVName", v.VName);
               command.Parameters.AddWithValue("@pHitPoints", v.HitPoints);

               int results = command.ExecuteNonQuery();
                    conn.Close();

                    if (results >= 1)
                    {
                        return "SUCCESSSS)";
                    }
                    else
                    {
                        return "VILLAIN DOESNT WORK!!!";
                    }
                }
            }
            
        }

        public static string DeleteVillain(int VillainID) 
          {
          using (SqlConnection conn = new SqlConnection(GetConnectionString()))
               {
               conn.Open();
               using (SqlCommand command = new SqlCommand("DELETE_Villain", conn))
               {
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@pVillainID", VillainID);   
               int results = command.ExecuteNonQuery();
               conn.Close();
               
               if (results >= 1) 
                    {
                        return "SUCCESSS";
                    }
                    else
                    {
                        return "VILLAIN DOESNT WORK!!!";
                    }

               }
               }

          }



     }
}