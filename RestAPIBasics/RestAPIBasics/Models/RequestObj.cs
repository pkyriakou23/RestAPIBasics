using System.ComponentModel.DataAnnotations;

namespace RestAPIBasics.Models
{
    public class RequestObj
    {
        [Required]
        public required IEnumerable<int> RequestArrayObj { get; set; }
    }
}
