using Core.Models;

namespace Core.Interfaces;

public interface ICoursesService
{
    CourseModel GetById(int id);
    IEnumerable<CourseModel> GetAll();
    Task Create(CourseModelCreate model);
    Task Edit(CourseModelEdit model);
    Task Delete(int id);

    IEnumerable<CategoryModel> GetCategories();
    IEnumerable<LevelModel> GetLevels();
}
