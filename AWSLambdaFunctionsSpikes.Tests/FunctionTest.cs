using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

namespace AWSLambda1.Tests;

public class FunctionTest
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