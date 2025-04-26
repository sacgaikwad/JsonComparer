namespace JsonComparer
{
    public sealed class DictionaryComparer
    {
        public static List<string> CompareDictionaries(Dictionary<string, object> originalDictionary, Dictionary<string, object> counterPartyDictonary)
        {
            var differences = new List<string>();

            foreach (var kvp in originalDictionary)
            {
                if (!counterPartyDictonary.ContainsKey(kvp.Key))
                {
                    differences.Add($"Missing key in second dictionary: {kvp.Key}");
                }
                else
                {
                    var dictionaryValueOne = kvp.Value;
                    var dictionaryValueTwo = counterPartyDictonary[kvp.Key];
                    if (!object.Equals(dictionaryValueOne, dictionaryValueTwo))
                    {
                        differences.Add($"Value mismatch for key {kvp.Key}: {dictionaryValueOne} vs {dictionaryValueTwo}");
                    }
                }
            }

            // Check for extra keys in second dictionary
            foreach (var kvp in counterPartyDictonary)
            {
                if (!originalDictionary.ContainsKey(kvp.Key))
                {
                    differences.Add($"Extra key in second dictionary: {kvp.Key}");
                }
            }

            return differences;
        }
    }
}
