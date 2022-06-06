using Amazon.Lambda;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaFunctionsUsingSQLSpike {
    using AWSLambdaFunctionsUsingSQLSpike.Configuration;
    using AWSLambdaFunctionsUsingSQLSpike.Pocos;
    using AWSLambdaFunctionsUsingSQLSpike.Requestors;

    public class Function {

        public Task<List<Notification>> Handler(ILambdaContext context)  {

            var configuration = LambdaConfigurationBuilder.Build();

            var notificationRequestor = new NotificationRequestor(context, configuration);            

            return notificationRequestor.GetNotifications();
        }

    }
}
