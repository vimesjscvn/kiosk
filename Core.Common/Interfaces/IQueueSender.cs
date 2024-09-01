using System.Threading.Tasks;

namespace Core.Common.Interfaces
{
    public interface IQueueSender
    {
        Task SendMessageToQueue(string message, string queueName);
    }
}