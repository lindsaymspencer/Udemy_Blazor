using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiddenVilla_Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace HiddenVilla_Server.Service
{
    public class FileUpload :IFileUpload
    {
        public Task<string> UploadFile(IBrowserFile file)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFIle(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
