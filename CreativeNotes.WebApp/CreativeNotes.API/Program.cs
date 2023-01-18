using CreativeNotes.API.Infrastructure.Extensions;
using CreativeNotes.Bll;
using CreativeNotes.Bll.Interfaces;
using CreativeNotes.Bll.Services;
using CreativeNotes.Dal;
using CreativeNotes.Dal.Interfaces;
using CreativeNotes.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddAutoMapper(typeof(BllAssemblyMarker));

builder.Services.AddDbContext<CreativeNotesDbContext>(optionBuilder =>
{
    optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("CreativeNotesConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandling();

app.UseRouting();

app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
