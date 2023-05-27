using System.Text.Json.Serialization;

namespace WebApp.Data.Models
{
    public class Account
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }
        [JsonPropertyName("internalId")]
        public long InternalId { get; set; }
        [JsonPropertyName("counter")]
        public int Counter { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }

        public Account Clone() => (Account) MemberwiseClone();
    }
}