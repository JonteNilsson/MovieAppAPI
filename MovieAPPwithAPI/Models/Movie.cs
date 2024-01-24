namespace MovieAPPwithAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int ProductionYear { get; set; }
        public string? Genre { get; set; }
        public string? BoxOffice { get; set; }
        public string? Synopsis { get; set; }
    }
}
