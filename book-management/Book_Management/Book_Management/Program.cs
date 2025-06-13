using Books.DataAccess;
using Books.DataAccess.Repositories;
using Books.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace Book_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            
            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

            // Add DbContext
            builder.Services.AddDbContext<BooksDbContext>(db => 
                db.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Services
            builder.Services.AddScoped<BooksService>();
            builder.Services.AddScoped<BooksRepository>();

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Use CORS
            app.UseCors("AllowAll");

            app.UseAuthorization();

            // Add static files support
            app.UseStaticFiles();

            // Add default page for root URL
            app.MapGet("/", () => Results.Content(@"
                <html>
                    <head>
                        <title>Book Management System</title>
                        <style>
                            body {
                                font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
                                margin: 0;
                                padding: 0;
                                background-color: #f5f5f5;
                                color: #333;
                            }
                            .container {
                                max-width: 1000px;
                                margin: 40px auto;
                                padding: 30px;
                                background-color: white;
                                border-radius: 10px;
                                box-shadow: 0 2px 10px rgba(0,0,0,0.1);
                            }
                            h1 {
                                color: #2c3e50;
                                margin-bottom: 20px;
                                text-align: center;
                            }
                            .description {
                                text-align: center;
                                margin-bottom: 30px;
                                color: #666;
                                line-height: 1.6;
                            }
                            .features {
                                display: grid;
                                grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
                                gap: 20px;
                                margin-bottom: 30px;
                            }
                            .feature-card {
                                background-color: #f8f9fa;
                                padding: 20px;
                                border-radius: 8px;
                                border-left: 4px solid #3498db;
                            }
                            .feature-card h3 {
                                color: #2c3e50;
                                margin-top: 0;
                            }
                            .links {
                                text-align: center;
                                margin-top: 30px;
                            }
                            .links a {
                                display: inline-block;
                                margin: 0 10px;
                                padding: 12px 24px;
                                background-color: #3498db;
                                color: white;
                                text-decoration: none;
                                border-radius: 5px;
                                transition: background-color 0.3s;
                            }
                            .links a:hover {
                                background-color: #2980b9;
                            }
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <h1>Welcome to Book Management System</h1>
                            <p class='description'>
                                A modern and efficient system for managing your book collection. 
                                Track books, manage inventory, and keep your library organized.
                            </p>
                            <div class='features'>
                                <div class='feature-card'>
                                    <h3>Book Management</h3>
                                    <p>Add, update, and remove books from your collection with ease.</p>
                                </div>
                                <div class='feature-card'>
                                    <h3>Inventory Tracking</h3>
                                    <p>Keep track of book availability and manage your inventory.</p>
                                </div>
                                <div class='feature-card'>
                                    <h3>Detailed Information</h3>
                                    <p>Store comprehensive book details including ISBN, price, and more.</p>
                                </div>
                            </div>
                            <div class='links'>
                                <a href='/swagger'>API Documentation</a>
                                <a href='/api/books'>View Books</a>
                            </div>
                        </div>
                    </body>
                </html>", "text/html"));

            app.MapControllers();

            app.Run();
        }
    }
}
