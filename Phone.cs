using Godot;
using System;

public class Phone : Area2D
{

	[Signal]
	public delegate void PhoneAwnserd();

	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionPressed("action"))
		{
			if (GetOverlappingBodies().Count > 0)
			{
				this.EmitSignal("PhoneAwnserd");

				GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
				GetNode<CollisionShape2D>("PhpneSHape").Disabled = true;
				GetNode<AnimatedSprite>("AnimatedSprite").Stop();
				GetNode<AnimatedSprite>("AnimatedSprite").Frame = 2;

				
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text = "Hello!!! Hello! Somebody there?";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;

			}
		}
	}
}
