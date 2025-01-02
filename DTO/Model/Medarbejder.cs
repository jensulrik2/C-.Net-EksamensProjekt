namespace DTO.Model
{
    public class Medarbejder
    {
        public int MedarbejderId { get; set; }
        public string Initialer { get; set; }
        public string Cpr { get; set; }
        public string Navn { get; set; }
        public double TotalHours { get; set; }
        public List<TidsregistreringsInfo> Tidsregistreringer { get; set; } = new List<TidsregistreringsInfo>();
        public List<AfdelingsInfo> Afdelinger { get; set; } = new List<AfdelingsInfo>();



        public Medarbejder() { }
        public Medarbejder( string initialer, string cpr, string navn)
        {
            this.Initialer = initialer;
            this.Cpr = cpr;
            this.Navn = navn;
         
        }

        public Medarbejder(int MedarbejderID, string initialer, string cpr, string navn)
        {
            this.MedarbejderId = MedarbejderID;
            this.Initialer = initialer;
            this.Cpr = cpr;
            this.Navn = navn;
        }

       
    }
}
