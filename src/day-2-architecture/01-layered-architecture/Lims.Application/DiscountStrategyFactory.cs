using Lims.Domain;
using Lims.Domain.Discounts;
using System.Collections.Generic;
using System.Linq;

namespace Lims.Application
{
    // Primary Constructor C# 12
    // public class DiscountStrategyFactory(IEnumerable<IDiscountStrategy> strategies)
    public class DiscountStrategyFactory
    {
        private readonly IEnumerable<IDiscountStrategy> strategies;
        public DiscountStrategyFactory(IEnumerable<IDiscountStrategy> strategies) => this.strategies = strategies;        
        public IDiscountStrategy Create(PayerType payerType) => strategies.Single(s => s.PayerType == payerType);
    }
}
