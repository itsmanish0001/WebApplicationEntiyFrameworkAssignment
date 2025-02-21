namespace WebApplicationEntiyFrameworkAssignment.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int CountryId { get; set; }
        public Country Country { get; set; }

        // Navigation Property
        public ICollection<City> Cities { get; set; }
    }
}
