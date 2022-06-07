using Amazon.Lambda.Core;
using AWSLambdaFunctionsUsingSQLSpike.Pocos;

namespace AWSLambdaFunctionsUsingSQLSpike.Requestors.Contracts {
    public interface INotificationRequestor {
        Task<List<Notification>> GetNotifications(ILambdaContext context);
    }
}
