using Microsoft.EntityFrameworkCore;
using Practica_1_P2.Domain.Context;
using Practica_1_P2.Domain.Repository;
using Practica_1_P2.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                                    builder => builder.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod()));

// Configuración de la base de datos
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("connecction")));
builder.Services.AddScoped<IProductoRepository, ProductoService>();
// Registro del repositorio (Asegúrate de que tienes una implementación de IPedidoRepository)
builder.Services.AddScoped<IPedidoRepository, PedidoService>(); // Cambia IPedidoRepository por la clase que implementa la interfaz
builder.Services.AddScoped<IUsuarioRepository, UsuarioService>();
builder.Services.AddScoped<IPedidoProdRepository, PedidoProductosService>();

// Configuración de controladores y JSON
builder.Services.AddControllers().AddNewtonsoftJson();

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de la aplicación
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
