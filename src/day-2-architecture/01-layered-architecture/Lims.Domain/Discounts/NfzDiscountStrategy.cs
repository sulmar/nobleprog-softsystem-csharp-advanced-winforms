namespace Lims.Domain.Discounts
{
    public class NfzDiscountStrategy : IDiscountStrategy
    {
        public PayerType PayerType => PayerType.Nfz;
        public decimal Apply(decimal price) => 0m;
    }
}
