public class CustomCapterraItem : ICustomItem
{
    public string Name { get; internal set; }
    public List<string> Tags { get; internal set; }
    public string Twitter { get; internal set; }

    public CustomCapterraItem()
    {
        Tags = new List<string>();
    }
}