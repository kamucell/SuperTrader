using SuperTrader.Core.DataAccess.EFRepository;

namespace Data.Repository
{
    public class RpShareOwner : EfEntityRepositoryBase<Data.Entities.ShareOwner, SuperTraderContext>, Abstract.IRpShareOwner
    {
        public RpShareOwner() : base()
        {
        }
        
    }
}
