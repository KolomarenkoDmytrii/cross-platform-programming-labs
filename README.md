# Cross Platform Programming Labs

Laboratory works on subject Cross Platform Programming by Kolomarenko Dmytrii,
IPZ-34ms, variant 31.

## Notes
### Create new project
```
dotnet new sln -o LabN
cd LabN
dotnet new console -o LabN.App
dotnet new nunit -o LabN.Test
dotnet sln ./LabN.sln add ./LabN.Test/LabN.Test.csproj
cd LabN.Test
dotnet add reference ../LabN.App/LabN.App.csproj

```

### MSBuild commands
Build a selected project: `dotnet build Build.proj -p:Solution=Lab1 -t:Run`

Run a selected project: `dotnet build Build.proj -p:Solution=Lab1 -t:Build`

Run test for a selected project: `dotnet build Build.proj -p:Solution=Lab1 -t:Test`

### Lab3
Lab3.Lib/Lab3.Lib.csproj:
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <PackageId>DKolomarenko</PackageId>
    <Version>1.0.0</Version>
    <Authors>Dmytrii Kolomarenko</Authors>
  </PropertyGroup>

</Project>
```

```
dotnet new sln -o Lab3
cd Lab3

dotnet new classlib -o Lab3.Lib
dotnet pack Lab3.Lib/Lab3.Lib.csproj -o packages
mkdir ~/.nuget/NuGet/packages
dotnet nuget push packages/DKolomarenko.1.0.0.nupkg" -s ~/.nuget/NuGet/packages

dotnet new console -o Lab3.App
cd Lab3.App
dotnet add package DKolomarenko

cd ..
dotnet new nunit -o Lab3.Test
dotnet sln ./Lab3.sln add ./Lab3.Test/Lab3.Test.csproj
#dotnet add ./Lab3.Test/Lab3.Test.csproj reference DKolomarenko
dotnet add ./Lab3.Test/Lab3.Test.csproj reference ./Lab3.Lib/Lab3.Lib.csproj
dotnet add ./Lab3.Test/Lab3.Test.csproj reference ./Lab3.App/Lab3.App.csproj
```

Update package:
1. Update `<Version>a.b.c+1</Version>`
2. `dotnet pack Lab3.Lib/Lab3.Lib.csproj -o packages`
2. `dotnet nuget push packages/DKolomarenko.a.b.c+1.nupkg -s ~/.nuget/NuGet/packages`


### Lab4
Run lab (example): `dotnet run -- run lab3 -I INPUT.TXT -o OUTPUT.TXT`.

How to create a dotnet tool package:
- https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-create
How to install a dotnet tool package localy:
- https://learn.microsoft.com/en-us/dotnet/core/tools/local-tools-how-to-use
- `dotnet tool install --add-source ./Lab4/nupkg/ DKolomarenko` (Build the project first)

#### Vagrant
Setting up Vagrant to work with VirtualBox 7.1.x: https://github.com/hashicorp/vagrant/issues/13501#issuecomment-2352562190

Move to Lab4 directory and run `vagrant up <vm_name>` or `vagrant provision <vm_name>`, 
if virtual machine already running, and `<vm_name>` stands for ubuntu for the ubuntu vm,
windows for the windows vm.


### Lab6
Install Entity Framework CLI: https://learn.microsoft.com/en-us/ef/core/cli/dotnet

https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli

https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx

`dotnet ef migrations add MigrationName`

`dotnet ef database update`
