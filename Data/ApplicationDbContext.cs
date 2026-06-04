using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaLegalPagares.Models;

namespace SistemaLegalPagares.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // =========================
        // DBSETS
        // =========================

        public DbSet<Cliente> Clientes { get; set; } = default!;

        public DbSet<Expediente> Expedientes { get; set; } = default!;

        public DbSet<Deudor> Deudores { get; set; } = default!;

        public DbSet<Pagare> Pagares { get; set; } = default!;

        public DbSet<SubPagare> SubPagares { get; set; } = default!;

        public DbSet<PagareDeudor> PagareDeudores { get; set; } = default!;


        // =========================
        // CONFIGURACIÓN DE RELACIONES
        // =========================

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Cliente 1 ---- N Expedientes
            builder.Entity<Expediente>()
                .HasOne(e => e.Cliente)
                .WithMany(c => c.Expedientes)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Expediente 1 ---- N Pagares
            builder.Entity<Pagare>()
                .HasOne(p => p.Expediente)
                .WithMany(e => e.Pagares)
                .HasForeignKey(p => p.ExpedienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Pagare 1 ---- N SubPagares
            builder.Entity<SubPagare>()
                .HasOne(sp => sp.Pagare)
                .WithMany(p => p.SubPagares)
                .HasForeignKey(sp => sp.PagareId)
                .OnDelete(DeleteBehavior.Cascade);

            // Llave compuesta para tabla intermedia PagareDeudor
            builder.Entity<PagareDeudor>()
                .HasKey(pd => new
                {
                    pd.PagareId,
                    pd.DeudorId
                });

            // PagareDeudor N ---- 1 Pagare
            builder.Entity<PagareDeudor>()
                .HasOne(pd => pd.Pagare)
                .WithMany(p => p.PagareDeudores)
                .HasForeignKey(pd => pd.PagareId)
                .OnDelete(DeleteBehavior.Cascade);

            // PagareDeudor N ---- 1 Deudor
            builder.Entity<PagareDeudor>()
                .HasOne(pd => pd.Deudor)
                .WithMany(d => d.PagareDeudores)
                .HasForeignKey(pd => pd.DeudorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}