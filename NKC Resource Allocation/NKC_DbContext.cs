using Microsoft.EntityFrameworkCore;
using NKC_Resource_Allocation.DbModels;

namespace NKC_Resource_Allocation
{
    public class NKC_DbContext: DbContext
    {
        public NKC_DbContext(DbContextOptions<NKC_DbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Auditors> Auditors { get; set; }
        public DbSet<Outlets> Outlets { get; set; }
        public DbSet<Documents> Documents { get; set; }
    }
}
