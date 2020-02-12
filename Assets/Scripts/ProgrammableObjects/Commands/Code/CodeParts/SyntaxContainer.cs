using System;

[System.Serializable]
public class SyntaxContainer
{
    public string Name;
    public CommandType CommandType;

    [Obsolete]
    public ArgsType ArgsType;
}