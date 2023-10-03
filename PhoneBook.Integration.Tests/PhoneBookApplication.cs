using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Repositories;

namespace PhoneBook.Integration.Tests
{
    internal class PhoneBookApplication : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                RemoveService<IPhoneBookRepository>(services);
                services.AddTransient<IPhoneBookRepository, PhoneBookRepositoryFake>();
            });

            builder.UseEnvironment("InMemoryApplication");
        }

        private static void RemoveService<T>(IServiceCollection services)
        {
            var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            
            if (serviceDescriptor != null)
                services.Remove(serviceDescriptor);
        }
    }
}
