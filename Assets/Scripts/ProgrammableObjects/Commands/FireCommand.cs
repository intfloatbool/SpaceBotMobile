public class FireCommand : CommandBase
{
    public override CommandType CommandType => CommandType.FIRE;

    public FireCommand(ProgrammableObjectBase programmableObject, object[] args = null) : base(programmableObject, args) { }
}
