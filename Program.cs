using Microsoft.EntityFrameworkCore;
using Practica_1_P2.Domain.Context;
using Practica_1_P2.Domain.Repository;
using Practica_1_P2.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de CORS
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                                    builder => builder.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod()));

// Configuraci�n de la base de datos
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("connecction")));
builder.Services.AddScoped<IProductoRepository, ProductoService>();
// Registro del repositorio (Aseg�rate de que tienes una implementaci�n de IPedidoRepository)
builder.Services.AddScoped<IPedidoRepository, PedidoService>(); // Cambia IPedidoRepository por la clase que implementa la interfaz
builder.Services.AddScoped<IUsuarioRepository, UsuarioService>();
builder.Services.AddScoped<IPedidoProdRepository, PedidoProductosService>();

// Configuraci�n de controladores y JSON
builder.Services.AddControllers().AddNewtonsoftJson();

// Configuraci�n de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de la aplicaci�n
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowWebapp");
app.MapControllers();

app.Run();
