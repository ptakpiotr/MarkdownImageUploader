using Azure.Storage.Blobs;
using System.Text.RegularExpressions;

namespace MarkdownFileUploaderConsole
{
    internal class ImageUploader
    {
        private readonly string regExp = @"\!\[.*\]\(.*(.jpg|.png)\)";
        private readonly BlobContainerClient _client;

        public ImageUploader(BlobContainerClient client)
        {
            _client = client;
        }

        private async Task UploadFileAsync(string path)
        {
            if (File.Exists(path))
            {
                string exts = Path.GetExtension(path);
                string randomName = Guid.NewGuid().ToString();
                string newName = $"{randomName}{exts}";
                using(var stream = File.OpenRead(path))
                {
                    await _client.UploadBlobAsync(newName, stream);
                }
            }

        }

        public async Task SaveToBlobAsync(string txt)
        {
            List<string> strings = txt.Split("\\n").ToList();
            try {
                foreach (var str in strings)
                {
                    foreach (var matched in Regex.Matches(str, regExp))
                    {
                        string mt = matched.ToString();
                        if (!string.IsNullOrEmpty(mt))
                        {
                            mt = mt.Substring(mt.IndexOf("(") + 1);
                            mt = mt.TrimEnd(')');
                            await UploadFileAsync(mt);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
