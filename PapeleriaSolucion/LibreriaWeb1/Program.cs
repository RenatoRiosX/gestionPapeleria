using AccesoDatos.RepositorioEF;
using LogicaAplicacion.ImplementacionCasosUsos.Articulos;
using LogicaAplicacion.ImplementacionCasosUsos.Usuarios;
using LogicaAplicacion.ImplementacionCasosUsos.Clientes;
using LogicaAplicacion.ImplementacionCasosUsos.Pedidos;
using LogicaAplicacion.InterfacesCasosUsos.Articulos;
using LogicaAplicacion.InterfacesCasosUsos.Clientes;
using LogicaAplicacion.InterfacesCasosUsos.Pedidos;
using LogicaAplicacion.InterfacesCasosUsos.Usuarios;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();



//Se inyecta el repositorio en el controlador
builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulosEF>();
builder.Services.AddScoped<IRepositorioClientes, RepositorioClientesEF>();
builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidosEF>();
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosEF>();

//Casos de uso 
//Ej: builder.Services.AddScoped<ICrearAdministrador, CrearAdministradorCU>(); CU hace referencia a Caso de Uso
builder.Services.AddScoped<ILogin, Login>();
builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
builder.Services.AddScoped<IAltaArticulo, AltaArticulo>();
builder.Services.AddScoped<IBajaUsuario, BajaUsuario>();
builder.Services.AddScoped<IEditarUsuario, EditarUsuario>();
builder.Services.AddScoped<IBuscarClientePorRazonSocial, BuscarClientePorRazonSocial>();
builder.Services.AddScoped<IBuscarClientePorMonto, BuscarClientePorMonto>();
builder.Services.AddScoped<IGetClienteById, GetClienteById>();
builder.Services.AddScoped<IGetAllArticulos, GetAllArticulos>();
builder.Services.AddScoped<IGetAllClientes, GetAllClientes>();
builder.Services.AddScoped<IGetAllPedidos, GetAllPedidos>();
builder.Services.AddScoped<IGetPedidosPorFecha, GetPedidosPorFecha>();
builder.Services.AddScoped<IAnularPedido, AnularPedido>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
