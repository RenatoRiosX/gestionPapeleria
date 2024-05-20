using AccesoDatos.RepositorioEF;
using LogicaAplicacion.ImplementacionCasosUsos.Articulos;
using LogicaAplicacion.ImplementacionCasosUsos.Clientes;
using LogicaAplicacion.ImplementacionCasosUsos.Pedidos;
using LogicaAplicacion.ImplementacionCasosUsos.Usuarios;
using LogicaAplicacion.InterfacesCasosUsos.Articulos;
using LogicaAplicacion.InterfacesCasosUsos.Clientes;
using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaAplicacion.InterfacesCasosUsos.Usuarios;
using LogicaNegocio.InterfacesRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Se inyecta el repositorio en el controlador
builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulosEF>();
builder.Services.AddScoped<IRepositorioClientes, RepositorioClientesEF>();


//Casos de uso 
builder.Services.AddScoped<IBuscarClientePorRazonSocial, BuscarClientePorRazonSocial>();
builder.Services.AddScoped<IMostrarArticulos, MostrarArticulos>();
builder.Services.AddScoped<IObtenerPedidosAnulados, ObtenerPedidosAnulados>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
