using PureMVCContent.Controller;

public class PlayCommand : PureMVC.Patterns.MacroCommand
{
    protected override void InitializeMacroCommand()
    {
        AddSubCommand(typeof(Play1SubCommand));
        AddSubCommand(typeof(Play2SubCommand));
    }
}