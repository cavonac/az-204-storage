# az-204-storage
See https://learn.microsoft.com/en-us/training/modules/work-azure-blob-storage/4-develop-blob-storage-dotnet for walkthrough.

## Pre-requisites:
- An Azure account with an active subscription. If you don't already have one, you can sign up for a free trial at [https://azure.com/free](https://azure.com/free).
- [Visual Studio Code](https://code.visualstudio.com/) on one of the supported platforms.
- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) is the target framework.
- The [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code.
- Optional: [GitHub Copilot](https://github.com/features/copilot) and Copilot VS extension (install from Extensions Marketplace within Code)

## Walkthrough Steps:
1. Open a new Terminal Window in VS Code
2. Login to Azure using <code>az login</code>
3. Create a resource group needed in a specific region: <code>az group create --location \<myLocation\> --name az204-blob-rg</code>
4. Create a storage account with a unique name <code>az storage account create --resource-group az204-blob-rg --name \<myStorageAcct\> --location \<myLocation\> --sku Standard_LRS</code>
5. Get the credentials for the new storage account from the Azure portal
6. Set the environment variable **AZ204_STORAGE_CONNECTIONSTRING** to your connection string in a terminal window for this modified version: <code>$env:AZ204_STORAGE_CONNECTIONSTRING="\<myConnectionString\>"</code>
7. Prepare a .NET project: <code>dotnet new console -n az204-blob</code>
8. Change directory to **az204-blob** and build: <code>cd az204-blob && dotnet build</code>
9. Create a data folder for uploading and downloading to the storage account: <code>mkdir data</code>
10. While in the az204-blob folder, add the following package: <code>dotnet add package Azure.Storage.Blobs</code>
11. Create the **Program.cs** file according to the MS Learn, or GitHub Copilot to follow along.
12. Create a .gitignore file by running <code>dotnet new gitignore</code> in the working folder
13. Publish to GitHub
