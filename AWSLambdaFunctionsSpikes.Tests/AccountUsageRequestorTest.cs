using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

namespace AWSLambdaFunctionsSpikes.Tests;

public class AccountUsageRequestorTest
{
    [Fact]
    public void TestSampleFunction()
    {
        //var function = new Function();
        var context = new TestLambdaContext();        
        //var response = function.FunctionHandler(request, context);

        //Assert.Equal(200, response.StatusCode);
        //Assert.Contains("Hello World from Lambda", response.Body);
    }
}