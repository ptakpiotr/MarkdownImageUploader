using Azure.Storage.Blobs;
using MarkdownFileUploaderConsole;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        //I am storing sensitive information like azure blob storage connection string in plain-text appsettings.json if you want more security consider using Azure Key Vault
        //Remember to change all placeholders for valid values, otherwise this console app will not work

        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
        string containerName = configuration["ContainerName"].ToString();


        BlobServiceClient blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("AzureBlob"));
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        string wholeText = File.ReadAllText("<YOUR-FILE-PATH>");

        ImageUploader img = new(containerClient);
        await img.SaveToBlobAsync(wholeText);
    }
}