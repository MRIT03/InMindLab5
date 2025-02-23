using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using InMindLab5.Domain.Entities;
using InMindLab5.Persistence.Data;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace InMindLab5.Persistence.Data.Repositories;

public class StudentRepository : IRepository<Student>
{
    private readonly UmcContext _dbContext;
    private readonly IDistributedCache _cache;
    private readonly IConnectionMultiplexer _redis;

    public StudentRepository(UmcContext dbContext, IDistributedCache cache, IConnectionMultiplexer redis)
    {
        _dbContext = dbContext;
        Query = _dbContext.Students;
        _cache = cache;
        _redis = redis;
    }

    public IQueryable<Student> Query { get; }

    public async Task<List<Student>> GetAllAsync()
    {
        String cacheKey = "Students";
        string? cacheData = await _cache.GetStringAsync(cacheKey);
        if (!string.IsNullOrEmpty(cacheData))
        {
            return JsonSerializer.Deserialize<List<Student>>(cacheData);
        }
        var students = await _dbContext.Students.ToListAsync();
        if (students.Count > 0)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
            };
            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(students), options);
        }
        
        
        return students;
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