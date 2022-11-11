#Proyecto LP3 Blazor Server
#GUÍA A SEGUIR
<br/>
1- Para iniciar la conexión a base de datos debe realizar la siguiente configuración:<br/>
1.1 Agregar en el archivo "*.csproj" (es el archivo de la solución de Visual Studio) los paquetes necesarios para trabajar con Entity Framework (EF) están delimitados en el segmento siguiente (COPIAR): 
<br/>

DESCARGAR EL PROYECTO PARA VER EL CÓDIGO QUE DEBERÍA APARECER AQUÍ....
<br/>
 <ItemGroup>
  		<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.7" />
		  <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.7" />
		  <PackageReference Include="System.Net.Http.Json" Version="6.0.0" />
  </ItemGroup>
  <br/>
  Luego debe pegarlo después de: </PropertyGroup> en el "*.csproj".
  <br/>
1.2 Ejecutar en la terminar: dotnet restore <br/>
1.3 Crear un archivo llamado "MyDbContext.cs" en la ruta: "Data/Context/" en su proyecto.<br/>
1.3.1 Heredar de la clase DbContext de EF "MyDbContext:DbContext" .<br/>
1.3.2 Declarar los DbSet de cada modelo a utilizar en la base de datos ej.: <br/>
´´
    public virtual DbSet<Producto> Productos {get; set;} = null!;
´´ <br/>
1.3.3 Crear una interface "IMyDbContext".<br/>

2. Configurar la ruta de su base de datos SQLite en la clase "Program.cs":<br/>
´´
builder.Services.AddSqlite<MyDbContext>("Data Source=.//Data//Context//MyDb.sqlite");
´´ <br/>
3. Registrar la interfaz(IMyDbContext) y la clase (MyDbContext) en la clase "Program.cs" como un Scoope:<br/>
´´
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
´´ <br/>
4. Registrar la migración para la creación de la base de datos en la clase "Program.cs"<br/>
´´
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    if (db.Database.EnsureCreated())
    {
        
    }
}
´´
<br/>
Si todo esta bien, solo faltaría ejecutar: dotnet watch y comprobar que se cree la base de datos en la ruta: //Data//Context//
