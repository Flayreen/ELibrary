using ELibrary.API.BLL.Services;
using ELibrary.API.Extensions;
using ELibrary.API.Core.Interfaces.Auth;
using ELibrary.API.Core.Interfaces.Repositories;
using ELibrary.API.Core.Interfaces.Services;
using ELibrary.API.DAl;
using ELibrary.API.DAL.Repositories;
using ELibrary.API.Infrastructure;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<ELibraryDbContext>();

services.AddScoped<IBookService, BooksService>();
services.AddScoped<IUsersService, UsersService>();

services.AddScoped<IBookRepository, BookRepository>();
services.AddScoped<IUsersRepository, UsersRepository>();

services.AddScoped<IJwtProvider, JwtProvider>();
services.AddScoped<IPasswordHasher, PasswordHasher>();

services.AddAutoMapper(typeof(DatabaseMappings));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.AddMappedEndpoints();

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
