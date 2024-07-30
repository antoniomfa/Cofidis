using Microsoft.EntityFrameworkCore;

namespace DATAACCESS.Repo
{
    public class CofidisRepo : ICofidisRepo
    {
        private readonly CofidisDbContext _context;
        public CofidisRepo(CofidisDbContext context)
        {
            _context = context;
        }


        // Case for asked Storage Procedure
        public void ExecuteStoredProcedure()
        {
            _context.Database.ExecuteSqlRaw("EXEC CofidisSP");
        }
    }
}
