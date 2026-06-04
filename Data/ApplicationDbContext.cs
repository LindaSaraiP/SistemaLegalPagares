using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaLegalPagares.Models;

namespace SistemaLegalPagares.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pagare> Pagares { get; set; } = default!;

        public DbSet<Expediente> Expedientes { get; set; } = default!;

        public DbSet<Deudor> Deudores { get; set; } = default!;

        public DbSet<SubPagare> SubPagares { get; set; } = default!;

        public DbSet<PagareDeudor> PagareDeudores { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PagareDeudor>()
                .HasKey(pd => new
                {
                    pd.PagareId,
                    pd.DeudorId
                });
        }
    }
}