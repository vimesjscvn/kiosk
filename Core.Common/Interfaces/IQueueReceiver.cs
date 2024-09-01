using System.Threading.Tasks;

namespace Core.Common.Interfaces
{
    public interface IQueueReceiver
    {
        Task<string> GetMessageFromQueue(string queueName);
    }
}