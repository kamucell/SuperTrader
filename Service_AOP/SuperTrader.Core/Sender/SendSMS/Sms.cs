using SuperTrader.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTrader.Core.Sender.SendSMS
{
    public class Sms : ISend
    {
        public   IResult Send(List<ReceiverInfo> receiver, string message)
        {

            return new SuccessResult();
        }
    }
}
