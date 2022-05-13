using Microsoft.EntityFrameworkCore;
using Szakdoga.Common.Dto;
using Szakdoga.Common.Mappers;
using Szakdoga.DataLayer.DAL;
using Szakdoga.DataLayer.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var filePath = Path.Combine(AppContext.BaseDirectory, "SubjectTree.xml");
    c.IncludeXmlComments(filePath, includeControllerXmlComments: true);
    c.UseAllOfForInheritance();
    

});
builder.Services.AddDbContext<ISzakdogaContext, SzakdogaContext>(options
    => options.UseLazyLoadingProxies()
              .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IMapper<Subject, SubjectDto>, SubjectMapper>();
builder.Services.AddSingleton<IMapper<Student, StudentDto>, StudentMapper>();
builder.Services.AddSingleton<IMapper<Syllabus, SyllabusDto>, SyllabusMapper>();
var app = builder.Build();

app.UseCors(options =>
                        options
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials()
                                .WithOrigins(builder.Configuration["appUrls"])
                                );


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Subject Tree V1");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
