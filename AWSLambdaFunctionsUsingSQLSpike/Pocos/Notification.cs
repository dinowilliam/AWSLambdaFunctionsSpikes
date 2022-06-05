namespace AWSLambdaFunctionsUsingSQLSpike.Pocos
{
    public class Notification {
        public string NotificationID { get; set; }
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public string Description { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
