using SuperTrader.Core.DataAccess.EFRepository;

namespace Data.Repository
{
    public class RpPortfolio : EfEntityRepositoryBase<Data.Entities.Portfolio, SuperTraderContext>, Abstract.IRpPortfolio
    {
        public RpPortfolio() : base()
        {
        }
        
    }
}
