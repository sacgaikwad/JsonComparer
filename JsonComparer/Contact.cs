using System.Text.Json.Serialization;

namespace JsonComparer
{
    public sealed class Contact
    {
        [JsonPropertyName("mobileNumber")]
        public long MobileNumber { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("type")]
        public List<string> Type { get; set; }
    }
}
