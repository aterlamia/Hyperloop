using Godot;
using System;
using ld47;

public class feet : Area2D
{
	[Export] private bool oneandonly = false;
	[Export] private Texture text;

	private int dialogPos = 1;
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	private void enableMe()
	{
		Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
		Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
	}

	private void enableNpc()
	{
		Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
		Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
	}

	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionJustPressed("action") && GetNode<State>("/root/State").HasState(Statetype.SLEEP_TALK))
		{
			if (GetOverlappingBodies().Count > 0)
			{
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = text;
				if (oneandonly)
				{
					switch (dialogPos)
					{
						case 1:
							GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
							enableMe();
							Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
								"There you are, i heard you have a pocket knife, can i borrow it";
							break;
						case 2:
							enableNpc();
							Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
								"Shhht don't give me away";
							break;
						case 3:
							enableMe();
							Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
								"Please it is a mather of live and death";
							break;
						case 4:
							enableMe();
							Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
								"Wow that is a big knife, thanks";
							break;
						case 5:
							Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
								"Wow that is a big knife, thanks";
							Owner.GetNode<Panel>("Control/Panel").Visible = false;
							GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
							GetNode<State>("/root/State").AddState(Statetype.HAS_TOOL);
							break;
					}
				}
				else
				{
					switch (dialogPos)
					{
						case 1:
							GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
							enableMe();
							Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
								"He is not here";
							break;
						case 2:
							GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
							Owner.GetNode<Panel>("Control/Panel").Visible = true;
							break;
					}
				}

				dialogPos++;
			}
		}
	}


	private void _on_Area2D_body_entered(object body)
	{
		// Replace with function body.
	}
}
