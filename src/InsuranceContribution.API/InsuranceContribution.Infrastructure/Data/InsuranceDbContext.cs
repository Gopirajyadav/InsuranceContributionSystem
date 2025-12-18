using Microsoft.EntityFrameworkCore;
using InsuranceContribution.Domain.Entities;

namespace InsuranceContribution.Infrastructure.Data;

public class InsuranceDbContext : DbContext
{
    public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }

    public DbSet<Insurer> Insurers => Set<Insurer>();
    public DbSet<Policy> Policies => Set<Policy>();
    public DbSet<Contribution> Contributions => Set<Contribution>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Insurer>()
            .HasIndex(x => x.InsurerCode).IsUnique();

        modelBuilder.Entity<Policy>()
            .HasIndex(x => x.PolicyNumber).IsUnique();

        modelBuilder.Entity<Contribution>()
            .HasIndex(x => x.TransactionRef).IsUnique();
    }
}
