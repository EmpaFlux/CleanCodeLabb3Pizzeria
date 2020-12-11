namespace DefaultNamespace
{
    public class OrderPublisher
    {
        private string message;
        private List<string> Order;

        public void PostNewMessage(string message)
        {
            this.message = message;
            this.
        }

        public void MarkMessageAsRead()
        {
            message = null;
        }
        
        public bool hasNewMessage()
        {
            return message != null;
        }

        public string pollMessage()
        {
            return message;
        }
    }
}