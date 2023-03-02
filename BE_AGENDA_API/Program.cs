using BE_AGENDA_API.Data;
using BE_AGENDA_API.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("ConsultaUsersApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ConsultaUsersApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definición
                }, new List<string>() }
    });
});

/* Inyeccion de dependencia Dbcontext para crear la database */
builder.Services.AddDbContext<AgendaApiContext>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:AgendaAPIDBConnectionString"]));

#region
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<ContactRepository>();
#endregion

/* Defino metodo de authentication and config */
#region
builder.Services
    .AddHttpContextAccessor()
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(Options =>
    {
        Options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Aundience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

//- `AddHttpContextAccessor`: Registra el `IHttpContextAccessor` que nos permite acceder el `HttpContext`de cada solicitud (la usaremos más adelante para acceder al usuario actual autenticado)
//- `AddAutorization`: Dependencias necesarias para autorizar solicitudes (como autorización por roles)
//- `AddAuthentication`: Agrega el esquema de autenticación que queramos usar, en este caso, queremos usar por default la autenticación por Bearer Tokens (Básicamente es para decirle que vamos a usar JWT)
//- `AddJwtBearer`: Configura la autenticación por tokens, especificando qué cosas debe de validar y que llave privada utilizar.
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); /* Implemento el middlewares para decodificar automaticamente y agregar el Jwt si la solicitud HTTP es valida */

app.UseAuthorization();

app.MapControllers();

app.Run();
