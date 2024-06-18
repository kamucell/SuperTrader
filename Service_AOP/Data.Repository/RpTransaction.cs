using SuperTrader.Core.DataAccess.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RpTransaction : EfEntityRepositoryBase<Data.Entities.Transaction, SuperTraderContext>, Abstract.IRpTransaction
    {
        public RpTransaction() : base()
        {
        }

    }
}
