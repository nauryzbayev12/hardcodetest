using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Services.Interfaces
{
    public interface IUploadService
    {
        string GetImagePath(int id);
        Task<int> SaveImageAsync(IFormFile file);
       
    }
}
