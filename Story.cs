using Godot;
using System;
using ld47;

public class Story : Node2D
{
	[Signal]
	public delegate void IntroFinished();

	private Timer startTimer;


	private int starTimerCalled = 0;
	private int currentPhonePos = 0;
	private bool inPhoneCall = false;
	private int phonecalltime;

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
		if (phonecalltime == 1)
		{
			FirstCall(pos);
		}

		if (phonecalltime == 2)
		{
			SecondCall(pos);
		}
	}

	private void enableMe()
	{
		Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
		Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
	}

	private void enablePhone()
	{
		Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
		Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
	}

	private void SecondCall(int pos)
	{
		Owner.GetNode<Panel>("Control/Panel").Visible = true;
		switch (pos)
		{
			case 1:
				
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = false;
				
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Diane, hare you there?";

				enableMe();
				break;
			case 2:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Finally have been calling this phone for over an hour, I was afraid they got to you";
				enablePhone();
				break;
			case 3:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Have you found anything out that might help us?";
				enablePhone();
				break;
			case 4:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Yes, listen you have to get us off the train fast";
				enableMe();
				break;
			case 6:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"I just overheard two hijackers talk, it seems the randsome is not their main goal";
				enableMe();
				break;
			case 7:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"What!!!";
				enablePhone();
				break;
			case 8:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"They are planning to blow up the loop under the [color=blue][b]United World headqarters[/b][/color]. \n It seems it is a terrorist group called [color=red][b]heavens light[/b][/color] ";
				enableMe();
				break;
			case 9:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"And no mather if you pay they will explode the whole hyperloop.";
				enableMe();
				break;
			case 10:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"[color=red][b]heavens light[/b][/color]!!! [color=red][b]ezekiel's[/b][/color] that basterd. Give me one moment";
				enablePhone();
				break;
			case 11:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Wait were are you going?";
				enableMe();
				break;
			case 12:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Hello!!!";
				enableMe();
				break;
			case 13:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"..........";
				enablePhone();
				break;
			case 14:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"There i am again, i just relayed your information to the task team here \n I have some good and bad news for you.";
				enablePhone();
				break;

			case 15:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"The bad: since they wil not free the people in the loop we will stop the hyperloop before it arrives at the [color=blue][b]United World headqarters[/b][/color] ";
				enablePhone();
				break;

			case 16:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"The good: The safest place to do that without to much damage is not for an another 50 minutes";
				enablePhone();
				break;


			case 17:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"If you can stop them before then ... well no Kaboom";
				enablePhone();
				break;

			case 18:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Shit, they discovered my connection they are disconectuing me, i wont be able to help you with doors anymore";
				enablePhone();
				break;

			case 19:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"bzzzzzzzzzzzzzzzzzzzzzzzzzzz ..... ";
				enablePhone();
				break;
			case 20:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Damn damn damn what now. They cut the line.  I guess i will have to try to dismantle the bomb, but how";
				enableMe();
				break;
			case 21:
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("PhoneDone");
				GetNode<State>("/root/State").AddState(Statetype.PHONE2_DONE);
				Owner.GetNode<Panel>("Control/Panel").Visible = false;
				break;
		}
	}

	private void FirstCall(int pos)
	{
		switch (pos)
		{
			case 1:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Hello!!! Hello! Somebody there?";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 2:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Don't speak, we have to do this quickly. I don't want them to hear you";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 3:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"who a....";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 4:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"What did i just say. Dont speak. I am [color=blue][b]Diane[/b][/color] from the [color=red][b]Main Office of HyperTrans [/b][/color] and ride a37 is being hijacked at this moment ";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 5:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Good stay silent, but yes you are on ride a37. And the first person to actually pick up the phone";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 6:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Now listen very closely as you know you are in a closed hyper loop which makes it hard for us to do somthing about it";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 7:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"We do have protocols for this in which we slow down the hyperloop so we can board it \n Here is were the problem starts.";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 8:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"They have connected explosives to the hyperloop and if it slows down below 600miles an hour  .... well Kaboom ";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 9:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"I am afraid untill we find out what we can do you will be [color=blue][b]stuck in the hyperloop[/b][/color]";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 10:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"We need help from the inside, all doors have automaticlly locked but i can open them for you \n as long as they don't find out.";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;

			case 11:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"Please try and help but do stay safe yourself dont take unnecessary risk \n I will call this phone later if possible try to be here";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = true;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				break;
			case 12:
				Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
					"But ... --BEEP-- --BEEP-- --BEEP-- \n Damn she hung up";
				Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = true;
				Owner.GetNode<Sprite>("Control/Panel/Panel/portraitgirl").Visible = false;
				Owner.GetNode<Panel>("Control/Panel").Visible = true;
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
				GetNode<SignalManager>("/root/SignalManager").EmitSignal("PhoneDone");
				GetNode<State>("/root/State").AddState(Statetype.PHONE_DONE);
				break;
			case 13:
				Owner.GetNode<Panel>("Control/Panel").Visible = false;
				inPhoneCall = false;
				break;
		}
	}

	private void _on_Phone_PhoneAwnserd(int time)
	{
		currentPhonePos = 1;
		inPhoneCall = true;
		phonecalltime = time;
	}
}
