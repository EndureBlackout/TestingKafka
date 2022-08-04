namespace MessageAPI.Interfaces
{
    public interface IKafkaClient
    {
        public Task writeMessage(string message);
    }
}
