using FluentValidation.AspNetCore;

using Fluent.Validation.API.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

            builder.Services.AddControllers(options =>
                options.Filters.Add<ValidationFilter>()
            )
            .ConfigureApiBehaviorOptions(configuration =>
                configuration.SuppressModelStateInvalidFilter = true
            )
            .AddFluentValidation(configuration =>
            {
                configuration.ImplicitlyValidateChildProperties = false;
                configuration.DisableDataAnnotationsValidation = true;
                //configuration.AutomaticValidationEnabled = false;
                configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
