using Amazon.Lambda;
using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace AWSLambdaFunctionsUsingSQLSpike.Requestors {

    using AWSLambdaFunctionsUsingSQLSpike.Pocos;
    using AWSLambdaFunctionsUsingSQLSpike.SQLCommands;

    public class NotificationRequestor {

        private static ILambdaContext _context;

        public NotificationRequestor(ILambdaContext context) {
            _context = context;
        }

        public async Task<List<Notification>> GetNotifications() {

            List<Notification> notificationList;

            try {
                string conString = "data source=.; database=StudentDB; integrated security=SSPI";

                var sqlConnection = new SqlConnection(conString);
                var getNotificationCommand = new GetNotificationsCommand(1, sqlConnection);

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


