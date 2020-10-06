using Godot;
using System;

public class bombe : Area2D
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


	private void _on_bombe_body_entered(object body)
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("ShowWarning");
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
	}

	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionJustPressed("action"))
		{
			if (GetOverlappingBodies().Count > 0)
			{
				GetOwner().GetNode<Panel>("Control/Chose").Visible = true;
			}
		}
	}


	private void _on_bombe_body_exited(object body)
	{
		// Replace with function body.
	}
}
