using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace API
{

    public class VillainDatabaseHandler:DatabaseHandler
    {
    public static List<Villain> GetVillains() {

     List<Villain> v = new List<Villain>();
     using (SqlConnection conn = new SqlConnection(GetConnectionString()))
     {
         try {
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
        }
        catch (Exception e)
        {
          throw new Exception("Error in GetAllDemoFromDB() " + e.Message);
        }
        finally {
        conn.Close();
        }
        return v;
        
        }
      }

        public static Villain GetIDVillain(int VillainID)
        {
            Villain v = new Villain();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try {
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
                }
                catch (Exception e)
                {
                throw new Exception("Error in GetAllDemoFromDB() " + e.Message);
                }
                finally {
                conn.Close();
            }
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