using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public class UploadImageTool
    {
        public static string Upload(IFormFile imageFile, string serverPath)
        {
            if (imageFile.FileName != "no-product.png")
            {
                string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).ToArray()).Replace(' ', '-');
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
                var folderPath = Path.Combine("Uploads", "images");
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), folderPath, imageName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                var imageSrc = Path.Combine(serverPath, folderPath, imageName);

                return imageSrc;
            }

            return null;
        }
    }
}
