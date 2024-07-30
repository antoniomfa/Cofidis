using DATAACCESS.Models;

namespace SERVICES.Interfaces
{
    public interface ICreditManager
    {
        IEnumerable<Credit> GetAll();
        Credit GetById(int id);
        public Task<UserData> Create(int nif);
        bool SaveChanges();
    }
}
