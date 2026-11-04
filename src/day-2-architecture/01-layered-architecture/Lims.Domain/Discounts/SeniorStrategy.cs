namespace Lims.Domain.Discounts
{
    public class SeniorStrategy : IDiscountStrategy
    {
        public PayerType PayerType => PayerType.Senior;
        public decimal Apply(decimal price) => price * 0.5m;
    }
}
