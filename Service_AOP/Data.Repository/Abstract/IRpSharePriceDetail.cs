using Data.Entities;
using SuperTrader.Core.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Abstract
{
	public interface IRpSharePriceDetail : IRepository<Data.Entities.SharePriceDetail>
    {
        Task<IEnumerable<SharePriceDetail>> GetLastPriceOfShareAsync(int shareId);
    }
}
 
