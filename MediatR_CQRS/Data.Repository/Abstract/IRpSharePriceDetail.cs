using SuperTrader.Domain;
using SuperTrader.Core.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Abstract
{
	public interface IRpSharePriceDetail : IRepository<SuperTrader.Domain.SharePriceDetail>
    {
        Task<IEnumerable<SharePriceDetail>> GetLastPriceOfShareAsync(int shareId);
    }
}
 
