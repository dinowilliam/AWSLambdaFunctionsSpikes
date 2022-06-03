using Amazon.Lambda.Model;

namespace AWSLambdaFunctionsSimpleSpike.Pocos
{
    public class RequestorObject
    {
        public string Input { get; set; }
        public Task<AccountUsage> AccountUsage { get; set; }
    }
}
