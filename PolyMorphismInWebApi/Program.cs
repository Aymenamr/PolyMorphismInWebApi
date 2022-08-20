using PolymorphismInWebApi.Utils;
using JsonSubTypes;
using Microsoft.OpenApi.Models;
using PolymorphismInWebApi.Models.Abstract;
using PolymorphismInWebApi.Models;
using PolymorphismInWebApi.Models.Enumeration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(
        JsonSubtypesConverterBuilder
        .Of(typeof(Device),CommonData.DeviceDiscriminator)
        .RegisterSubtype(typeof(Phone), DeviceTypeEnum.Phone)
        .RegisterSubtype(typeof(Laptop), DeviceTypeEnum.Laptop)
        .SerializeDiscriminatorProperty()
        .Build()
    );
   
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "PolymorphismInWebApi", 
                        Version = "v1" }
                );
        c.UseAllOfToExtendReferenceSchemas();
        c.UseAllOfForInheritance();
        c.UseOneOfForPolymorphism();
        c.SelectDiscriminatorNameUsing(type =>
        {
            return type.Name switch
            {
                nameof(Device) => CommonData.DeviceDiscriminator,
                _ => null
            };
        });   
});


var app = builder.Build();

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
