using System;

namespace API {

    public class Villain {

        
        public int VillainID { get; set; }
        public string VName { get; set; }
        public int HitPoints { get; set; }


        public Villain(int villainID, string vName, int hitPoints) 
        {
            this.VillainID = villainID;
            this.VName = vName;
            this.HitPoints = hitPoints;
               
        }
    }
}
