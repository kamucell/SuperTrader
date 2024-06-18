using System.Collections.Generic;
using System.Threading.Tasks;
using SuperTrader.Core.Results;

namespace SuperTrader.Core.Sender.SendEmail
{
    public class Email:ISend
    {
        public IResult Send(List<ReceiverInfo> receiver, string message)
        {
            
            return new SuccessResult();
        }


    }
}
