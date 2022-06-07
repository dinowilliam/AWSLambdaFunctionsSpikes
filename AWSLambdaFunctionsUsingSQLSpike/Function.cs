using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaFunctionsUsingSQLSpike {
    using AWSLambdaFunctionsUsingSQLSpike.Configuration;
    using AWSLambdaFunctionsUsingSQLSpike.Pocos;
    using AWSLambdaFunctionsUsingSQLSpike.Requestors.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public class Function {

        private readonly INotificationRequestor _notificationRequestor;

        public Function() {
            var startup = new Startup();
            IServiceProvider provider = startup.Setup();

            _notificationRequestor = provider.GetRequiredService<INotificationRequestor>();
        }

        public Task<List<Notification>> Handler(ILambdaContext context)  {
                        
            return _notificationRequestor.GetNotifications(context);
        }

    }
}
