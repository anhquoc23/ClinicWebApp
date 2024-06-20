using CloudinaryDotNet.Actions;

namespace ClinicWebAPI.Interfaces
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadPhotoToCloudinaryAsync(IFormFile image);
    }
}
