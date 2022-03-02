using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace B_lotus.Function
{
    public class ImageUpload
    {
        public byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

        public string GetStrigFromByteArray(byte[] ImageByte) {
            string imageBase64Data = Convert.ToBase64String(ImageByte);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            return imageDataURL;
        }
    }
}
