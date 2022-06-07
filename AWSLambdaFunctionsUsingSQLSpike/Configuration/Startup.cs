using Amazon.Extensions.NETCore.Setup;
using AWSLambdaFunctionsUsingSQLSpike.Requestors;
using AWSLambdaFunctionsUsingSQLSpike.Requestors.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AWSLambdaFunctionsUsingSQLSpike.Configuration {
    public class Startup {
        public IServiceProvider Setup() {

            var configuration = new ConfigurationBuilder() 
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
               .AddEnvironmentVariables() 
               .Build();
            var services = new ServiceCollection(); 
            
            services.AddSingleton<IConfiguration>(configuration);
         
            ConfigureServices(configuration, services);

            IServiceProvider provider = services.BuildServiceProvider();

            return provider;
        }

        private void ConfigureServices(IConfiguration configuration, ServiceCollection services) {
            
            #region AWS SDK setup

            AWSOptions awsOptions = configuration.GetAWSOptions();
            
            services.AddDefaultAWSOptions(awsOptions);

            #endregion

            services.AddSingleton<INotificationRequestor, NotificationRequestor>();
        }
    }
}