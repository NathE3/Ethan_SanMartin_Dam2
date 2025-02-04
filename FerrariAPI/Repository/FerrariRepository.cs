using FerrariAPI.Data;
using FerrariAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using FerrariAPI.Models.Entity;
using System.Diagnostics;

namespace FerrariAPI.Repository
{
    public class FerrariRepository : IFerrariRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string FerrariCacheKey = "FerrariCacheKey";
        private readonly int CacheExpirationTime = 3600;
        public FerrariRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
            {
                ClearCache();
            }
            return result;
        }

        public void ClearCache()
        {
            _cache.Remove(FerrariCacheKey);
        }

        public async Task<ICollection<FerrariEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(FerrariCacheKey, out ICollection<FerrariEntity> categoriesCached))
                return categoriesCached;

            var categoriesFromDb = await _context.Ferraris.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(FerrariCacheKey, categoriesFromDb, cacheEntryOptions);
            return categoriesFromDb;
        }

        public async Task<FerrariEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(FerrariCacheKey, out ICollection<FerrariEntity> dictadorCached))
            {
                var dictadores = dictadorCached.FirstOrDefault(c => c.Id == id);
                if (dictadores != null)
                    return dictadores;
            }

            return await _context.Ferraris.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Ferraris.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(FerrariEntity ferrari)
        {
            _context.Ferraris.Add(ferrari);
            return await Save();
        }

        public async Task<bool> UpdateAsync(FerrariEntity ferrari)
        {
            _context.Update(ferrari);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await GetAsync(id);
            if (category == null)
                return false;

            _context.Ferraris.Remove(category);
            return await Save();
        }
    }
}
