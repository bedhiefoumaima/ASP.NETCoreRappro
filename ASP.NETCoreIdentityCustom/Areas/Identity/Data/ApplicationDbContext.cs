using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rappro.Data;

namespace ASP.NETCoreIdentityCustom.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
        : base(option)
    {
    }

    public DbSet<Actif> Actifs { get; set; }
    public  DbSet<Passif> Passifs { get; set; }
    public  DbSet<Rapprochement> Rapprochements { get; set; }
    public  DbSet<Valeursnonsim> Valeursnonsims { get; set; }
    public  DbSet<Valeurssim> Valeurssims { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Actif>(entity =>
        {
            entity.HasKey(e => e.NumActif)
                .HasName("PRIMARY");

            entity.ToTable("actif");

            entity.Property(e => e.NumActif).HasColumnType("int(11)");

            entity.Property(e => e.FichierActif)
                .HasMaxLength(45)
                .HasColumnName("fichierActif");
        });
        builder.Entity<Passif>(entity =>
        {
            entity.HasKey(e => e.NumPassif)
                .HasName("PRIMARY");

            entity.ToTable("passif");

            entity.Property(e => e.NumPassif).HasColumnType("int(11)");

            entity.Property(e => e.FichierPassif)
                .HasMaxLength(45)
                .HasColumnName("fichierPassif");
        });

        builder.Entity<Rapprochement>(entity =>
        {
            entity.HasKey(e => e.NumRapp)
                .HasName("PRIMARY");

            entity.ToTable("rapprochement");

            entity.HasIndex(e => e.NumActif, "NumActif_idx");

            entity.HasIndex(e => e.NumPassif, "NumPassif_idx");

            entity.HasIndex(e => e.Id, "NumUtilisateur_idx");

            entity.Property(e => e.NumRapp).HasColumnType("int(11)");

            entity.Property(e => e.DateRapp).HasColumnType("date");

            entity.Property(e => e.FichierRapp)
                .HasMaxLength(45)
                .HasColumnName("fichierRapp");

            entity.Property(e => e.NumActif).HasColumnType("int(11)");

            entity.Property(e => e.NumPassif).HasColumnType("int(11)");

            entity.Property(e => e.Id).HasColumnType("NumUtilisateur");

            entity.HasOne(d => d.NumActifNavigation)
                .WithMany(p => p.Rapprochements)
                .HasForeignKey(d => d.NumActif)
                .HasConstraintName("NumActif");

            entity.HasOne(d => d.NumPassifNavigation)
                .WithMany(p => p.Rapprochements)
                .HasForeignKey(d => d.NumPassif)
                .HasConstraintName("NumPassif");

            entity.HasOne(d => d.IdNavigation)
                .WithMany(p => p.Rapprochements)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("NumUtilisateur");
        });



        builder.Entity<Valeursnonsim>(entity =>
        {
            entity.HasKey(e => e.Idvns)
                .HasName("PRIMARY");

            entity.ToTable("valeursnonsim");

            entity.HasIndex(e => e.NumRapp, "NumRapp_idx");

            entity.Property(e => e.Idvns)
                .HasColumnType("int(11)")
                .HasColumnName("IDVNS");

            entity.Property(e => e.FichierVns)
                .HasMaxLength(45)
                .HasColumnName("FichierVNS");

            entity.Property(e => e.NumRapp).HasColumnType("int(11)");

            entity.HasOne(d => d.NumRappNavigation)
                .WithMany(p => p.Valeursnonsims)
                .HasForeignKey(d => d.NumRapp)
                .HasConstraintName("NumRapp");
        });

        builder.Entity<Valeurssim>(entity =>
        {
            entity.HasKey(e => e.Idvs)
                .HasName("PRIMARY");

            entity.ToTable("valeurssim");

            entity.HasIndex(e => e.NumRapp, "NumRapp_idx");

            entity.Property(e => e.Idvs)
                .HasColumnType("int(11)")
                .HasColumnName("IDVS");

            entity.Property(e => e.FichierVs)
                .HasMaxLength(45)
                .HasColumnName("FichierVS");

            entity.Property(e => e.NumRapp).HasColumnType("int(11)");

            entity.HasOne(d => d.NumRappNavigation)
                .WithMany(p => p.Valeurssims)
                .HasForeignKey(d => d.NumRapp)
                .HasConstraintName("NumRRapp");
        });

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(e => e.Id)
                    .HasName("PRIMARY");
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}