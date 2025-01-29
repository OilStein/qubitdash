using Godot;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed = 400f; // Speed of movement
	[Export] public float SprintMultiplier = 1.5f;


    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        if (Input.IsActionPressed("move_right")) velocity.X += 1;
        if (Input.IsActionPressed("move_left")) velocity.X -= 1;
        if (Input.IsActionPressed("move_down")) velocity.Y += 1;
        if (Input.IsActionPressed("move_up")) velocity.Y -= 1;

        if (velocity != Vector2.Zero)
        {
			float finalSpeed = Speed;
			if (Input.IsActionPressed("sprint")) // Add "sprint" action in Input Map (e.g., Shift)
        	{
            	finalSpeed *= SprintMultiplier;
        	}
            velocity = velocity.Normalized() * finalSpeed;
        }

        Velocity = velocity; // Assign movement velocity
        MoveAndSlide(); // Move the player using physics-based movement
    }
}
