using SuperTrader.Core.DataAccess.EFRepository;

namespace Data.Repository
{
    public class RpShare : EfEntityRepositoryBase<Data.Entities.Share, SuperTraderContext>, Abstract.IRpShare
    {
        public RpShare() : base()
        {
        }
        
    }
}
