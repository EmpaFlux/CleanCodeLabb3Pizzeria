namespace DefaultNamespace
{
    public class OrderSubscriber
    {
        {
            public void pollAndPrintMessage(Publisher publisher)
            {
                if (publisher.hasNewMessage())
                {
                    Console.WriteLine(publisher.pollMessage());
                }
                else
                {
                    Console.WriteLine("No new messages");
                }
            }
        }
    }
}