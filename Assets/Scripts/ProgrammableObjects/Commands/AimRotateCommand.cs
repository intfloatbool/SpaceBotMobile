public class AimRotateCommand : CommandBase
{
    public override CommandType CommandType => CommandType.AIM_ROTATE;

    public AimRotateCommand(ProgrammableObjectBase programmableObjectBase, object[] args = null) : base(programmableObjectBase, args) { }
}
