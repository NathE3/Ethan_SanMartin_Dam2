using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Data;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string AutorCacheKey = "AutorCacheKey";
        private readonly int CacheExpirationTime = 3600;
        public AutorRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(AutorCacheKey);
        }

        public async Task<ICollection<AutorEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(AutorCacheKey, out ICollection<AutorEntity> categoriesCached))
                return categoriesCached;

            var categoriesFromDb = await _context.Autor.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(AutorCacheKey, categoriesFromDb, cacheEntryOptions);
            return categoriesFromDb;
        }

        public async Task<AutorEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(AutorCacheKey, out ICollection<AutorEntity> autorCached))
            {
                var autores = autorCached.FirstOrDefault(c => c.Id == id);
                if (autores != null)
                    return autores;
            }

            return await _context.Autor.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Autor.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(AutorEntity autor)
        {
            _context.Autor.Add(autor);
            return await Save();
        }

        public async Task<bool> UpdateAsync(AutorEntity autor)
        {
            _context.Update(autor);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await GetAsync(id);
            if (category == null)
                return false;

            _context.Autor.Remove(category);
            return await Save();
        }
    }
}

