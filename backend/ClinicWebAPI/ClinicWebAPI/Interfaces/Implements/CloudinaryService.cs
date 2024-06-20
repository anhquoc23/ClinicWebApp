using ClinicWebAPI.Settings;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace ClinicWebAPI.Interfaces.Implements
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySetting> options) 
        {
            Account account = new Account
            {
                Cloud = options.Value.CloudName,
                ApiKey = options.Value.ApiKey,
                ApiSecret = options.Value.ApiSecret,
            };
            _cloudinary = new Cloudinary(account);
        }
        public async Task<ImageUploadResult> UploadPhotoToCloudinaryAsync(IFormFile image)
        {
            var uploadResult = new ImageUploadResult();

            if (image.Length > 0)
            {
                using var stream = image.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(image.Name, stream),
                    Folder = CloudinarySetting.PathAvatar
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }
    }
}
