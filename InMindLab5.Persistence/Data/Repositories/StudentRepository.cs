using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data;

namespace InMindLab5.Persistence.Data.Repositories;

public class StudentRepository : IRepository<Student>
{
    private readonly UmcContext _dbContext;

    public StudentRepository(UmcContext dbContext)
    {
        _dbContext = dbContext;
        Query = _dbContext.Students;
    }

    public IQueryable<Student> Query { get; }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _dbContext.Students.ToListAsync();
    }

    public async Task AddAsync(Student entity)
    {
        await _dbContext.AddAsync(entity);
        await SaveAsync();
    }

    public async Task DeleteAsync(Student entity)
    {
        _dbContext.Remove(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}