using RestAPI.Data;
using RestAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Models.Entity;
using System.Diagnostics;

namespace RestAPI.Repository
{
    public class DictadorRepository : IDictadorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string DictadorCacheKey = "DictadorCacheKey";
        private readonly int CacheExpirationTime = 3600;
        public DictadorRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
            {
                ClearDictadorCache();
            }
            return result;
        }

        public void ClearDictadorCache()
        {
            _cache.Remove(DictadorCacheKey);
        }

        public async Task<ICollection<DicatadorEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(DictadorCacheKey, out ICollection<DicatadorEntity> categoriesCached))
                return categoriesCached;

            var categoriesFromDb = await _context.Dictadors.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(DictadorCacheKey, categoriesFromDb, cacheEntryOptions);
            return categoriesFromDb;
        }

        public async Task<DicatadorEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(DictadorCacheKey, out ICollection<DicatadorEntity> dictadorCached))
            {
                var dictadores = dictadorCached.FirstOrDefault(c => c.Id == id);
                if (dictadores != null)
                    return dictadores;
            }

            return await _context.Dictadors.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Dictadors.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(DicatadorEntity dictador)
        {
            _context.Dictadors.Add(dictador);
            return await Save();
        }

        public async Task<bool> UpdateAsync(DicatadorEntity dictador)
        {
            _context.Update(dictador);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await GetAsync(id);
            if (category == null)
                return false;

            _context.Dictadors.Remove(category);
            return await Save();
        }
    }
}
