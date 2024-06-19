using NexusGroup.Api.References;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Referencias
Reference.AddPositionDepedency(builder.Services, builder.Configuration);
Reference.AddAccessLevelDependency(builder.Services, builder.Configuration);
Reference.AddDBDependency(builder.Services, builder.Configuration);
Reference.AddJobOffersDependency(builder.Services, builder.Configuration);





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
