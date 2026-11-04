using System;

namespace Lims.Domain.Discounts
{
    public class CompanySubscriptionStrategy : IDiscountStrategy
    {
        public PayerType PayerType => PayerType.CompanySubscription;
        public decimal Apply(decimal price) => Math.Max(price - 10m, 0);
    }
}
