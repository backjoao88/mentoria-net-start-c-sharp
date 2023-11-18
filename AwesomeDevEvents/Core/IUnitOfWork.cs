using AwesomeDevEvents.Core.Repositories;
namespace AwesomeDevEvents.Core
{
    public interface IUnitOfWork
    {
        public IDevEventRepository DevEventRepository { get; }
        public int Complete();
    }
}