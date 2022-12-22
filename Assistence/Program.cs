using DBAssistance;
using DBAssistance.BussinesLayer.Repositories.PeriodRepository;
using DBAssistance.BussinesLayer.Repositories.CourseRepository;
using DBAssistance.BussinesLayer.Repositories.StudentRepository;

using DBAssistance.BussinesLayer.Services.PeriodService;
using DBAssistance.BussinesLayer.Services.CourseService;


using Microsoft.EntityFrameworkCore;
using DBAssistance.BussinesLayer.Services.StudentService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBAssistenceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AssistenceConnectionString"));
});

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IPeriodRepository, PeriodRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


builder.Services.AddScoped<IPeriodService, PeriodService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DBAssistenceContext>();  
    context.Database.Migrate();
}

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
