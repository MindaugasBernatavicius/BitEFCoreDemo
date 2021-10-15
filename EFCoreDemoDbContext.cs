using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

class EFCoreDemoDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("data source=.; database=EF; integrated security=True");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .Property(p => p.Name)
            .HasColumnName("Vardenis")
            .HasColumnType("varchar(15)");

        modelBuilder.Entity<Department>()
            .Property(p => p.Name)
            .HasColumnName("DepName");

        modelBuilder.Entity<Department>().HasData(
            new Department() { Id = 1, Name = "IT" },
            new Department() { Id = 2, Name = "Marketing" },
            new Department() { Id = 3, Name = "HR" }
        );
        modelBuilder.Entity<Employee>().HasData(
            new Employee(999, "Mindaugas"),
            new Employee(5156, "Jonas"),
            new Employee(65, "Petras")
        );

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Departments)
            .WithMany(d => d.Employees)
            .UsingEntity<DepartmentEmployee>(
                de => de.HasOne<Department>().WithMany(),
                de => de.HasOne<Employee>().WithMany()
            )
            .Property(de => de.DateJoined).
            HasDefaultValueSql("getdate()");
    }
}
