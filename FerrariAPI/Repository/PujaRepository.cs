using FerrariAPI.Data;
using FerrariAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using FerrariAPI.Models.Entity;
using System.Diagnostics;

namespace FerrariAPI.Repository
{
    public class PujaRepository : IPujaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string PujaCacheKey = "PujaCacheKey";
        private readonly int CacheExpirationTime = 3600;
        public PujaRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(PujaCacheKey);
        }

        public async Task<ICollection<PujaEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(PujaCacheKey, out ICollection<PujaEntity> pujaCached))
                return pujaCached;

            var pujasFromDb = await _context.Pujas.OrderBy(c => c.Id).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(PujaCacheKey, pujasFromDb, cacheEntryOptions);
            return pujasFromDb;
        }

        public async Task<PujaEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(PujaCacheKey, out ICollection<PujaEntity> pujaCached))
            {
                var pujas = pujaCached.FirstOrDefault(c => c.Id == id);
                if (pujas != null)
                    return pujas;
            }

            return await _context.Pujas.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Ferraris.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(PujaEntity puja)
        {
            _context.Pujas.Add(puja);
            return await Save();
        }

        public async Task<bool> UpdateAsync(PujaEntity ferrari)
        {
            _context.Update(ferrari);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var puja = await GetAsync(id);
            if (puja == null)
                return false;

            _context.Pujas.Remove(puja);
            return await Save();
        }
    }
}
