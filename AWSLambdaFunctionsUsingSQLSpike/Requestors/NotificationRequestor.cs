using Amazon.Lambda;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace AWSLambdaFunctionsUsingSQLSpike.Requestors {
    using AWSLambdaFunctionsUsingSQLSpike.Configuration;
    using AWSLambdaFunctionsUsingSQLSpike.Pocos;
    using AWSLambdaFunctionsUsingSQLSpike.SQLCommands;
    using Microsoft.Extensions.Configuration;

    public class NotificationRequestor {

        private static ILambdaContext _context;
        private static IConfiguration _configuration;

        public NotificationRequestor(ILambdaContext context, IConfiguration configuration) {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Notification>> GetNotifications() {

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
                LambdaLogger.Log("CONTEXT: " + JsonConvert.SerializeObject(_context));
            }

            return notificationList;
        }
        
    }
}


