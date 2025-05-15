using Customers.Services;
using EnigeeringEmployeeBasicInfo.Services;
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
            
            // Add the services 
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<GetEnigeeringEmployeeBasicInfo>();

        }
    }
}
