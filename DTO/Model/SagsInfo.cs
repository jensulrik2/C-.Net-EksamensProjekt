namespace DTO.Model
{
    public class SagsInfo
    {
        public int SagsId { get; set; }
        public string Overskrift { get; set; }
        public string Beskrivelse { get; set; }
        // Foreign key
        public int AfdelingNr { get; set; }

        // Constructor to initialize from AfdelingsInfo
        public SagsInfo(int sagsId, string overskrift, string beskrivelse, int afdelingNr)
        {
            this.SagsId = sagsId;
            this.Overskrift = overskrift;
            this.Beskrivelse = beskrivelse;
            this.AfdelingNr = afdelingNr;
        }

        public SagsInfo(string overskrift, string beskrivelse, int afdelingNr)
        {
            this.Overskrift = overskrift;
            this.Beskrivelse = beskrivelse;
            this.AfdelingNr = afdelingNr;
        }


    }
}
