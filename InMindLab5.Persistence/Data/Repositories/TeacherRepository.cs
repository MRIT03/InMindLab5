using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data;

namespace InMindLab5.Persistence.Data.Repositories;

public class TeacherRepository : IRepository<Teacher>
{
    private readonly UmcContext _dbContext;

    public TeacherRepository(UmcContext dbContext)
    {
        _dbContext = dbContext;
        Query = _dbContext.Teachers;
    }

    public IQueryable<Teacher> Query { get; }

    public async Task<List<Teacher>> GetAllAsync()
    {
        return await _dbContext.Teachers.ToListAsync();
    }

    public async Task AddAsync(Teacher entity)
    {
        await _dbContext.AddAsync(entity);
        await SaveAsync();
    }

    public async Task DeleteAsync(Teacher entity)
    {
        _dbContext.Remove(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}