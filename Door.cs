using Godot;
using System;
using ld47;

public class Door : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	[Export] private Texture texture;
	[Export] private int doorNr = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionJustPressed("action"))
		{
			GD.Print(doorNr);
			GD.Print(GetOverlappingBodies().Count);
			if (GetOverlappingBodies().Count > 0 && GetNode<State>("/root/State").HasState(Statetype.PHONE_DONE) &&
			  doorNr == 1)
			{
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("HideWarning");
				GetParent<Sprite>().Texture = texture;


				GetNode<CollisionShape2D>("DoorShape").Disabled = true;
			}

			if (GetOverlappingBodies().Count > 0 && GetNode<State>("/root/State").HasState(Statetype.CORRECT_NPC_TALKED_TO) &&
				doorNr == 2)
			{
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("HideWarning");
				GetParent<Sprite>().Texture = texture;


				GetNode<CollisionShape2D>("DoorShape").Disabled = true;
			}
		}
	}
}
