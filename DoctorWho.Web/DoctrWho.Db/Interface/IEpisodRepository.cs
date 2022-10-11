using EfDoctorWho;

namespace DoctorWho.Db.Interface
{
    public interface IEpisodRepository
    {
        public  Task<bool> CreateEpisodes(Episod episod, int AuthorId, int DoctorId);
        public void DeleteEpisod(int id);
        public Task<ICollection<Episod>> GetAllEpisods();
        public Task<int> GetLastIdEpisod();
    }
}