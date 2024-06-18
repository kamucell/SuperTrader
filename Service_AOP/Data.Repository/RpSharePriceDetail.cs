using Data.Entities;
using SuperTrader.Core.DataAccess.EFRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RpSharePriceDetail : EfEntityRepositoryBase<Data.Entities.SharePriceDetail, SuperTraderContext>, Abstract.IRpSharePriceDetail
    {
        public RpSharePriceDetail() : base()
        {
        }

        public async Task<IEnumerable<SharePriceDetail>> GetLastPriceOfShareAsync(int shareId) => await GetListAsync(f => f.ShareId == shareId, o => o.OrderByDescending(g => g.UpdatedDate),1);
    }
}
