using Godot;

namespace Controllers.Scripts;

public partial class Runner: CharacterBody2D
{
    [Export] public float Speed { get; set; } = 100f;
    [Export] public float Force { get; set; } = 500f;
    [Export] public float CooldownMilliseconds { get; set; } = 500f;

    // start with a big value to allow immediate jump
    private float previousJump = -10_000f; 

    public override void _PhysicsProcess(double delta)
    {
        // always falling
        Velocity += GetGravity() * (float)delta;
        // always moving forward
        Velocity = new Vector2(Speed, Velocity.Y);

        var now = Time.GetTicksMsec();
        var difference = now - previousJump;
        var canJump = difference >= CooldownMilliseconds;
        
        if (canJump && Input.IsActionJustPressed("ui_accept"))
        {
            Velocity = Velocity with { Y = -Force };
            previousJump = now;
        }
        
        MoveAndSlide();
    }
}