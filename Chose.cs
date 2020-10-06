using Godot;
using System;

public class Chose : Panel
{
	public override void _Ready()
	{
	}

	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://Yay.tscn");
	}


	private void _on_Button2_pressed()
	{
		GetTree().ChangeScene("res://Nay.tscn");
	}
}
