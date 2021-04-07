using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImageUpload
{
  public  class UploadImagesPath
    {

        public static async Task<string> CarImgSave(IFormFile imageFile)
        {
            var getextension = Path.GetExtension(imageFile.FileName).ToLower();
            var ImageName = DateTime.Now.ToString("sdsadsa") + new Guid() + getextension;

            var imagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + PathName.AddCarImage, ImageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            string imagePathAndName = PathName.CarImages + "\\" + ImageName;

            return imagePathAndName;

        }
    }
}
