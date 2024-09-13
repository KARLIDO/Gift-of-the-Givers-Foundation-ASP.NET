namespace Gift_of_the_Givers_Foundation.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }
        public int VolunteerId { get; set; }
        public string TaskName { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
