# az-204-storage
See https://learn.microsoft.com/en-us/training/modules/work-azure-blob-storage/4-develop-blob-storage-dotnet for walkthrough.

## Pre-requisites:
- An Azure account with an active subscription. If you don't already have one, you can sign up for a free trial at [https://azure.com/free](https://azure.com/free).
- [Visual Studio Code](https://code.visualstudio.com/) on one of the supported platforms.
- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) is the target framework.
- The [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code.
- Optional: [GitHub Copilot](https://github.com/features/copilot) and Copilot VS extension (install from Extensions Marketplace within Code)

## Walkthrough Steps:
Create a storage account resource in Azure:
1. Open a new Terminal Window in VS Code
2. Login to Azure using `az login`
3. Create a resource group needed in a specific region: `az group create --location \<myLocation\> --name az204-blob-rg`
4. Create a storage account with a unique name `az storage account create --resource-group az204-blob-rg --name \<myStorageAcct\> --location \<myLocation\> --sku Standard_LRS`
5. Get the credentials for the new storage account from the Azure portal

Development:
1. Set the environment variable **AZ204_STORAGE_CONNECTIONSTRING** to credentials from the previous section in a terminal window for this modified version to set the connection string: `$env:AZ204_STORAGE_CONNECTIONSTRING="\<myConnectionString\>"`
1. Prepare a .NET project: `dotnet new console -n az204-blob`
1. Change directory to **az204-blob** and build: `cd az204-blob && dotnet build`
1. Create a data folder for uploading and downloading to the storage account: `mkdir data`
1. While in the az204-blob folder, add the following package: `dotnet add package Azure.Storage.Blobs`
1. Create the **Program.cs** file according to the MS Learn, or GitHub Copilot to follow along.
1. Create a .gitignore file by running `dotnet new gitignore` in the working folder
1. Publish to GitHub

## Running the Application
Run the console application by first building it from the application folder: `dotnet build && dotnet run. Don't forget to open storage in the portal and set any RBAC controls to Reader to view the application as it progresses through:
- creating a container
- adding a file to the storage container
- downloading and renaming the file from the container
- cleanup of local files and container

Don't forget you can delete the resource group once you're finished learning.

## Sample output:
```
PS C:\SRC\az-204-storage> dotnet run
Azure Blob Storage exercise

Created container quickstartblobs4b60d4c4-53ea-46c9-8eb1-459c9cfaca85
Press enter to continue

Uploading to Blob storage as blob:
         https://myStorageAccount.blob.core.windows.net/quickstartblobs4b60d4c4-53ea-46c9-8eb1-459c9cfaca85/quickstartaddffe0e-7c1b-4c8e-ba0f-209d88821711.txt

Properties for container https://myStorageAccount.blob.core.windows.net/quickstartblobs4b60d4c4-53ea-46c9-8eb1-459c9cfaca85
Public access level: None
Last modified time in UTC: 9/10/2023 12:16:47 AM +00:00
Press enter to continue

Listing blobs...
        quickstartaddffe0e-7c1b-4c8e-ba0f-209d88821711.txt
Press enter to continue


Downloading blob to
        ./data/quickstartaddffe0e-7c1b-4c8e-ba0f-209d88821711DOWNLOAD.txt

Press enter to continue

Press enter to delete the blobs and example container

Deleting blob container...
Deleting the local source and downloaded files...
Press enter to exit the sample application.

PS C:\SRC\az-204-storage>
```