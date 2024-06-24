using SuperTrader.Core.DataAccess.EFRepository;

namespace Data.Repository
{
    public class RpPortfolio : EfEntityRepositoryBase<SuperTrader.Domain.Portfolio, SuperTraderContext>, Abstract.IRpPortfolio
    {
        public RpPortfolio() : base()
        {
        }
        
    }
}
