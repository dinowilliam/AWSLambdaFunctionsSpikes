using Amazon.Lambda;
using Amazon.Lambda.Core;
using AWSLambdaFunctionsUsingSQLSpike.Pocos;
using AWSLambdaFunctionsUsingSQLSpike.Requestors;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaFunctionsUsingSQLSpike
{
    public class Function {

        public Task<List<Notification>> Handler(string input, ILambdaContext context)  {
                        
            var notificationRequestor = new NotificationRequestor(context);            

            return notificationRequestor.GetNotifications();
        }

    }
}
