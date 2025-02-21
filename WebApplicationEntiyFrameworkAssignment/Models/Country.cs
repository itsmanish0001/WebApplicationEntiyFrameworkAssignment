namespace WebApplicationEntiyFrameworkAssignment.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<State> States { get; set; }
    }
}
