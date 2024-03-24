If not already installed, install SQL Server 2022 Express: https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x409&culture=en-us&country=us

Clone the repository in Visual Studio 2022

In NuGet Packet Manager Console, navigate to ...\GiphyAPI\GiphyAPI

Run the following commands to update the database

dotnet tool install --global dotnet-ef

dotnet ef database update

Run the project
