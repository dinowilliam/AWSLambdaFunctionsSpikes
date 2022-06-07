using Amazon.Lambda;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace AWSLambdaFunctionsUsingSQLSpike.Requestors {
    using AWSLambdaFunctionsUsingSQLSpike.Pocos;
    using AWSLambdaFunctionsUsingSQLSpike.Requestors.Contracts;
    using AWSLambdaFunctionsUsingSQLSpike.SQLCommands;
    using Microsoft.Extensions.Configuration;

    public class NotificationRequestor : INotificationRequestor {
        
        private static IConfiguration _configuration;

        public NotificationRequestor(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<List<Notification>> GetNotifications(ILambdaContext context) {

            List<Notification> notificationList;

            try {
                                                
                var sqlConnection = new SqlConnection(_configuration.GetConnectionString("lambdaConString"));
                var getNotificationCommand = new GetNotificationsCommand(10250, sqlConnection);

                notificationList = getNotificationCommand.Execute();
            }
            catch (AmazonLambdaException ex) {
                throw ex;
            }
            finally {
                LambdaLogger.Log("ENVIRONMENT VARIABLES: " + JsonConvert.SerializeObject(System.Environment.GetEnvironmentVariables()));
                LambdaLogger.Log("CONTEXT: " + JsonConvert.SerializeObject(context));
            }

            return notificationList;
        }
        
    }
}


