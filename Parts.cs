using Godot;
using System;

public class Parts : KinematicBody2D
{
	private Vector2 velocity;
	private bool run;
	[Export] private float speed = 100;

	private bool canMoveForward = true;

	public override void _Input(InputEvent inputEvent)
	{
		if (inputEvent.IsActionPressed("run"))
		{
			run = true;
		}


		if (inputEvent.IsActionReleased("run"))
		{
			run = false;
		}
	}


	public override void _PhysicsProcess(float delta)
	{
		velocity = new Vector2();
		if (Input.IsActionPressed("ui_right"))
		{
			velocity.x -= 1;
		}

		if (Input.IsActionPressed("ui_left"))
		{
			velocity.x += 1;
		}

		velocity = velocity.Normalized() * speed;

		if (run)
		{
			velocity *= 3f;
		}

		if (canMoveForward == false && velocity.x > 0)
		{
			velocity.x = 0;
		}

		MoveAndSlide(velocity * delta);
	}

	private void _on_Player_body_entered(object body)
	{
		GD.Print(body);
		GD.Print("ent");
	}

	private void _on_Area2D_body_exited(object body)
	{
		canMoveForward = true;
	}

	private void _on_Area2D_body_entered(object body)
	{
		canMoveForward = false;
	}
}
