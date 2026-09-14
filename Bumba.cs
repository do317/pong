using Godot;
using System;

public partial class Bumba : CharacterBody2D
{

	private Game game;

	private Vector2 velocity; 
	[Export] public float BaseSpeed = 420.0f;
	
	private Vector2 spawnPosition = new Vector2(640, 360);
	public void ResetBall() {
		Position = spawnPosition;
	}
	[Export] private NodePath pathToGame;
	public override void _Ready()
	{ 
		game = GetNode<Game>(pathToGame);
		ResetBall();
		velocity = new Vector2();
		velocity.X = BaseSpeed;
	}

	public void Stop() {
		velocity.X = 0;
		velocity.Y = 0;
	}

	public override void _PhysicsProcess(double delta)
	{
		//Reizina, jo nevisi tick-i ir viena garuma
		var c = MoveAndCollide(velocity * (float)delta);

		if(c != null){
			Vector2 vec = c.GetNormal();
			if(c.GetCollider() is Paddle paddle){
				vec = (paddle.PaddleCenter()-Position);
				vec.Y *= 0.6f;
				vec = vec.Normalized();
			}
			velocity = velocity.Bounce(vec);
		}

		if(Position.X < 0)
			game.OnScore(true);
		else if(Position.X > 1280)
			game.OnScore(false);
	}
}
