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
