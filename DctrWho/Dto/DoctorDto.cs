namespace DoctorWho.Dto
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public int DoctorNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FirstEpisodDate { get; set; }
        public DateTime LastEpisodDate { get; set; }
    }
}
