using SuperTrader.Core.DataAccess.EFRepository;

namespace Data.Repository
{
    public class RpUser : EfEntityRepositoryBase<Data.Entities.User, SuperTraderContext>, Abstract.IRpUser
    {
        public RpUser() : base()
        {
        }
        
    }
}
