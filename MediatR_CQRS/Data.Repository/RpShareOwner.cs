using SuperTrader.Core.DataAccess.EFRepository;

namespace Data.Repository
{
    public class RpShareOwner : EfEntityRepositoryBase<SuperTrader.Domain.ShareOwner, SuperTraderContext>, Abstract.IRpShareOwner
    {
        public RpShareOwner() : base()
        {
        }
        
    }
}
