﻿namespace WebApplicationEntiyFrameworkAssignment.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
