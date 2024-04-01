using System.Text.RegularExpressions;

namespace PizzeriaApi.Services;
public class ImageService 
{
    public async Task<string> SaveImageAsync(string image)
    {
        if (image.Length == 0)
            return "";

        var filename = $"{Guid.NewGuid()}.jpg";
        var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(image, "");
        var bytes = Convert.FromBase64String(data);

        var path = $"wwwroot/images/{filename}";
        await System.IO.File.WriteAllBytesAsync(path,bytes);

        return path;
    }



    public void DeleteImage(string path) {
        System.IO.File.Delete(path);
    }
}

