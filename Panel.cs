using Godot;
using System;
using ld47;

public class Panel : Godot.Panel
{
	public override void _Ready()
	{
	}

	private void _on_Door_body_entered(object body, int door)
	{
		if (GetNode<State>("/root/State").HasState(Statetype.PHONE_DONE) == false && door == 1)
		{
			GetNode<RichTextLabel>("Panel/RichTextLabel").Text = "It seems this door is locked \n I cannot go further";
			Visible = true;
		}

		if (GetNode<State>("/root/State").HasState(Statetype.CORRECT_NPC_TALKED_TO) == false && door == 2)
		{
			GetNode<RichTextLabel>("Panel/RichTextLabel").Text = "It seems this door is locked \n I cannot go further, lets look around";
			Visible = true;
		}
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
