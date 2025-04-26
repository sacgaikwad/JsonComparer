using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonComparer
{
    public sealed class ParseToken : IParseToken
    {
        public Dictionary<string, object> ParseJsonToken(string json)
        {
            var token = JsonConvert.DeserializeObject<JToken>(json);
            var dict = new Dictionary<string, object>();

            if (token != null)
            {
                foreach (var prop in token.Children<JProperty>())
                {
                    if (prop.Value.Type == JTokenType.Array)
                    {
                        foreach (var item in prop.Value.Children())
                        {
                            dict[item.Path] = item;
                        }
                    }
                    if (prop.Value.Type == JTokenType.Object)
                    {
                        foreach (var childProp in prop.Value.Children<JProperty>())
                        {
                            dict[childProp.Path] = childProp.Value;
                        }
                    }
                    if (prop.Value.Type != JTokenType.Array && prop.Value.Type != JTokenType.Object && prop.Value.Type != JTokenType.Property)
                    {
                        dict[prop.Path] = prop.Value;
                    }
                }
            }
            return dict;
        }
    }
}
