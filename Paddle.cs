using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
	[Export] public string InputUp = "p1_up";
	[Export] public string InputDown = "p1_down";
	[Export] public float Speed = 420.0f;
	
	public Vector2 PaddleCenter() {return Position;}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		// if (!IsOnFloor())
		// {
		// 	velocity += GetGravity() * (float)delta;
		// }

		// Handle Jump.
		// if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		// {
		// 	velocity.Y = JumpVelocity;
		// }


		velocity.Y = Mathf.MoveToward(velocity.Y, 0, Speed);

		// Vector2 velocity = new Vector2();
		if(Input.IsActionPressed(InputUp))
			velocity.Y -= Speed;
		if(Input.IsActionPressed(InputDown))
			velocity.Y += Speed;
		// GD.Print(Input.IsActionPressed(InputUp));

		// if (direction != Vector2.Zero)
		// {
		// 	velocity.X = direction.X * Speed;
		// }
		// else
		// {
		// 	velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		// }

		Velocity = velocity;
		MoveAndSlide();
	}
}
