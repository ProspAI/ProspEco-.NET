using Microsoft.EntityFrameworkCore;
using Proj_ProspEco.Models;

namespace Proj_ProspEco.Data
{
    public class ProspEcoDbContext : DbContext
    {
        public ProspEcoDbContext(DbContextOptions<ProspEcoDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recomendacao> Recomendacoes { get; set; }
        public DbSet<Conquista> Conquistas { get; set; }
        public DbSet<Aparelho> Aparelhos { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<BandeiraTarifaria> BandeirasTarifarias { get; set; }
        public DbSet<RegistroConsumo> RegistrosConsumo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.PontuacaoEconom)
                .HasColumnType("NUMBER(10,2)"); 

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Recomendacoes)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Conquistas)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Aparelhos)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Metas)
                .WithOne(m => m.Usuario)
                .HasForeignKey(m => m.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Notificacoes)
                .WithOne(n => n.Usuario)
                .HasForeignKey(n => n.UsuarioId);

            modelBuilder.Entity<Aparelho>()
                .HasMany(a => a.RegistrosConsumo)
                .WithOne(rc => rc.Aparelho)
                .HasForeignKey(rc => rc.AparelhoId);
        }
    }
}
