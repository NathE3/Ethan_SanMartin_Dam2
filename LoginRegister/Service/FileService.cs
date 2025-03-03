using LoginRegister.Interface;
using System.IO;
using System.Text.Json;

namespace LoginRegister.Services
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> Load(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            var content = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(content) ?? new List<T>();
        }

        public void Save(string filePath, IEnumerable<T> data)
        {
            var content = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, content);
        }
    }
}