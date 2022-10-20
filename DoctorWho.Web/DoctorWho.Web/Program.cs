using EFCore;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DoctorWho.Db.Repositories;
using DoctrWho.Db.Interface;
using EfDoctorWho;
using DoctorWho.validation;
using DoctorWho.Db.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IDoctorRepository, DoctorssRepository>();
builder.Services.AddScoped<IEpisodRepository, EpisodRepositry>();
builder.Services.AddScoped<lAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IEnemyToEpisodeRepository, EnemytblEpisodRepositry>();
builder.Services.AddScoped<ICompanionToEpisodeRepository, CompanionEpisodRepositry>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DoctorWhoContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
   // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});
builder.Services.AddControllers().AddFluentValidation(fv => 
fv.RegisterValidatorsFromAssemblyContaining<EpisodValidator>());


builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
