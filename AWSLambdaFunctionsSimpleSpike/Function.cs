using Amazon.Lambda;
using Amazon.Lambda.Core;
using AWSLambdaFunctionsSimpleSpike.Pocos;
using AWSLambdaFunctionsSimpleSpike.Requestors;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaFunctionsSimpleSpike
{
    public class Function {

        public RequestorObject Handler(string input, ILambdaContext context)  {
            
            var requestorObject = new RequestorObject();

            var accountUsageRequestor = new AccountUsageRequestor(new AmazonLambdaClient(), context);            

            requestorObject.Input = input.ToString();
            requestorObject.AccountUsage = accountUsageRequestor.GetAccountUsage();

            return requestorObject;
        }

    }
}
