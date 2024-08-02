using System.Reflection;

namespace ProjectRoadmap.Plugins.Host;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}