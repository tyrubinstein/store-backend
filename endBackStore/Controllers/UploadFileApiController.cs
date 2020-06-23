using BLL;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
namespace endBackStore.Controllers
{
 
    public class UploadFileApiController : ApiController
    {


        //[HttpPost]
        //public async Task Upload(IFormFile file)
        //{
        //    FileService FileService = new FileService();
        //    if (file == null) throw new Exception("File is null");
        //    if (file.Length == 0) throw new Exception("File is empty");

        //    using (Stream stream = file.OpenReadStream())
        //    {
        //        using (var binaryReader = new BinaryReader(stream))
        //        {
        //            var fileContent = binaryReader.ReadBytes((int)file.Length);
        //           await FileService.addFile(fileContent, file.FileName, file.ContentType);
        //        }
        //    }
        //}




    }
}
