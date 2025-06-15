
using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection;
using TrialDay.Core.Abstraction;
using TrialDay.Core.UnitOfWork;
using TrialDay.Profiles;
using TrialDay.Repo.Context;
using TrialDay.Repo.Repo;
using TrialDay.Repo.UNitOfWork;
using TrialDay.Services.IServices.ClassService;
using TrialDay.Services.IServices.EnrollmentService;
using TrialDay.Services.IServices.MarkService;
using TrialDay.Services.IServices.StudentService;

namespace TrialDay
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<SchoolContext>(Options => 
            Options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));
            builder.Services.AddFastEndpoints();
            builder.Services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UNitOfWork));
            builder.Services.AddAutoMapper(typeof(Profile).Assembly);
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IClassService, ClassServices>();
            builder.Services.AddScoped<IEnrollmentService,EnrollStudentService>();
            builder.Services.AddScoped<IMarksService, MarkService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseFastEndpoints();


            //UpdateDataBase
            var Scope = app.Services.CreateScope();
            var services = Scope.ServiceProvider;
            var logger = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbcontext = services.GetRequiredService<SchoolContext>();
                await dbcontext.Database.MigrateAsync();

            }
            catch (Exception ex)
            {

                var Logger = logger.CreateLogger<Program>();
                Logger.LogError(ex, "Error while Update Database");

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
        }
    }
}
