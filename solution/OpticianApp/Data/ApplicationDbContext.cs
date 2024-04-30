using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpticianApp.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<OpticianApp.Models.Customer> Customer { get; set; } = default!;

public DbSet<OpticianApp.Models.OpticalPrescription> OpticalPrescription { get; set; } = default!;
    }
