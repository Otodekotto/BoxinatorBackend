namespace BoxinatorBackend.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Multiplier { get; set; }

        //Relationship
        public string Destination { get; set; }
        public Package Package { get; set; }
    }
}
