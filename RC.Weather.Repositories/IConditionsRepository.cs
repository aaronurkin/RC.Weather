using RC.Weather.Repositories.Models;

namespace RC.Weather.Repositories
{
	public interface IConditionsRepository
	{
		ConditionDbModel Create(ConditionDbModel condition);

		ConditionDbModel GetSingle(string cityCode);
	}
}
