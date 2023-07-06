using System.Text.Json.Serialization;

namespace GoogleAuth.Shared.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [JsonIgnore]
        public string FullName { get => FirstName + " " + LastName; }
        public string Place { get; set; } = string.Empty;
    }
}