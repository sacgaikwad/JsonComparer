using System.Text.Json.Serialization;

namespace JsonComparer
{
    public sealed class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}
