
using System.Data;
using System.Data.SqlClient;

namespace AWSLambdaFunctionsUsingSQLSpike.SQLCommands {

    using AWSLambdaFunctionsUsingSQLSpike.Pocos;
    using AWSLambdaFunctionsUsingSQLSpike.SQLCommands.Contracts;

    public class GetNotificationsCommand : ISQLCommand<Notification> {

        private readonly SqlConnection _connection;
        private SqlParameter _orderIdSqlParameter;

        public GetNotificationsCommand(int OrderId, SqlConnection connection) {
            _connection = connection;            
            _orderIdSqlParameter = new SqlParameter("@OrderID", SqlDbType.Int) { Value = OrderId };            
        }

        private string SQL {

            get => @"SELECT 
                            NotificationID, 
                            OrderID, 
                            ProductID, 
                            Description, 
                            InsertedDate 
                    FROM Notifications
                    WHERE OrderID = @OrderID
                   ";
        }

        public List<Notification> Execute() {
            
            var notificationList = new List<Notification>();

            using (_connection) {
                                
                SqlCommand sqlCommand = new SqlCommand(this.SQL, _connection);
                sqlCommand.Parameters.Add(_orderIdSqlParameter); 
                
                _connection.Open();
                
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) {

                    var notification = new Notification();

                    notification.NotificationID = sqlDataReader["NotificationID"].ToString();
                    notification.OrderID = sqlDataReader["OrderID"].ToString();
                    notification.ProductID = sqlDataReader["ProductID"].ToString();
                    notification.Description = sqlDataReader["Description"].ToString();
                    notification.InsertedDate = DateTime.Parse(sqlDataReader["InsertedDate"].ToString());

                    notificationList.Add(notification);
                }
                
                _connection.Close();
            }

            return notificationList;
        }
    }
}
