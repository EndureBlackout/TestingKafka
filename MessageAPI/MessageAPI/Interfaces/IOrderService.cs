using MessageAPI.Models;

namespace MessageAPI.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> SubmitOrder(Order order);
    }
}
