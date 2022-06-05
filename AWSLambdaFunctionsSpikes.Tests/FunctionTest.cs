using Amazon.Lambda.TestUtilities;
using Xunit;

namespace AWSLambdaFunctionsSpikes.Tests;

using AWSLambdaFunctionsSimpleSpike;

public class FunctionTest
{
  

    [Fact]
    public void Function_WhenHandlerCall_IsValid()
    {
        //Arrange
        var function = new Function();
        var context = new TestLambdaContext();
        var request = "Hello World from Lambda";
        
        //Act
        var response = function.Handler(request, context);
        
        //Assert
        Assert.Contains(request, response.Input);
    }

    [Fact]
    public void Function_WhenHandlerCall_IsInvalid()
    {
        //Arrange
        var function = new Function();
        TestLambdaContext context = null;
        var request = "Hello World from Lambda";

        //Act
        var response = function.Handler(request, context);

        //Assert
        Assert.Null(response.AccountUsage);
    }
}