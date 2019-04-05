using CarBuddy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarBuddy.Data
{
	public class CarNotesContext : DbContext
	{
		public CarNotesContext()
		{

		}

		public CarNotesContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }

		public DbSet<Car> Cars { get; set; }

		public DbSet<Note> Notes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //nastroiva vruskata s bazata
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Config.ConnectionString);
			}
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<User>().HasIndex(x => x.FirstName).IsUnique;
			base.OnModelCreating(modelBuilder);
		}
	}
}
