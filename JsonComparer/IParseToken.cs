namespace JsonComparer
{
    public interface IParseToken
    {
        Dictionary<string, object> ParseJsonToken(string json);
    }
}
