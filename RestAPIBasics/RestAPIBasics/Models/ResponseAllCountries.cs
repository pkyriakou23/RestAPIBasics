namespace RestAPIBasics.Models
{
    public class ResponseAllCountries
    {
        public string? Name { get; set; }
        public IEnumerable<string>? Capital { get; set; }
        public IEnumerable<string>? Borders { get; set; }

        public ResponseAllCountries()
        {
            Capital = new List<string>();
            Borders = new List<string>();
        }
    }
}
