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

        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }

        [JsonPropertyName("hobbies")]
        public List<string> Hobbies { get; set; }
    }
}
