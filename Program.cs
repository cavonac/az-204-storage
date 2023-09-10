using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

// See https://learn.microsoft.com/en-us/training/modules/work-azure-blob-storage/4-develop-blob-storage-dotnet

Console.WriteLine("Azure Blob Storage exercise\n");

// Run the examples asynchronously, wait for the results before proceeding
ProcessAsync().GetAwaiter().GetResult();

Console.WriteLine("Press enter to exit the sample application.");
Console.ReadLine();

static async Task ProcessAsync()
{
    // Copy the connection string from the portal in the variable below.
    // string storageConnectionString = "CONNECTION STRING";
    string storageConnectionString = Environment.GetEnvironmentVariable("AZ204_STORAGE_CONNECTIONSTRING");
    if (string.IsNullOrEmpty(storageConnectionString))
    {
        Console.WriteLine("A connection string has not been defined in the system environment variables. " +
            "Add an environment variable named 'AZ204_STORAGE_CONNECTIONSTRING' with your storage " +
            "connection string as a value.");
        return;
    }

    // Create a client that can authenticate with a connection string
    BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);

    // COPY EXAMPLE CODE BELOW HERE

    // Create a unique name for the container
    string containerName = "quickstartblobs" + Guid.NewGuid().ToString();

    // Create the container and return a container client object
    BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
    Console.WriteLine("Created container {0}", containerName);
    Console.WriteLine("Press enter to continue");
    Console.ReadLine();

    // Create a local file in the ./data/ directory for uploading and downloading
    string localPath = "./data/";
    string fileName = "quickstart" + Guid.NewGuid().ToString() + ".txt";
    string localFilePath = Path.Combine(localPath, fileName);

    // Write text to the file
    await File.WriteAllTextAsync(localFilePath, "Hello, World!");

    // Get a reference to a blob
    BlobClient blobClient = containerClient.GetBlobClient(fileName);

    Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

    // Output container properties
    await Utils.ReadContainerPropertiesAsync(containerClient);

    // Open the file and upload its data
    using (FileStream uploadFileStream = File.OpenRead(localFilePath))
    {
        await blobClient.UploadAsync(uploadFileStream, true);
        uploadFileStream.Close();
    }

    Console.WriteLine("Press enter to continue");
    Console.ReadLine();

    // List all blobs in the container
    Console.WriteLine("Listing blobs...");

    await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
    {
        Console.WriteLine("\t" + blobItem.Name);
    }

    Console.WriteLine("Press enter to continue");
    Console.ReadLine();

    // Download the blob to a local file
    // Append the string "DOWNLOAD" before the .txt extension so you can see both files in the data directory
    string downloadFilePath = localFilePath.Replace(".txt", "DOWNLOAD.txt");

    Console.WriteLine("\nDownloading blob to\n\t{0}\n", downloadFilePath);

    // Download the blob's contents and save it to a file
    BlobDownloadInfo download = await blobClient.DownloadAsync();

    using (FileStream downloadFileStream = File.OpenWrite(downloadFilePath))
    {
        await download.Content.CopyToAsync(downloadFileStream);
        downloadFileStream.Close();
    }

    Console.WriteLine("Press enter to continue");
    Console.ReadLine();

    // Clean up
    Console.WriteLine("Press enter to delete the blobs and example container");
    Console.ReadLine();

    // Delete the blob
    Console.WriteLine("Deleting blob container...");
    await containerClient.DeleteAsync();

    // Delete the local files
    Console.WriteLine("Deleting the local source and downloaded files...");
    File.Delete(localFilePath);
    File.Delete(downloadFilePath);

    // END OF EXAMPLE CODE
}