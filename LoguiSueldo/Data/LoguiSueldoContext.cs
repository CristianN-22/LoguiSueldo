using LoguiSueldo.Models;
using Microsoft.EntityFrameworkCore;

namespace LoguiSueldo.Data
{
    public class LoguiSueldoContext: DbContext
    {
        public LoguiSueldoContext(DbContextOptions<LoguiSueldoContext> options)
            : base(options)
        {
        }
        
        public DbSet<ART> ARTs { get; set; }

    }

}
