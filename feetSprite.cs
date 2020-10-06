using Godot;
using System;

public class feetSprite : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
				GetNode<SignalManager>("/root/SignalManager").Connect("ShowFeet", this, "_showFeet");
	}
	
	private void _showFeet() {
		Visible = true;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
