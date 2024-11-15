using Autofac;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using Students.ExceptionHandling;
using Microsoft.AspNetCore.SpaServices.AngularCli;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<CourseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new Repositories.DependencyInjection());
    containerBuilder.RegisterModule(new Business.DependencyInjection());
});

var app = builder.Build();
app.UseExceptionHandleMiddleware();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSpaStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
        spa.Options.StartupTimeout = TimeSpan.FromSeconds(200);
    }
});

app.Run();
