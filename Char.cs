using Godot;
using System;
using ld47;

public class Char : Area2D
{
	[Export] private int userId = 0;

	[Export] private Texture texture;


	private int dialogPos = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}


	private void _on_Char_body_entered(object body)
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("ShowWarning");
		dialogPos = 0;
	}


	private void _on_Char_body_exited(object body)
	{
		GetNode<SignalManager>("/root/SignalManager").EmitSignal("HideWarning");
	}


	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionJustPressed("action"))
		{
			if (GetOverlappingBodies().Count > 0)
			{
				
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = texture;

				if (userId == 1)
				{
					ConvoSleep();
				}
				else if (userId == 2)
				{
					ConvoFirst();
				}
				else if (userId == 3)
				{
					ConvoHide();
				}

			}
		}
	}

	private void ConvoHide()
	{
		switch (dialogPos)
		{
			case 0:
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Hey you, i would not continue if i were you..";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 1:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Why not ? what did you see";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 2:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"There were some rough looking guys going that way, and you know what \n I am sure i saw one of them has a gun.";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 3:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Fuck!!!! the hijackers are there as well.";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 4:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"HIJACKERS!!!!";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 5:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"shhhhh you dont want them to hear you, \n yes we are nbeing hijacked.";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 6:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"please stay calm, i am in contact with somebody and am trying to come up with a plan";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 7:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Fuck that i am going to hide";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 8:
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				GetNode<State>("/root/State").AddState(Statetype.CORRECT_NPC_TALKED_TO);
				GetParent<Sprite>().Hide();
				break;
		}

		dialogPos++;
	}

	private void ConvoFirst()
	{
		switch (dialogPos)
		{
			case 0:
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Did you hear that noice just ago? it sounded lke shots.";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 1:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"They wre definitely shots, we are being hijjacked!";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 2:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Hijjacked!!, are you serious? \n damn, well for now we are safe the doors are locked";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 3:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"... hey how did you get here?";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 4:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"... hey how did you get here?";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 5:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Not important, but please stay low, I gotta go.";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 6:
				Owner.GetNode<Panel>("Control/Panel").Visible = false;
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
				break;
		}

		dialogPos++;
	}

	private void ConvoSleep()
	{
		switch (dialogPos)
		{
			case 0:
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"ZZZzzzZZZzzzzzz.... go way i am sleeping";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 1:
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = false;
				break;
		}

		dialogPos++;
	}
}
