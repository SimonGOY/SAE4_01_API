using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SAE_4._01.Models.EntityFramework
{
    public partial class BMWDBContext : DbContext
    {
        public BMWDBContext() { }
        public BMWDBContext(DbContextOptions<BMWDBContext> options)
            : base(options) { }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
