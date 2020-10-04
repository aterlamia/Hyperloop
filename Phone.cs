using Godot;
using System;

public class Phone : Area2D
{
	private bool sedondTime = false;

	[Signal]
	public delegate void PhoneAwnserd(int time);

	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<SignalManager>("/root/SignalManager").Connect("DisableToilet", this, "enablering");
	}


	private void enablering()
	{
		GetNode<CollisionShape2D>("PhpneSHape").Disabled = false;
		GetNode<AnimatedSprite>("AnimatedSprite").Play();
		sedondTime = true;
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionPressed("action"))
		{
			if (GetOverlappingBodies().Count > 0)
			{
				if (sedondTime == false)
				{
					this.EmitSignal("PhoneAwnserd", 1);

					GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
					GetNode<CollisionShape2D>("PhpneSHape").Disabled = true;
					GetNode<AnimatedSprite>("AnimatedSprite").Stop();
					GetNode<AnimatedSprite>("AnimatedSprite").Frame = 1;


					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"Hello!!! Hello! Somebody there?";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
					Owner.GetNode<Panel>("Control/Panel").Visible = true;
				}
				else
				{
					GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
					GetNode<CollisionShape2D>("PhpneSHape").Disabled = true;
					GetNode<AnimatedSprite>("AnimatedSprite").Stop();
					GetNode<AnimatedSprite>("AnimatedSprite").Frame = 1;
					this.EmitSignal("PhoneAwnserd", 2);
				}

			}
		}
	}
}
