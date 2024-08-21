using Godot;

public partial class Ghost : CharacterBody2D
{
	private Sprite2D sprite;
	[Export] public float Speed { get; set; } = 500.0f;
	[Export(PropertyHint.Range, "0,1")]
	public float Floatiness { get; set; } = 0.025f;

	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Velocity = Velocity.Lerp(Speed * direction, Floatiness);

		sprite.FlipH = direction.X switch
		{
			< 0 => false,
			> 0 => true,
			_ => sprite.FlipH
		};

		MoveAndSlide();
	}
}
