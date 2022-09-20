using EfDoctorWho;

namespace DoctorWho.Db.Interface
{
    public interface IEpisod
    {
        public bool CreateEpisodes(Episod episod, int AuthorId, int DoctorId);
        public void DeleteEpisod(int id);
        public ICollection<Episod> GetAllEpisods();
        public int GetLastIdEpisod();
    }
}