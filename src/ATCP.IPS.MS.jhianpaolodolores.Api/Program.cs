using ATCP.IPS.MS.jhianpaolodolores.Core.Exceptions;
using ATCP.IPS.MS.jhianpaolodolores.Core.Service.Contracts;
using ATCP.IPS.MS.jhianpaolodolores.Core.Service.Implementation;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Contract;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Implementation;
using ATCP.IPS.MS.jhianpaolodolores.Repository.Mapper;
using ATCP.IPS.MS.jhianpaolodolores.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ATCP.IPS.MS.jhianpaolodolores.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(builder.Configuration["AppDbConnectionString"]));
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerAdoNetRepository>(r => 
                new CustomerAdoNetRepository(builder.Configuration.GetConnectionString("AppDbConnectionString")));
            builder.Services.AddScoped<ICustomerAdoNetService, CustomerAdoNetService>();
            builder.Services.AddScoped<ICustomerMapper, CustomerMapper>();
            builder.Services.AddScoped<IAppDbContext, AppDbContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else 
            {
                app.UseMiddleware<ExceptionHandler>();
            }
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true));

            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            { 
            
            app.MapControllers();

            } );

            app.Run();
        }

    }
}