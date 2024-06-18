using SuperTrader.Core.Results;
using System.Threading.Tasks;

namespace SuperTrader.Core.Rule
{
    public class RuleEnginee
    {
        public async Task<IResult> ValidateAsync(params Task<IResult>[] rules)
        {
            foreach (var rule in rules)
            {
                var result = await rule;
                if (!result.Success)
                    return result;
            }

            return new SuccessResult();
        }
    }
}
