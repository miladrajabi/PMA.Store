using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PMA.Store_EndPoints.FileSaver
{
    public class FileSaver
    {
        public string Save(IFormFile formFile, string path)
        {
            if (formFile == null || formFile.Length <= 0) return null;
            var fileExtension = Path.GetExtension(formFile.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            formFile.CopyTo(fileStream);
            return $"/{path}/{fileName}";
        }
    }
}
