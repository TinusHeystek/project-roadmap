namespace ProjectRoadmap.Shared.IOptions.Sample;

public class SampleSettings
{
    public const string SectionName = "Settings";
    
    public int IntField { get; init; }
    public required string UrlField { get; init; }
    public required string StringField { get; init; }
    public required ChildSettings Child { get; init; }
    public List<int> IntArray { get; init; } = [];
    public Dictionary<string, string> StringDictionary { get; init; } = [];
    public bool BooleanField { get; init; }
    public double DoubleField { get; init; }
}

public class ChildSettings
{
    public required string ChildProperty { get; init; }
}

