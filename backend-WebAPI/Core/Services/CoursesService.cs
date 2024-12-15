using Data;
using System.Net;
using AutoMapper;
using Core.Models;
using Core.Interfaces;
using Core.Exceptions;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public class CoursesService(
    IMapper mapper,
    IFilesService filesService,
    OnlineCoursesDbContext context
    ) : ICoursesService
{
    public CourseModel GetById(int id)
    {
        var course = context.Courses.Find(id)
            ?? throw new HttpException($"Course with id {id} not found!", HttpStatusCode.NotFound);

        context.Entry(course).Reference(x => x.Category).Load();
        context.Entry(course).Reference(x => x.Level).Load();

        return mapper.Map<CourseModel>(course);
    }

    public IEnumerable<CourseModel> GetAll()
    {
        var courses = context.Courses
            .Include(x => x.Category)
            .Include(x => x.Level)
            .OrderBy(x => x.Id)
            .ToList();

        return mapper.Map<IEnumerable<CourseModel>>(courses);
    }

    public async Task Create(CourseModelCreate model)
    {
        var entity = mapper.Map<Course>(model);

        // save file to server
        if (model.Image is not null)
            entity.ImageUrl = await filesService.SaveImage(model.Image);

        context.Courses.Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task Edit(CourseModelEdit model)
    {
        var entity = mapper.Map<Course>(model);

        // rewrite file on server
        if (model.Image is not null)
            entity.ImageUrl = await filesService.EditImage(model.Image, entity.ImageUrl);

        context.Courses.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = context.Courses.Find(id)
            ?? throw new HttpException($"Course with id {id} not found!", HttpStatusCode.NotFound);

        // delete file
        if (entity.ImageUrl is not null)
            filesService.DeleteImage(entity.ImageUrl);

        context.Courses.Remove(entity);
        await context.SaveChangesAsync();
    }

    public IEnumerable<CategoryModel> GetCategories()
    {
        var categories = context.Categories.ToList();
        return mapper.Map<IEnumerable<CategoryModel>>(categories);
    }

    public IEnumerable<LevelModel> GetLevels()
    {
        var levels = context.Levels.ToList();
        return mapper.Map<IEnumerable<LevelModel>>(levels);
    }
}
