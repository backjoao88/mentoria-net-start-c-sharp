using BloodDonationManager.Core.Repositories;

namespace BloodDonationManager.Core;

public interface IUnitOfWork
{
    public IDonorRepository DonorRepository { get; }
    public IDonationRepository DonationRepository { get; }
    public IStockRepository StockRepository { get; }
    public int Complete();
    public Task<int> CompleteAsync();
}