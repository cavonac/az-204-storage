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
2. Login to Azure using <code>az login</code>
3. Create a resource group needed in a specific region: <code>az group create --location \<myLocation\> --name az204-blob-rg</code>
4. Create a storage account with a unique name <code>az storage account create --resource-group az204-blob-rg --name \<myStorageAcct\> --location \<myLocation\> --sku Standard_LRS</code>
5. Get the credentials for the new storage account from the Azure portal

Development:
1. Set the environment variable **AZ204_STORAGE_CONNECTIONSTRING** to your connection string in a terminal window for this modified version: <code>$env:AZ204_STORAGE_CONNECTIONSTRING="\<myConnectionString\>"</code>
1. Prepare a .NET project: <code>dotnet new console -n az204-blob</code>
1. Change directory to **az204-blob** and build: <code>cd az204-blob && dotnet build</code>
1. Create a data folder for uploading and downloading to the storage account: <code>mkdir data</code>
1. While in the az204-blob folder, add the following package: <code>dotnet add package Azure.Storage.Blobs</code>
1. Create the **Program.cs** file according to the MS Learn, or GitHub Copilot to follow along.
1. Create a .gitignore file by running <code>dotnet new gitignore</code> in the working folder
1. Publish to GitHub

## Running the Application
Run the console application by first building it from the application folder: <code>dotnet build && dotnet run</code>. Don't forget to open storage in the portal and set any RBAC controls to Reader to view the application as it progresses through:
- creating a container
- adding a file to the storage container
- downloading and renaming the file from the container
- cleanup of local files and container

Don't forget you can delete the resource group once you're finished learning.
