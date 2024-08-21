using Godot;

namespace Controllers.Scripts;

public partial class Adventurer: Ghost
{
    [Export] public int Speed { get; set; } = 100;
    
    public override void _PhysicsProcess(double delta)
    {
        var direction = Input.GetVector("ui_left", "ui_right",  "ui_up", "ui_down");
        Velocity = direction * Speed;
        MoveAndSlide();
    }
}