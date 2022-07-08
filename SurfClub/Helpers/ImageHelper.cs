namespace SurfClub.Helpers
{
    public class ImageHelper
    {
        public async Task<Guid?> UploadImage(IFormFile photo)
        {
            Guid? result = null;
            if (photo != null)
            {
                result = Guid.NewGuid();
                var fileName = $"{result}.jpg";

                var filePath = Path.Combine("wwwroot/images/Uploads", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileSteam);
                }
            }
            return result;

        }
        public static string GetUrl(Guid? guid)
        {
            if (!guid.HasValue || guid.Value == Guid.Empty)
            {
                return null;
            }
            return string.Format("~/images/Uploads/{0}.jpg", guid);
        }

    }
}
