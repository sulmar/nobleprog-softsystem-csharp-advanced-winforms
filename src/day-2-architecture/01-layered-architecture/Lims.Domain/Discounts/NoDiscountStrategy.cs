namespace Lims.Domain.Discounts
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        public PayerType PayerType => PayerType.Commercial;
        public decimal Apply(decimal price) => price;
    }
}
