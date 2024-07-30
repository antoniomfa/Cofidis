using DATAACCESS.Models;

namespace SERVICES.Interfaces
{
    public interface IChaveMovelDigitalManager
    {
        // Get user data by NIF
        public Task<UserData> GetByNif(int nif);
    }
}
