using Godot;
using System;

public class Story : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	[Signal]
	public delegate void IntroFinished();

	private Timer startTimer;


	private int starTimerCalled = 0;
	private int currentPhonePos = 0;
	private bool inPhoneCall = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		startTimer = new Timer();
		startTimer.OneShot = false;
		startTimer.ProcessMode = Timer.TimerProcessMode.Physics;
		startTimer.WaitTime = 0.6f;
		startTimer.Connect("timeout", this, "_timer_callback");
		AddChild(startTimer);
		startTimer.Start();

		currentPhonePos = 1;
	}

	private void _timer_callback()
	{
		switch (starTimerCalled)
		{
			case 4:
			case 9:
				GetNode<Control>("action 1").Visible = true;
				break;
			case 5:
			case 10:
				GetNode<Control>("action 1").Visible = false;
				GetNode<Control>("action 2").Visible = true;
				GetNode<Control>("action 3").Visible = true;
				break;
			case 6:
			case 11:
				GetNode<Control>("action 1").Visible = true;
				GetNode<Control>("action 2").Visible = false;
				GetNode<Control>("action 3").Visible = true;
				break;
			case 7:
			case 12:
				GetNode<Control>("action 1").Visible = false;
				GetNode<Control>("action 2").Visible = false;
				GetNode<Control>("action 3").Visible = true;
				break;
			case 8:
			case 13:
				GetNode<Control>("action 1").Visible = true;
				GetNode<Control>("action 2").Visible = true;
				GetNode<Control>("action 3").Visible = false;
				break;
			case 14:
				GetNode<Control>("action 1").Visible = false;
				GetNode<Control>("action 2").Visible = false;
				GetNode<Control>("action 3").Visible = false;
				break;
			case 17:
				GetNode<Control>("../Control/Panel").Visible = true;
				GetNode<RichTextLabel>("../Control/Panel/Panel/RichTextLabel").Text = "What!!! \n What was that?";
				break;
			case 20:
				GetNode<Control>("../Control").Visible = true;
				GetNode<RichTextLabel>("../Control/Panel/Panel/RichTextLabel").Text = "I better get away from that";

				GetNode<Sprite>("../Train/Parts/maincharsit").Visible = false;
				GetNode<RigidBody2D>("../Train/Player").Visible = true;

				this.EmitSignal("IntroFinished");
				break;
			case 23:
				GetNode<Control>("../Control/Panel").Visible = false;
				break;
			case 30:
				startTimer.Stop();
				break;
		}

		starTimerCalled += 1;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionJustPressed("action") && inPhoneCall)
		{
			PhoneCall(currentPhonePos++);
		}
	}

	private void PhoneCall(int pos)
	{
		switch (pos)
		{
			case 1:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Hello!!! Hello! Somebody there?";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 2:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Don't speak, we have to do this quickly. I don't want them to hear you";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 3:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"who a....";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 4:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"What did i just say. Dont speak. I am diane from the Main Office of HyperTrans and ride a37 is being hijacked at this moment ";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 5:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Good stay silent, but yes you are on ride a37. And the first person to actually pick up the phone";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 6:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Now listen very closely as you know you are in a closed hyper loop which makes it hard for us to do somthing about it";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 7:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"We do have protocols for this in which we slow down the hyperloop so we can board it \n Here is were the problem starts.";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 8:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"They have connected explosives to the hyperloop and if it slows down below 600miles an hour  .... well Kaboom ";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 9:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"We need help from the inside, all doors have automaticlly locked but i can open them for you \n as long as they don't find out.";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			
			case 10:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"Please try and help but do stay safe yourself dont take unnecessary risk \n I will call this phone later if possible try to be here";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 11:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").Text =
					"But ... **BEEP** **BEEP* **BEEP** \n Damn she hung up";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				inPhoneCall = false;
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
				break;
		}
	}

	private void _on_Phone_PhoneAwnserd()
	{
		inPhoneCall = true;
	}
}
