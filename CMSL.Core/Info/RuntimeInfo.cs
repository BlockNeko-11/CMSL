namespace CMSL.Core.Info;

public static class RuntimeInfo
{
    public static RunType RunType { get; set; } = RunType.Program;
}

public enum RunType
{
    Program,
    Designer
}
