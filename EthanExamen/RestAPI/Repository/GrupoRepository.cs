using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class GrupoRepository :IGrupoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string GrupoCacheKey = "GrupoCacheKey";
        private readonly int CacheExpirationTime = 3600;
        public GrupoRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(GrupoCacheKey);
        }

        public async Task<ICollection<GrupoEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(GrupoCacheKey, out ICollection<GrupoEntity> categoriesCached))
                return categoriesCached;

            var categoriesFromDb = await _context.Grupo.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(GrupoCacheKey, categoriesFromDb, cacheEntryOptions);
            return categoriesFromDb;
        }

        public async Task<GrupoEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(GrupoCacheKey, out ICollection<GrupoEntity> autorCached))
            {
                var autores = autorCached.FirstOrDefault(c => c.Id == id);
                if (autores != null)
                    return autores;
            }

            return await _context.Grupo.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Autor.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(GrupoEntity grupo)
        {
            _context.Grupo.Add(grupo);
            return await Save();
        }

        public async Task<bool> UpdateAsync(GrupoEntity grupo)
        {
            _context.Update(grupo);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await GetAsync(id);
            if (category == null)
                return false;

            _context.Grupo.Remove(category);
            return await Save();
        }
    }
}

