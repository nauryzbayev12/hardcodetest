using Catalog.Core.Services.Interfaces;
using Catalog.Data;
using Catalog.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Services.Implementation
{
    public class UploadService : IUploadService
    {
        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UploadService(DatabaseContext context, IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> SaveImageAsync(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var image = new Upload
            {
                FileName = fileName,
                FilePath = filePath
            };

            _context.Uploads.Add(image);
            await _context.SaveChangesAsync();

            return image.Id;
        }

        public string GetImagePath(int id)
        {
            var image = _context.Uploads.Find(id);
            if (image == null) return null;

            return image.FilePath;
        }

    }
}
