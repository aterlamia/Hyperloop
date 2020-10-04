using Godot;
using System;
using ld47;

public class SpeakerStart : Area2D
{
    private int dialogPos;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    [Export] private Texture texture;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        dialogPos = 0;
    }


    private void _on_SpeakerStart_body_entered(object body)
    {
        GetNode<State>("/root/State").AddState(Statetype.SPEAKER_FIRED);
        GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
    }

    public override void _PhysicsProcess(float delta)
    {
        if (GetOverlappingBodies().Count > 0 && dialogPos == 0)
        {
            Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
            Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = texture;
            dialogPos++;
            GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
            Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
                "Bzzz... is this things on.  ..boop.. bang  ..boop ";
            Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
            Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
            Owner.GetNode<Panel>("Control/Panel").Visible = true;
        }

        if (Input.IsActionJustPressed("action"))
        {
            if (GetOverlappingBodies().Count > 0)
            {
                switch (dialogPos)
                {
                    case 1:
                        GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
                        Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
                            "Ladies and gentlemen, for those that do not know yet today you are our \n involuntary guests";
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
                        Owner.GetNode<Panel>("Control/Panel").Visible = true;
                        break;
                    case 2:
                        GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
                        Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
                            "If you stay at your seat nothing will happen to you unless HyperTrans will meet our demands";
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
                        Owner.GetNode<Panel>("Control/Panel").Visible = true;
                        break;
                    case 3:
                        GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
                        Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
                            "We will not hesitate of making an example of anybody snooping around";
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
                        Owner.GetNode<Panel>("Control/Panel").Visible = true;
                        break;
                    case 4:
                        GetNode<SignalManager>("/root/SignalManager").EmitSignal("BlockMovement");
                        Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
                            "Weird.. no mention of the exposices. Anyway better not let them see me walking around";
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
                        Owner.GetNode<Panel>("Control/Panel").Visible = true;
                        break;
                    case 5:
                        GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
                        Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
                        Owner.GetNode<Panel>("Control/Panel").Visible = false;
                        GetNode<CollisionShape2D>("SpeakerSHape").Disabled = true;
                        break;
                }

                dialogPos++;
            }
        }
    }
}