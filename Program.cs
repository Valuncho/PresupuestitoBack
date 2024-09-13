using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DataAccess;
using PresupuestitoBack.Services;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepository;
using PresupuestitoBack;

var builder = WebApplication.CreateBuilder(args);

var AllowSpecificOrigins = "";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Aca vamos a tener que agregar los servicios y los repositorios, hasta no encontrar una forma mas efectica
// hay que cargarlos manualmente
builder.Services.AddScoped<BudgetService>();
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>(); 

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(AllowSpecificOrigins);
app.MapControllers();

app.Run();
