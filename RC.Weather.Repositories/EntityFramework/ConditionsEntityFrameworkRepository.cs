using Microsoft.EntityFrameworkCore;
using RC.Weather.Repositories.Models;
using System.Linq;

namespace RC.Weather.Repositories.EntityFramework
{
	public class ConditionsEntityFrameworkRepository : IConditionsRepository
	{
		private readonly ApplicationDbContext dbContext;

		public ConditionsEntityFrameworkRepository(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public ConditionDbModel Create(ConditionDbModel condition)
		{
			var created = this.dbContext.Conditions.Add(condition);
			this.dbContext.SaveChanges();
			return created.Entity;
		}

		public ConditionDbModel GetSingle(string cityCode)
		{
			var condition = this.dbContext.Conditions.AsNoTracking().FirstOrDefault(c => c.CityCode == cityCode);
			return condition;
		}
	}
}
