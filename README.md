First Do
```
dotnet restore
```

<b>NOTE</b> You probably want to change TargetFramework from .Net 7 to .Net 6 in both projects. Unless you're cool and use .Net 7.

Hopefully the .csproj file will look like this
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net7.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Bogus" Version="34.0.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.0">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.0" />
  </ItemGroup>

</Project>
```

You need
- bogus
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design

Then add the migrations to the database
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Everytime you change your models you need to add a new migration and update the database through the CLI.