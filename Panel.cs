using Godot;
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
			GetNode<RichTextLabel>("Panel/RichTextLabel").Text =
				"It seems this door is locked \n I cannot go further, lets look around";
			Visible = true;
		}

		if (GetNode<State>("/root/State").HasState(Statetype.HIDDEN) == false && door == 3)
		{
			GetNode<RichTextLabel>("Panel/RichTextLabel").Text =
				"I hear loud voices on the other side, this cannot be good, i need to hide";
			Visible = true;
			GetNode<State>("/root/State").AddState(Statetype.DOOR3);
			GetNode<SignalManager>("/root/SignalManager").EmitSignal("ActivateToilet");
		}

		if (GetNode<State>("/root/State").HasState(Statetype.HIDDEN) && door == 3)
		{
			GetNode<RichTextLabel>("Panel/RichTextLabel").BbcodeText =
				"Let's go back first i have some information for [color=blue][b]Diane[/b][/color]";
			Visible = true;
			GetNode<State>("/root/State").AddState(Statetype.DOOR3);
		}

		if (door == 4)
		{
			if (GetNode<State>("/root/State").HasState(Statetype.HAS_TOOL))
			{
				GetNode<RichTextLabel>("Panel/RichTextLabel").Text =
					"Maybe i can use the knife to force the door";
				Visible = true;
			}
			else
			{
				GetNode<RichTextLabel>("Panel/RichTextLabel").Text =
					"I realy need a tool for this";
				Visible = true;
			}
		}
	}

	private void _on_Door_body_exited(object body)
	{
		Visible = false;
	}


	private void _on_Blocker_body_entered(object body)
	{
		if (GetNode<State>("/root/State").HasState(Statetype.SLEEP_TALK) == false)
		{
			GetNode<RichTextLabel>("Panel/RichTextLabel").Text = "The shot came from over there I better not go there";
			Visible = true;
		}
	}

	private void _on_Blocker_body_exited(object body)
	{
		Visible = false;
	}
}
