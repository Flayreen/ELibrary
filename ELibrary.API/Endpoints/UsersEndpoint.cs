using ELibrary.API.Contracts.Users;
using ELibrary.API.Core.Interfaces.Services;

namespace ELibrary.API.Endpoints;

public static class UsersEndpoint
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        
        app.MapPost("login", Login);

        return app;
    }

    private static async Task<IResult> Register(
        RegisterUserRequest request, 
        IUsersService usersService)
    {
        await usersService.Register(request.Name, request.Login, request.Password);
        
        return Results.Ok();
    }

    private static async Task<IResult> Login(
        LoginUserRequest request,
        IUsersService usersService,
        HttpContext context)
    {
        var token = await usersService.Login(request.Login, request.Password);

        context.Response.Cookies.Append("tasty-cookie", token);
        
        return Results.Ok();
    }
}