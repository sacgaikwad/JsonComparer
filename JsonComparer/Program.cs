namespace JsonComparer
{
    public class Program
    {
        public static async Task Main()
        {
            int thresholdCount = 1;
            string originalMessage = "{ \"Name\": \"Sachin\",\"Age\": 30, \"City\": \"New York\", \"Contact\": { \"MobileNumber\": 98855226612,\"Email\": \"test@test.com\"}}";
            string counterPartyMessage = "{ \"Name\": \"Sachin\",\"Age\": 31, \"City\": \"New York\", \"Contact\": { \"MobileNumber\": 98855226611,\"Email\": \"test@test.com\"}}";

            var original = DictionaryComparer.ConvertJsonToDictionary(originalMessage);
            var counterParty = DictionaryComparer.ConvertJsonToDictionary(counterPartyMessage);

            var modifiedValues = DictionaryComparer.CompareDictionaries(original, counterParty);

            if (modifiedValues.Count >= thresholdCount)
            {
                Console.WriteLine($"Message is modified more than threshold: {modifiedValues.Count}");
            }
            else
            {
                Console.WriteLine($"Message is not modified");
            }
        }
    }
}
