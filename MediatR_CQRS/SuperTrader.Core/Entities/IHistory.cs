using System;

namespace SuperTrader.Core.Entities
{
    public class IHistory
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
    }
}
