using Microsoft.EntityFrameworkCore;
using RC.Weather.Repositories.Models;

namespace RC.Weather.Repositories.EntityFramework
{
	public class ApplicationDbContext : DbContext
	{
		private const string TABLE_NAME_FAVORITES = "Favorites";
		private const string TABLE_NAME_CONDITIONS = "Conditions";

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			this.ConfigureFavorites(modelBuilder);
			this.ConfigureConditions(modelBuilder);
		}

		public DbSet<ConditionDbModel> Conditions { get; set; }

		public DbSet<FavoriteCityDbModel> Favorites { get; set; }

		private void ConfigureFavorites(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<FavoriteCityDbModel>()
				.ToTable(TABLE_NAME_FAVORITES)
				.HasKey(f => f.Id);

			modelBuilder.Entity<FavoriteCityDbModel>()
				.HasIndex(f => f.CityCode)
				.IsUnique();
		}

		private void ConfigureConditions(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ConditionDbModel>()
				.ToTable(TABLE_NAME_CONDITIONS)
				.HasKey(c => c.Id);

			modelBuilder.Entity<ConditionDbModel>()
				.HasIndex(c => c.CityCode)
				.IsUnique();
		}
	}
}
