using Microsoft.OpenApi.Models;

namespace AWLT2022.API.Extensions {
    public static class WebApplicationBuilderExtensions {
        public static void AddPresentation(this WebApplicationBuilder builder) {

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAuthentication();

            builder.Services.AddScoped<Customers.Services.CustomerService>(sp => {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                return new Customers.Services.CustomerService(connectionString);
            });

        }
    }
}
