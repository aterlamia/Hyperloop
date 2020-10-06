using Godot;
using System;

public class Start : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("load");
	}

	private void _on_Button_pressed()
	{
			GD.Print("load");
	   		GetTree().ChangeScene("res://Train.tscn");
	}

}


