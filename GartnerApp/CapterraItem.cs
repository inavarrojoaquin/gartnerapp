using YamlDotNet.Serialization;

public class CapterraItem
{
    [YamlMember(Alias = "tags", ApplyNamingConventions = false)]
    public string Tags { get; set; }

    [YamlMember(Alias = "name", ApplyNamingConventions = false)]
    public string Name { get; set; }

    [YamlMember(Alias = "twitter", ApplyNamingConventions = false)]
    public string Twitter { get; set; }
}