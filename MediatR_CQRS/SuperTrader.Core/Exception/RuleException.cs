using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTrader.Core.Exception
{
    public class RuleException : System.Exception
    {
        public RuleException(string message) : base(message)
        {

        }
    }
}
