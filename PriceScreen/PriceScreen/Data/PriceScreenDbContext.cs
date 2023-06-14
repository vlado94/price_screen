using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PriceScreen.Models;

namespace PriceScreen.Data;

public partial class PriceScreenDbContext : DbContext
{
    public PriceScreenDbContext()
    {
    }

    public PriceScreenDbContext(DbContextOptions<PriceScreenDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Store> Stores { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=DESKTOP-9RT02VE; Database=PriceScreenDB; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
