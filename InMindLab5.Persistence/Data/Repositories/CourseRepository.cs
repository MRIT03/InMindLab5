using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data;


namespace InMindLab5.Persistence.Data.Repositories;

public class CourseRepository : IRepository<Course>
{
    private readonly UmcContext _dbContext;

    public CourseRepository(UmcContext dbContext)
    {
        _dbContext = dbContext;
        Query = _dbContext.Courses;
    }
    
    public async Task<List<Course>> GetAllAsync()
    {
        return await _dbContext.Courses.ToListAsync();
    }

    public IQueryable<Course> Query { get; }
    public async Task AddAsync(Course entity)
    {
        await _dbContext.AddAsync(entity);
        await SaveAsync();
    }

    public async Task DeleteAsync(Course entity)
    {
        _dbContext.Remove(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}