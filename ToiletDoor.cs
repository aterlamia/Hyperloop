using Godot;
using System;
using ld47;

public class ToiletDoor : Area2D
{
	private int dialogPos;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<SignalManager>("/root/SignalManager").Connect("DisableToilet", this, "disableToilet");
	}


	private void disableToilet()
	{
		GetNode<CollisionShape2D>("DoorShape").Disabled = true;
	}
	
	private void _on_ToiletDoor_body_entered(object body)
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("ShowWarning");
		
		dialogPos = 0;
	}


	private void _on_ToiletDoor_body_exited(object body)
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("HideWarning");
		Owner.GetNode<Panel>("Control/Panel").Visible = false;
	}


	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionJustPressed("action"))
		{
			if (GetOverlappingBodies().Count > 0)
			{
				if (GetNode<State>("/root/State").HasState(Statetype.DOOR3))
				{
					GetNode<SignalManager>("/root/SignalManager").EmitSignal("HidePlayer");
					GetNode<SignalManager>("/root/SignalManager").EmitSignal("Hide");
					GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
				} else
				{
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText = "It seems occupied";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
					Owner.GetNode<Panel>("Control/Panel").Visible = true;
				}
			}
		}
	}
}
