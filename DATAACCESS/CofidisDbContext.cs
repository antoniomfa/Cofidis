using Microsoft.EntityFrameworkCore;

namespace DATAACCESS
{
    public class CofidisDbContext : DbContext
    {
        public CofidisDbContext(DbContextOptions<CofidisDbContext> options) : base(options)
        {

        }
    }
}
