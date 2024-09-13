namespace Gift_of_the_Givers_Foundation.Models
{
    public class DisasterIncident
    {
        public int Id { get; set; }
        public string IncidentType { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Severity { get; set; }
        public string Description { get; set; }
    }

}
