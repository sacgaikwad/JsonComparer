using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonComparer
{
    public sealed class DictionaryComparer
    {
        public static List<KeyValuePair<string, string>> GetModifiedValues(
            Dictionary<string, Person> original,
            Dictionary<string, Person> modified)
        {
            var modifiedEntries = new List<KeyValuePair<string, string>>();

            foreach (var kvp in original)
            {
                if (modified.TryGetValue(kvp.Key, out Person? value))
                {
                    var originalPerson = kvp.Value;
                    var modifiedPerson = value;

                    if (originalPerson.Name.Equals(modifiedPerson.Name) == false)
                    {
                        modifiedEntries.Add(new KeyValuePair<string, string>("Name", modifiedPerson.Name));
                    }
                    if (originalPerson.Age.Equals(modifiedPerson.Age) == false)
                    {
                        modifiedEntries.Add(new KeyValuePair<string, string>("Age", modifiedPerson.Age.ToString()));
                    }
                    if (originalPerson.City.Equals(modifiedPerson.City) == false)
                    {
                        modifiedEntries.Add(new KeyValuePair<string, string>("City", modifiedPerson.City));
                    }
                }
            }

            return modifiedEntries;
        }


        public static List<string> CompareDictionaries(Dictionary<string, object> originalDictionary, Dictionary<string, object> counterPartyDictonary)
        {
            var differences = new List<string>();

            foreach (var kvp in originalDictionary)
            {
                string fullKey = kvp.Key + "." + kvp.Key;

                if (!counterPartyDictonary.ContainsKey(kvp.Key))
                {
                    differences.Add($"Missing key in second dictionary: {fullKey}");
                }
                else
                {
                    var dictionaryValueOne = kvp.Value;
                    var dictionaryValueTwo = counterPartyDictonary[kvp.Key];

                    if (dictionaryValueOne is Dictionary<string, object> nestedDict1 && dictionaryValueTwo is Dictionary<string, object> nestedDict2)
                    {
                        // Recursively compare nested dictionaries
                        differences.AddRange(CompareDictionaries(nestedDict1, nestedDict2));
                    }
                    else if (!object.Equals(dictionaryValueOne, dictionaryValueTwo))
                    {
                        differences.Add($"Value mismatch for key: {dictionaryValueOne} vs {dictionaryValueTwo}");
                    }
                }
            }

            // Check for extra keys in second dictionary
            foreach (var kvp in counterPartyDictonary)
            {
                string fullKey = kvp.Key + "." + kvp.Key;
                if (!originalDictionary.ContainsKey(kvp.Key))
                {
                    differences.Add($"Extra key in second dictionary: {fullKey}");
                }
            }

            return differences;
        }

        public static Dictionary<string, object> ConvertJsonToDictionary(string json)
        {
            var token = JsonConvert.DeserializeObject<JToken>(json);
            return ParseToken(token);
        }

        private static Dictionary<string, object> ParseToken(JToken token)
        {
            if (token.Type == JTokenType.Object)
            {
                var dict = new Dictionary<string, object>();

                foreach (var prop in token.Children<JProperty>())
                {
                    dict[prop.Name] = ParseToken(prop.Value);
                }

                return dict;
            }
            else
            {
                return new Dictionary<string, object> { { ((JValue)token).Path, ((JValue)token).Value } };
            }
        }
    }
}
