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
    }
}
