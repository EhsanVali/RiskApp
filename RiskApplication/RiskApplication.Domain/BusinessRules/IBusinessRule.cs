namespace RiskApplication.Domain.BusinessRules
{
    public interface IBusinessRule<T> where T : class
    {
        bool IsValid(T obj);
    }
}