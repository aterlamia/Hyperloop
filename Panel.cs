using Godot;
using System;

public class Panel : Godot.Panel
{
	public override void _Ready()
	{
	}

	private void _on_Door_body_entered(object body)
	{
		GetNode<RichTextLabel>("Panel/RichTextLabel").Text = "It seems this door is locked \n I cannot go further";
		Visible = true;
	}

	private void _on_Door_body_exited(object body)
	{
		Visible = false;
	}


	private void _on_Blocker_body_entered(object body)
	{
		GetNode<RichTextLabel>("Panel/RichTextLabel").Text = "The shot came from over there I better not go there";
		Visible = true;
	}

	private void _on_Blocker_body_exited(object body)
	{
		Visible = false;
	}
}
