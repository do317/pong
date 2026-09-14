using Godot;
using System;

public partial class Hello : Node
{
	private int counter = 0;
	private string playerName = "Pong 2.0 Player";
	private Vector2 spawnPosition = new Vector2(640, 360);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{ 
		GD.Print("Sveiks no C#!");
	 GD.Print("counter: "+counter);
	 GD.Print("playerName: "+playerName);
	 GD.Print("spawnPosition: "+spawnPosition);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
