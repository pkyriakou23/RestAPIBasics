using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace RestAPIBasics.Models
{
    public class CountryData
    {
        [Key]
        public int Id { get; set; } //only for database
        [JsonPropertyName("name")]
        public required Name Name { get; set; }
        private List<string>? _capital;
        [JsonPropertyName("capital")]
        public List<string>? Capital
        {
            get => _capital;
            set => _capital = (value == null || value.Count == 0) ? null : value;
        }
        private List<string>? _borders;
        [JsonPropertyName("borders")]
        public List<string>? Borders
        {
            get => _borders;
            set => _borders = (value == null || value.Count == 0) ? null : value;
        }
    }

    [Owned]
    public class Name
    {
        [JsonPropertyName("common")]
        public required string Common { get; set; }
    }
}
    