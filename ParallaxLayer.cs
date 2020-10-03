using Godot;
using System;
[Tool]
public class ParallaxLayer : Godot.ParallaxLayer
{
	[Export]
	private float speed;
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		var offset = MotionOffset;

		offset.x += speed;

		MotionOffset = offset;
	}
}
