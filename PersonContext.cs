namespace ColaAplication;

using Microsoft.EntityFrameworkCore;
using ColaAplication.Models;

public class PersonContext : DbContext
{
    public DbSet<Person> People { get; set; }

    public PersonContext (DbContextOptions<PersonContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Person> list = new List<Person>();
        list.Add(new Person
        {
            PersonId = Guid.NewGuid(),
            Name = "Roberto Abad Javier",
            Edad = 56,
            Cedula = "931-1509128-6",
            Profession = "Agricultor"
        });

        list.Add(new Person
        {
            PersonId = Guid.NewGuid(),
            Name = "Marisol De Los Santos Lara",
            Edad = 48,
            Cedula = "579-5480698-4",
            Profession = "Contadora"
        });

        modelBuilder.Entity<Person>(person =>
        {
            person.ToTable("Person");
            person.HasKey(p => p.PersonId);
            person.Property(p => p.Name).IsRequired().HasMaxLength(250);
            person.Property(p => p.Cedula).IsRequired();
            person.Property(p => p.Edad).IsRequired();
            person.HasData(list);
        });

    }
}

