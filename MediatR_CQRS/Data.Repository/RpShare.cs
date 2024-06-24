using SuperTrader.Core.DataAccess.EFRepository;

namespace Data.Repository
{
    public class RpShare : EfEntityRepositoryBase<SuperTrader.Domain.Share, SuperTraderContext>, Abstract.IRpShare
    {
        public RpShare() : base()
        {
        }
        
    }
}
