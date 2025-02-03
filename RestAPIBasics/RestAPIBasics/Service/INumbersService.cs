namespace RestAPIBasics.Service
{
    public interface INumbersService
    {
        int? GetSecondLargest(IEnumerable<int> numbers);
    }
}
