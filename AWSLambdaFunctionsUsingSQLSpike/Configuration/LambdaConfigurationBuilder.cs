using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace AWSLambdaFunctionsUsingSQLSpike.Configuration {
    public static class LambdaConfigurationBuilder {
        public static IConfiguration Build() => new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())          
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .Build();
    }
}