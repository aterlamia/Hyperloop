using Godot;
using System;
using ld47;


public class State : Node2D
{

	private Statetype state = 0;

	public void AddState(Statetype statetype)
	{
		state = state | statetype;
	}


	public bool HasState(Statetype statetype)
	{
		return (state & statetype) != Statetype.NONE;
	}
	
	public Statetype GetState()
	{
		return state;
	}
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
}
