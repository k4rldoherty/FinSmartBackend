using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinSmartBackend.Data
{
    public class DataContext : IdentityDbContext // For User Authentication.
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
