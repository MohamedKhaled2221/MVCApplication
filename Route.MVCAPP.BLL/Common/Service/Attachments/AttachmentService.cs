using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Route.MVCAPP.BLL.Common.Service.Attachments
{
    public class AttachmentService : IAttachmentService
    {
        #region Part 5 Attachment service 
        // Allowed file extensions
        public readonly List<string> AllowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
        // Maximum file size in bytes (e.g., 5 MB)
        public const int _allowedSize = 2_097_152; // 5 MB
        public string? Upload(IFormFile file, string folderName)
        {
            // 1 - Validate file extension
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(extension))
                return null; // Invalid file extension
            // 2 - Validate file size
            if (file.Length > _allowedSize)
                return null; // File size exceeds the limit
                             // 3 - Get Foler Path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            // 4 - Create unique file name
            var FileName = $"{Guid.NewGuid()}{extension}";
            //5 - Get File Path [FolderPath + FileName]
            var filePath = Path.Combine(folderPath, FileName); // File Location
                                                               //6 - Save File As Stream [Data Per Time]
            using var filestream = new FileStream(filePath, FileMode.Create);
            // 7 - Copy File To FileStream
            file.CopyTo(filestream);
            // 8 - Return File Name
            return FileName;

        }
        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        } 
        #endregion


    }
}
