using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Route.MVCAPP.BLL.Common.Service.Attachments
{
    public interface IAttachmentService
    {
        #region Part 5 Attachment service 
        Task<string?> UploadAsync(IFormFile file, string folderName);
        bool Delete(string filePath); 
        #endregion
    }
}
