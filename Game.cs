using Godot;
using System;

public partial class Game : Node2D
{
	private int scoreLeft;
	private int scoreRight;
	private Bumba ball;
	private Label score;

	[Export] private NodePath pathToBall;
	[Export] private NodePath pathToScore;
	public override void _Ready() {
		ball = GetNode<Bumba>(pathToBall);
		score = GetNode<Label>(pathToScore);
	}

	public void OnScore(bool leftPlayer) {
		if(leftPlayer)scoreLeft++;
		else scoreRight++;
		ball.ResetBall();
		score.Text = scoreLeft+" : "+scoreRight;

		if(scoreLeft>=5) {win(true); return;}
		if(scoreRight>=5) {win(false); return;}
	}

	private void win(bool leftPlr) {
		ball.Stop();
		score.Text = "Uzvar: " + (leftPlr? "Kreisais" : "Labējais");
		
		var pos = score.Position;
		pos.X += 100;
		score.Position = pos;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
