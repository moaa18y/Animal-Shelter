
using Microsoft.Extensions.Hosting;
using AnimalShelter.src.Shared.DbLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AnimalShelter.src.Repositories.Interfaces;
using AnimalShelter.src.Repositories.Implementations;
using AnimalShelter.src.Services.Interfaces;
using AnimalShelter.src.Services.Implementation;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();

builder.Services.AddDbContext<AppDBContext>(options =>
   options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAdoptionRepo, AdoptionRepo>();
builder.Services.AddScoped<IVaccineRepo, VaccineRepo>();
builder.Services.AddScoped<ICareNoteRepo, CareNoteRepo>();
builder.Services.AddScoped<IAnimalRepository, AnimalManager>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdoptionService, Adoptionservice>();
builder.Services.AddScoped<IVaccineService, VaccineService>();
builder.Services.AddScoped<ICareNoteService, CareNoteService>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IAuthoService, AuthoServices>();

builder.Services.AddTransient<AnimalsController>();
builder.Services.AddTransient<UsersController>();
builder.Services.AddTransient<AuthorizationController>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
   var controller = scope.ServiceProvider.GetRequiredService<AuthorizationController>();
   controller.Run();
}


