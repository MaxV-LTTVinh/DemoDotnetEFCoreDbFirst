
- Scaffold by .NET CLI
```
dotnet ef dbcontext scaffold 'Name=ConnectionStrings:DefaultConnection'  Microsoft.EntityFrameworkCore.SqlServer --context-dir ./Entites/DbContexts --context DemoDbContext --output-dir Entities --data-annotations -f
```
- Scaffold by Visual Studio PMC
```
Scaffold-DbContext 'Name=ConnectionStrings:DefaultConnection'  Microsoft.EntityFrameworkCore.SqlServer -ContextDir ./Entities/DbContexts -Context DemoDbContext -OutputDir Entities -DataAnnotations -f
```