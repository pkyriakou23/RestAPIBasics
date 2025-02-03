namespace RestAPIBasics.Service.Implementation
{
    public class NumbersServiceImpl : INumbersService
    {
        public int? GetSecondLargest(IEnumerable<int> numbers)
        {
            if (numbers == null || numbers.Count() < 2)
                return null;

            int? largest = null, secondLargest = null;

            foreach (var num in numbers)
            {
                if (largest == null || num > largest)
                {
                    secondLargest = largest;
                    largest = num;
                }
                else if ((secondLargest == null || num > secondLargest) && num < largest)
                {
                    secondLargest = num;
                }
            }
            return secondLargest;
        }
    }
}
