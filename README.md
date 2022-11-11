#Proyecto LP3 Blazor Server
#GUÍA A SEGUIR
1- Para iniciar la conexión a base de datos debe realizar la siguiente configuración:
1.1 Agregar en el archivo "*.csproj" (es el archivo de la solución de Visual Studio) los paquetes necesarios para trabajar con Entity Framework (EF) están delimitados en el segmento siguiente (COPIAR): 
  <ItemGroup>
  		<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.7" />
		  <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.7" />
		  <PackageReference Include="System.Net.Http.Json" Version="6.0.0" />
  </ItemGroup>
  Luego debe pegarlo después de: </PropertyGroup> en el "*.csproj".
1.2 Ejecutar en la terminar: dotnet restore
1.3 Crear un archivo llamado "MyDbContext.cs" en la ruta: "Data/Context/" en su proyecto.
1.3.1 Heredar de la clase DbContext de EF "MyDbContext:DbContext" .
1.3.2 Declarar los DbSet de cada modelo a utilizar en la base de datos ej.: 
´´
    public virtual DbSet<Producto> Productos {get; set;} = null!;
´´
1.3.3 Crear una interface "IMyDbContext".

2. Configurar la ruta de su base de datos SQLite en la clase "Program.cs":
´´
builder.Services.AddSqlite<MyDbContext>("Data Source=.//Data//Context//MyDb.sqlite");
´´
3. Registrar la interfaz(IMyDbContext) y la clase (MyDbContext) en la clase "Program.cs" como un Scoope:
´´
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
´´
4. Registrar la migración para la creación de la base de datos en la clase "Program.cs"
´´
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LP3DbContext>();
    if (db.Database.EnsureCreated())
    {
        
    }
}
´´

Si todo esta bien, solo faltaría ejecutar: dotnet watch y comprobar que se cree la base de datos en la ruta: //Data//Context//
