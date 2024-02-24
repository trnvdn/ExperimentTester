using AutoMapper;
using ExperimentTester;
using ExperimentTester.DatabaseContext;
using ExperimentTester.Repositories.IRepositories;
using ExperimentTester.Repositories;
using Microsoft.EntityFrameworkCore;
using ExperimentTester.Services;
using ExperimentTester.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});


// AutoMapper configuration
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

// Repositories registration
builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddScoped<IExperimentRepository, ExperimentRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IAssociationRepository, AssociationRepository>();
builder.Services.AddScoped<IExperimentService, ExperimentService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IAssociationService, AssociationService>();
builder.Services.AddScoped<IExperimentHandlerService, ExperimentHandlerService>();
builder.Services.AddScoped<IExperimentsDetailsService, ExperimentsDetailsService>();

builder.Services.AddLogging();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Experiment/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=experiment}/{action=Index}/{id?}");

app.Run();
