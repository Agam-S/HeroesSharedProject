using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace API
{
    public static class DatabaseHandler
    {

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
    }

}