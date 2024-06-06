using System.ComponentModel.DataAnnotations;

namespace ProjectRoadmap.Shared.IOptions.Sample;

public class SampleAnnotationSettings
{
    public const string SectionName = "Settings";
    
    [Range(0, 100)]
    public required int IntField { get; init; }
    [Required, Url]
    public required string UrlField { get; init; }
    [Required]
    public required string StringField { get; init; }
    [Required]
    public required ChildSettings Child { get; init; }
    [MinLength(5)]
    public List<int> IntArray { get; init; } = [];
    [MinLength(2)]
    public Dictionary<string, string> StringDictionary { get; init; } = [];
    public bool BooleanField { get; init; }
    [Range(1, double.MaxValue)]
    public double DoubleField { get; init; }
}