
using StudentServices.Infrastructure.Builder.MapperProfile;
using Student_Interface;
using Student_Data;
using Student_Model;
using WebAPI.Assignment.Controllers;
using Student_IServices;
using Scrutor;

namespace WebAPI.Assignment
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomDatabase(this IServiceCollection services, IConfiguration _configuration) 
        {
            services.AddScoped<IDataBaseFactory>(x =>
            {
                return new DataBaseFactory(x.GetRequiredService<ILogger<IDataBaseFactory>>(), _configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        
        }
        public static IServiceCollection AddCustomMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoToModelMappingProfile));
            services.AddAutoMapper(typeof(ModelToDtoMappingProfile));
            return services;
        }
        public static IServiceCollection AddCustomAssimblies(this IServiceCollection services)
        {
            var type = new List<Type>()
            {
              typeof(IDataBaseFactory),
              typeof(DataBaseFactory),
              typeof(IStudentServices),
              typeof(Services.StudentServices),
              typeof(StudentController)
            };
            services.Scan(scan => scan
                .FromAssembliesOf(type)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
            services.AddTransient<Student>();
            return services;

        }
    }
}
