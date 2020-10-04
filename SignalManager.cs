using Godot;
using System;

public class SignalManager : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	
	
	[Signal]
	public delegate void BlockMovement();

	[Signal]
	public delegate void UnBlockMovement();
	
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
