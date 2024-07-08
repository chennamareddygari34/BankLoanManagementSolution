
using BankLoanManagement.Contexts;
using BankLoanManagement.Interfaces;
using BankLoanManagement.Models;
using BankLoanManagement.Repositories;
using BankLoanManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();


            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("MyCors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            builder.Services.AddDbContext<BankLoanDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("MyCors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
