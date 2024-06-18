using Arqtech.Data;
using Arqtech.Models;
using Arqtech.Repositorio;
using Arqtech.Servicos;
using Arqtech.Servicos.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("AppDhiego");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddScoped<LojaRepositorio>();
builder.Services.AddScoped<ProjetoRepositorio>();
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<MaterialRepositorio>();

builder.Services.AddScoped<ICriaRoleEUsuarioPadrao, CriaRoleEUsuarioPadrao>();

builder.Services.AddIdentity<UsuarioModel, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

CriarPerfisUsuarios(app);

void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ICriaRoleEUsuarioPadrao>();
        service.CriaRoles();
        service.CriaUsuarios();
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
