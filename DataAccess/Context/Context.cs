using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    internal class Context : DbContext
    {
        public DbSet<Afdeling> Afdelinger { get; set; }
        public DbSet<Medarbejder> Medarbejdere { get; set; }
        public DbSet<Sag> Sager { get; set; }
        public DbSet<Tidsregistrering> Tidsregistreringer { get; set; }

        public Context()
        {
            bool created = Database.EnsureCreated();
            if (created)
            {
                Debug.WriteLine("Database Created");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=LAPTOP-BL7HBSRP\\SQLEXPRESS01;Initial Catalog=CSharpEksamen;Integrated Security=SSPI; TrustServerCertificate=true");
            optionsBuilder.LogTo(message => Debug.WriteLine(message));

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afdeling>()
                .HasKey(a => a.AfdelingNr);

            modelBuilder.Entity<Sag>()
                .HasKey(s => s.SagsId);


            modelBuilder.Entity<Medarbejder>()
                .HasKey(a => a.MedarbejderId);

            modelBuilder.Entity<Tidsregistrering>()
                .HasKey(t => t.TidsregistreringId);

            // Define relationships
            modelBuilder.Entity<Afdeling>()
                .HasMany(a => a.Medarbejdere)
                .WithMany(m => m.Afdelinger)
                .UsingEntity<Dictionary<string, object>>(
                    "AfdelingMedarbejder", // Join table name
                    j => j.HasOne<Medarbejder>().WithMany().HasForeignKey("MedarbejderId"),
                    j => j.HasOne<Afdeling>().WithMany().HasForeignKey("AfdelingNr")
                );

            modelBuilder.Entity<Afdeling>()
                .HasMany(a => a.Sager)
                .WithOne(s => s.Afdeling)
                .HasForeignKey(s => s.AfdelingNr); // Correctly specify the foreign key here

            // Seed data for Afdeling
            Afdeling a1 = new ("IT Support") { AfdelingNr = 1 };
            Afdeling a2 = new ("HR") { AfdelingNr = 2 };
            Afdeling a3 = new ("Finance") { AfdelingNr = 3 };

            modelBuilder.Entity<Afdeling>().HasData(a1, a2, a3);

            // Seed data for Medarbejder
            Medarbejder m1 = new ("JD", "1234567890", "John Doe") { MedarbejderId = 1 };
            Medarbejder m2 = new ("JS", "0987654321", "Jane Smith") { MedarbejderId = 2 };
            Medarbejder m3 = new ("BJ", "1234567890", "Bo Johnson") { MedarbejderId = 3 };

            modelBuilder.Entity<Medarbejder>().HasData(m1, m2, m3);

            // Seed data for Sager (cases) using foreign key for AfdelingNr
            Sag s1 = new ("Network Downtime", "There was an issue with the network connection in IT Support", 1) { SagsId = 1 };
            Sag s2 = new ("Employee Recruitment", "HR is handling a recruitment for a new developer", 2) { SagsId = 2 };
            Sag s3 = new ("Budget Planning", "The finance department is working on the yearly budget", 3) { SagsId = 3 };
            modelBuilder.Entity<Sag>().HasData(s1, s2, s3);

            // kobling af medarbejdere til afdelinger
            modelBuilder.Entity("AfdelingMedarbejder").HasData(
                new { AfdelingNr = 1, MedarbejderId = 1 }, // John Doe in IT Support
                new { AfdelingNr = 2, MedarbejderId = 2 }, // Jane Smith in HR
                new { AfdelingNr = 3, MedarbejderId = 3 }, // Bo Johnson in Finance
                new { AfdelingNr = 2, MedarbejderId = 1 } // John Doe also in HR
            );
        }
    }

}

