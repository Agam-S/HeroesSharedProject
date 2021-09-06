using System;

namespace API {

    public class Hero {

        
        public int heroID { get; set; }
        public string HName { get; set; }  
        public int min_Value { get; set; }
        public int max_Value { get; set; }
        public int TotalUses { get; set; }


        public Hero(int heroID, string hName, int min_Value, int max_Value, int totalUses) 
        {
                this.heroID = heroID;
                this.HName = hName;
                this.min_Value = min_Value;
                this.max_Value = max_Value;
                this.TotalUses = totalUses;
               
        }
    }



}

