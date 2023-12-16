using BloodManager.Core.Repositories;

namespace BloodManager.Core;

public interface IUnitOfWork
{
    public IDonorRepository DonorRepository { get; set; }
    public IDonationRepository DonationRepository { get; set; }
    public IStockRepository StockRepository { get; set; }
    public int Complete();
    public Task<int> CompleteAsync();
}
