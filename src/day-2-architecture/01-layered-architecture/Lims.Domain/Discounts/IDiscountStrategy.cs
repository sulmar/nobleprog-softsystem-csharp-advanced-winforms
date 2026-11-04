namespace Lims.Domain.Discounts
{
    public interface IDiscountStrategy
    {
        PayerType PayerType { get; }
        decimal Apply(decimal price);
    }
}
