using Microsoft.EntityFrameworkCore;
using Szakdoga.DataLayer.DAL;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.Model;
using Szakdoga.Common.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ISzakdogaContext, SzakdogaContext>(options
    => options.UseLazyLoadingProxies()
              .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IMapper<Subject, SubjectDto>, SubjectMapper>();
builder.Services.AddSingleton<IMapper<Student, StudentDto>, StudentMapper>();
builder.Services.AddSingleton<IMapper<Syllabus, SyllabusDto>, SyllabusMapper>();
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
