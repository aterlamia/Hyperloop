using Godot;
using System;

public class Train : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private bool bump = false;

	private bool down = false;
	private Vector2? newPos;

	private Vector2 actualPos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		newPos = null;
		actualPos = Position;
	}

	private void _on_Timer_timeout()
	{
		bump = true;
		down = false;
	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _PhysicsProcess(float delta)
	{
		if (bump == true)
		{
			if (newPos == null)
			{
				newPos = Position + new Vector2(0, -3);
				Vector2 testPos = (Vector2) newPos;
				
			}

			Vector2 movePos = (Vector2) newPos;

			if (movePos.y + 0.2f >= Position.y && down == false)
			{
				down = true;
				newPos = actualPos;
			}

			if (actualPos.y - 0.2f <= Position.y && down == true)
			{
				down = false;
				bump = false;
				newPos = null;
			}

			var pos = Position.LinearInterpolate(movePos, 12f * delta);
			Position = pos;
		}


		// position = positionA.linear_interpolate(positionB, min(t, 1.0))
	}
}
