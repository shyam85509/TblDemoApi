using Microsoft.EntityFrameworkCore;


namespace TblDemoApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public virtual DbSet<TblDemoModel> TblDemoModels { get; set; }

    }
}
