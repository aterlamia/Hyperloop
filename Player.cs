using Godot;
using ld47;

public class Player : RigidBody2D
{
	private Vector2 velocity = Vector2.Zero;
	private bool canMoveForward = true;
	[Export] private float speed = 100;
	private bool run = false;

	private Sprite warning;
	private AnimatedSprite animater;

	private bool canMoveBackWards = true;

	private bool canMove = true;

	private void _blockMovement()
	{
		this.canMove = false;
		animater.Animation = "idle";
	}

	private void _unBlockMovement()
	{
		this.canMove = true;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		warning = GetNode<Sprite>("warning");
		animater = GetNode<AnimatedSprite>("PAnimlayer");
		GetNode<SignalManager>("/root/SignalManager").Connect("BlockMovement", this, "_blockMovement");
		GetNode<SignalManager>("/root/SignalManager").Connect("UnBlockMovement", this, "_unBlockMovement");
		GetNode<SignalManager>("/root/SignalManager").Connect("HideWarning", this, "_hideWarning");
		GetNode<SignalManager>("/root/SignalManager").Connect("ShowWarning", this, "_showWarning");
	}

	private void _hideWarning()
	{
		warning.Visible = false;
	}

	private void _showWarning()
	{
		warning.Visible = true;
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
		if (canMove == false)
		{
			return;
			;
		}

		velocity = new Vector2();
		if (Input.IsActionPressed("ui_right"))
		{
			velocity.x += 1;
		}

		if (Input.IsActionPressed("ui_left"))
		{
			velocity.x -= 1;
		}

		velocity = velocity.Normalized() * speed;

		animater.SpeedScale = 1f;
		if (run)
		{
			velocity *= 3f;
			animater.SpeedScale = 2f;
		}

		if (canMoveForward == false && velocity.x < 0)
		{
			animater.Animation = "idle";
		}
		else if (canMoveBackWards == false && velocity.x > 0)
		{
			animater.Animation = "idle";
		}
		else
		{
			if (velocity == Vector2.Zero)
			{
				animater.Animation = "idle";
			}
			else
			{
				animater.Animation = "walking";
			}
		}

		if (velocity.x > 0)
		{
			animater.FlipH = true;
		}
		else if (velocity.x != 0)
		{
			animater.FlipH = false;
		}
	}

	private void _on_Area2D_body_exited(object body)
	{
		if (GetNode<State>("/root/State").HasState(Statetype.PHONE_DONE) == false)
		{

			canMoveForward = true;
		}
		else
		{
			canMoveForward = true;
			warning.Visible = false;            
		}
	}

	private void _on_Area2D_body_entered(object body)
	{
		if (GetNode<State>("/root/State").HasState(Statetype.PHONE_DONE) == false)
		{
			
			canMoveForward = false;
		}
		else
		{
			canMoveForward = false;
			warning.Visible = true;
		}
	}


	private void _on_Phone_body_entered(object body)
	{
		warning.Visible = true;
	}


	private void _on_Phone_body_exited(object body)
	{
		warning.Visible = false;
	}

	private void _on_Blocker_body_entered(object body)
	{
		canMoveBackWards = false;
	}


	private void _on_Blocker_body_exited(object body)
	{
		canMoveBackWards = true;
	}

	private void _on_Phone_PhoneAwnserd()
	{
		warning.Visible = false;
		animater.Animation = "Phone";
		this.canMove = false;
	}
}
