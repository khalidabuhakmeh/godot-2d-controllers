using Godot;

public partial class Platformer : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 500;
    
    [Export]
    public int JumpVelocity { get; set; } = -400;

    public override void _PhysicsProcess(double delta)
    {
        if (!IsOnFloor())
        {
            var gravity = GetGravity() * (float)delta;
            Velocity += gravity;
        }
        
        var velocity = new Vector2(Velocity.X, Velocity.Y);
        if (Input.IsActionPressed("ui_accept") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        var direction = Input.GetAxis("ui_left", "ui_right");
        if (direction != 0)
        {
            velocity.X =  direction * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
