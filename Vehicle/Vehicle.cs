using System;
using Godot;

namespace Controllers.Scripts;

public partial class Vehicle: Ghost
{
    [Export] public float RotationSpeed { get; set; } = 3.0f;

    [Export] public float Acceleration { get; set; } = 500.0f;
    
    [Export] public float Deceleration { get; set; } = 500.0f;

    [Export] public float MaxSpeed { get; set; } = 500.0f;

    public override void _PhysicsProcess(double delta)
    {
        ProcessMovement(delta);
        ProcessRotation(delta);
        MoveAndSlide();
    }

    private void ProcessMovement(double delta)
    {
        var targetVelocity = Vector2.Zero;

        if (Input.IsActionPressed("ui_up"))
        {
            targetVelocity = UpDirection.Rotated(Rotation) * MaxSpeed;
        } 
        else if (Input.IsActionPressed("ui_down"))
        {
            targetVelocity = UpDirection.Rotated(Rotation + (float)Math.PI) * MaxSpeed;
        }

        Velocity = targetVelocity != Vector2.Zero
            ? Velocity.MoveToward(targetVelocity, Acceleration * (float)delta) 
            : Velocity.MoveToward(Vector2.Zero, Deceleration * (float)delta);
    }

    private void ProcessRotation(double delta)
    {
        var normalizeSpeed = Velocity.Length() / MaxSpeed;

        if (Input.IsActionPressed("ui_left"))
        {
            Rotation -= (float)delta * RotationSpeed * normalizeSpeed;
        } 
        else if (Input.IsActionPressed("ui_right"))
        {
            Rotation += (float)delta * RotationSpeed * normalizeSpeed;
        }
    }
}