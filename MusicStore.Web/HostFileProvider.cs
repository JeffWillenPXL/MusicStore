using Microsoft.AspNetCore.Hosting;
using System.IO;
using MusicStore.Web.Services;

namespace MusicStore.Web
{
    public class HostFileProvider : IFileProvider
    {
        private readonly IWebHostEnvironment _environment;

        public HostFileProvider(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public byte[] GetFileBytes(string relativePath)
        {
            var fullPath = Path.Combine(_environment.ContentRootPath, relativePath);
            return File.ReadAllBytes(fullPath);
        }
    }
}
