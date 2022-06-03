using Amazon.Lambda;
using Amazon.Lambda.Core;
using Amazon.Lambda.Model;
using Amazon.XRay.Recorder.Handlers.AwsSdk;
using Newtonsoft.Json;

namespace AWSLambdaFunctionsSimpleSpike.Requestors
{
    public class AccountUsageRequestor
    {
        private static AmazonLambdaClient _lambdaClient;
        private static ILambdaContext _context;

        public AccountUsageRequestor(AmazonLambdaClient lambdaClient, ILambdaContext context)
        {

            _lambdaClient = lambdaClient;
            _context = context;
        }

        public async void Initialize()
        {
            AWSSDKHandler.RegisterXRayForAllServices();
            await CallLambda();
        }

        public async Task<AccountUsage> GetAccountUsage()
        {
            GetAccountSettingsResponse accountSettings;

            try
            {
                accountSettings = await CallLambda();
            }
            catch (AmazonLambdaException ex)
            {
                throw ex;
            }

            AccountUsage accountUsage = accountSettings.AccountUsage;

            LambdaLogger.Log("ENVIRONMENT VARIABLES: " + JsonConvert.SerializeObject(System.Environment.GetEnvironmentVariables()));
            LambdaLogger.Log("CONTEXT: " + JsonConvert.SerializeObject(_context));

            return accountUsage;
        }

        public static async Task<GetAccountSettingsResponse> CallLambda()
        {
            var request = new GetAccountSettingsRequest();
            var response = await _lambdaClient.GetAccountSettingsAsync(request);
            return response;
        }
    }
}


