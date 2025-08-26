using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sigma.App.Extensions.Services
{
    public class FileSystemHelper 
    {
        public async Task<bool> CreateMainDirectory()
        {
            try
            {
                Directory.CreateDirectory(await GetMainDirectoryName());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetMainDirectoryName()
        {
            return Path.Combine("", "Sigma");
        }

        public async Task<List<string>> GetModelFileNamesAsync()
        {
            return Directory.GetFiles(await GetMainDirectoryName(), "*.gguf").ToList();
        }

        public async Task<bool> IsMainDirectoryExistsAsync()
        {
            return Directory.Exists(await GetMainDirectoryName());
        }
    }
}
