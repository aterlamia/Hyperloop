using Godot;
using System;

public class EnemeyBlock : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionPressed("action"))
		{
			if (GetOverlappingBodies().Count > 0)
			{
				GetParent<Sprite>().Visible = false;
				GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
				GetNode<Sprite>("../../en2idler2").Visible = true;
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("HideWarning");
			}
		}
	}

	private void _on_EnemeyBlock_body_entered(object body)
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("ShowWarning");
	}


	private void _on_EnemeyBlock_body_exited(object body)
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("HideWarning");
	}
}
