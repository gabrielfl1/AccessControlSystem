namespace AccessControl.Server.Models {
    public class Schedule {

        /*
         Monday (segunda-feira), 
        Tuesday (terça-feira), 
        Wednesday (quarta-feira), 
        Thursday (quinta-feira), 
        Friday (sexta-feira), 
        Saturday (sábado),
        Sunday (domingo)
        */

        public long Id { get; set; }
        public string Name { get; set; }
        public int MondayStart { get; set; }
        public int MondayEnd { get; set; }
        public int TuesdayStart { get; set; }
        public int TuesdayEnd { get; set; }
        public int WednesdayStart { get; set; }
        public int WednesdayEnd { get; set; }
        public int ThursdayStart { get; set; }
        public int ThursdayEnd { get; set; }
        public int FridayStart { get; set; }
        public int FridayEnd { get; set; }
        public int SaturdayStart { get; set; }
        public int SaturdayEnd { get; set; }
        public int SundayStart { get; set; }
        public int SundayEnd { get; set; }

        public IList<AccessRule> AccessRules { get; set; }

    }
}
