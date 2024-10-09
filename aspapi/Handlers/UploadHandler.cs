namespace aspapi.Handlers
{
    public class UploadHandler
    {
        public string Upload(IFormFile file) {
            //extension
            List<string> validExtensions = new List<string>() {".jpg", ".png", ".gif", ".webp"};
            string extension = Path.GetExtension(file.FileName);
            if (!validExtensions.Contains(extension)) {
                return $"Extension is not valid ({string.Join(',',validExtensions)})";
            }

            //file size
            long size = file.Length;
            if(size > (5 * 1024 * 1024))
                return "Maximum size can be 5mb";

            //name changing
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }
    }
}