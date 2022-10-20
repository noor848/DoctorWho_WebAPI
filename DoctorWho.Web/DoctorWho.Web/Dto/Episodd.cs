namespace DoctorWho.Dto
{
    public class Episodd
    {
        public int Id { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodNumber { get; set; }
        public string EpisodType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodDate { get; set; }
        public string Notes { get; set; }
    }
}
