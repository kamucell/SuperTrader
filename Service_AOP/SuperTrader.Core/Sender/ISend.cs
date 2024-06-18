using SuperTrader.Core.Event;
using SuperTrader.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTrader.Core.Sender
{
    public  interface ISend
    {
        IResult Send (List<ReceiverInfo> receiver,string message);
    }
}
