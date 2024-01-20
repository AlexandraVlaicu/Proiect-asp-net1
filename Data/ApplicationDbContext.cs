using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proiect3.Models;

namespace proiect3.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
    public DbSet<Produs> Produse { get; set; }
    public DbSet<Categorie> Categorii { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Comanda> Comenzi { get; set; }
    public DbSet<DetaliuComanda> DetaliiComanda { get; set; }
    public DbSet<Client> Clienti { get; set; }
    public DbSet<Livrare> Livrari { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DetaliuComanda>()
        .HasKey(dc => dc.DetaliuComandaID);
        // Relația many-to-many între Produs și Categorie
        modelBuilder.Entity<Produs>()
            .HasMany(e => e.Comenzi)
            .WithMany(e => e.Produse);

        // Relația one-to-many între Comanda și DetaliuComanda
        modelBuilder.Entity<Comanda>()
            .HasMany(c => c.DetaliiComanda)
            .WithOne(dc => dc.Comanda)
            .HasForeignKey(dc => dc.ComandaID)
            .OnDelete(DeleteBehavior.Cascade);

        // Relația many-to-one între DetaliuComanda și Produs
        modelBuilder.Entity<DetaliuComanda>()
            .HasOne(dc => dc.Produs)
            .WithMany(c => c.DetaliiComanda)
            .HasForeignKey(dc => dc.ProdusID);

        // Relația one-to-one între Comanda și Livrare
        modelBuilder.Entity<Comanda>()
            .HasOne(c => c.Livrare)
            .WithOne(l => l.Comanda)
            .HasForeignKey<Livrare>(l => l.ComandaID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Produs>()
            .HasOne(r => r.Review)
            .WithMany(p => p.Produse)
            .HasForeignKey(r => r.ReviewID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Client>()
            .HasMany(r => r.Comenzi)
            .WithOne(p => p.Client)
            .HasForeignKey(r => r.ClientID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Client>()
           .HasMany(r => r.Reviews)
           .WithOne(p => p.Client)
           .HasForeignKey(r => r.ClientID)
           .OnDelete(DeleteBehavior.Cascade);
       
    }
}


