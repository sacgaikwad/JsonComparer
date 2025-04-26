namespace JsonComparer
{
    public class Program
    {
        public static async Task Main()
        {
            int thresholdCount = 1;
            string originalMessage = "{\"Name\":\"Sachin\",\"Age\":30,\"City\":\"NewYork\",\"Contact\":{\"MobileNumber\":98855226611,\"Email\":\"test@test.com\"},\"Hobbies\":[\"BasketBall\",\"Football\",\"Tennis\"]}";
            string counterPartyMessage = "{\"Name\":\"Sachin\",\"Age\":30,\"City\":\"NewYork\",\"Contact\":{\"MobileNumber\":98855226612,\"Email\":\"test@test.com\"},\"Hobbies\":[\"Cricket\",\"Football\",\"Tennis\"]}";

            IParseToken parseToken = new ParseToken();
            var original = parseToken.ParseJsonToken(originalMessage);
            var counterParty = parseToken.ParseJsonToken(counterPartyMessage);
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
