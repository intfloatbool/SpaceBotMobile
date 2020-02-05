public abstract class CommandBase
{
    public abstract CommandType CommandType { get; }
    public object[] Args { get; set; }
    public ProgrammableObjectBase Reciever { get; protected set; }
    public CommandBase(ProgrammableObjectBase reciever) 
    {
        Reciever = reciever;
    }
    public CommandBase(ProgrammableObjectBase reciever, object[] args)
    {
        Reciever = reciever;
        Args = args;
    }
    public virtual void DoAction()
    {
        Reciever.ExecuteCommand(CommandType, Args);
    }
}
