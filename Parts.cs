using Godot;
using System;
using ld47;

public class Parts : KinematicBody2D
{
	private Vector2 velocity;
	private bool run;
	[Export] private float speed = 100;

	private bool canMoveForward = true;
	private bool introFinished = false;
	private bool canMoveBackWards = true;
	private bool canMove = true; 
	private KinematicBody2D upperlayer;

	public override void _Ready()
	{
		GetNode<SignalManager>("/root/SignalManager").Connect("BlockMovement", this, "_blockMovement");
		GetNode<SignalManager>("/root/SignalManager").Connect("UnBlockMovement", this, "_unBlockMovement");
		upperlayer = GetNode<KinematicBody2D>("../PartsForeground");
	}

	private void _blockMovement()
	{
		this.canMove = false;
	}

	private void _unBlockMovement()
	{
		this.canMove = true;
	}


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
		if (introFinished == false || canMove == false)
		{
			return;
		}

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

		if (canMoveBackWards == false && velocity.x < 0)
		{
			velocity.x = 0;
		}


		MoveAndSlide(velocity * delta);
		upperlayer.MoveAndSlide(velocity * delta);
	}


	private void _on_Area2D_body_exited(object body)
	{
		canMoveForward = true;
	}

	private void _on_Area2D_body_entered(object body)
	{
		canMoveForward = false;
	}

	private void _on_Story_IntroFinished()
	{
		introFinished = true;
	}

	private void _on_Blocker_body_entered(object body)
	{
		if (GetNode<State>("/root/State").HasState(Statetype.SLEEP_TALK) == false)
		{
			canMoveBackWards = false;
		}
	}

	private void _on_Blocker_body_exited(object body)
	{
		canMoveBackWards = true;
	}
	
	private void _on_Door2_body_entered(object body)
	{
		
		canMoveBackWards = false;
	}


	private void _on_Door2_body_exited(object body)
	{
		canMoveBackWards = true;
	}

}

