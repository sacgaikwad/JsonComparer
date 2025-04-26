using Newtonsoft.Json;

namespace JsonComparer
{
    public class Program
    {
        public static async Task Main()
        {
            int thresholdCount = 1;
            string originalMessage = "{\"name\":\"Sachin\",\"age\":30,\"city\":\"New York\"}";
            string counterPartyMessage = "{\"name\":\"Sachin\",\"age\":31,\"city\":\"New York\"}";

            //Original Message
            var originalPerson = JsonConvert.DeserializeObject<Person>(originalMessage);
            Dictionary<string, Person> originalMessageDictionary = new()
            {
                { "Message", originalPerson }
            };

            //CounterParty Message
            var counterPartyPerson = JsonConvert.DeserializeObject<Person>(counterPartyMessage);
            Dictionary<string, Person> countertPartyMessageDictionary = new()
            {
                { "Message", counterPartyPerson }
            };

            var modifiedValues = DictionaryComparer.GetModifiedValues(originalMessageDictionary, countertPartyMessageDictionary);
            var modifiedCount = modifiedValues.Count;

            if (modifiedCount >= thresholdCount)
            {
                Console.WriteLine($"Message is modified more than threshold: {modifiedCount}");
            }
            else
            {
                Console.WriteLine($"Message is not modified");
            }
        }
    }
}
