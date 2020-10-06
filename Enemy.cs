using Godot;
using System;
using ld47;

public class Enemy : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	[Export] public Vector2 dest;
	[Export] public Vector2 dest2;
	[Export] public bool turn;
	[Export] public bool initConvo = false;
	[Export] public int id;
	[Export] public int speed = 6000;
	[Export] public Texture speaker1;
	[Export] public Texture speaker2;
	public bool FirstPoint { get; private set; } = false;
	private Vector2 velocity;
	private Timer startTimer;
	private int dialogPos = 1;

	private bool startAction = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		startTimer = new Timer();
		startTimer.OneShot = false;
		startTimer.ProcessMode = Timer.TimerProcessMode.Physics;
		startTimer.WaitTime = 3f;
		startTimer.Connect("timeout", this, "_timer_callback");
		AddChild(startTimer);
		
		GetNode<SignalManager>("/root/SignalManager").Connect("Hide", this, "start");
	}

	private void start()
	{
		startAction = true;
		Visible = true;
	}

	private void _timer_callback()
	{
		if (initConvo)
		{
			Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Visible = true;
			Owner.GetNode<Sprite>("Control/Panel/Panel/portrait").Visible = false;
			Owner.GetNode<Panel>("Control/Panel").Visible = true;
			switch (dialogPos)
			{
				case 1:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"I havebeen thinking";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = speaker1;
					break;
				case 2:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"And yeah you are right";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = speaker1;
					break;
				case 3:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"Backstreet boys was the worse thing that happend to music. But Nsync is a close second";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = speaker1;
					break;
				case 4:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"Finally he comes to his sense and just in time. Anyway, you left all your worldly business in order?";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = speaker2;
					break;
				case 5:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"And here i try to keep the conversation light. \n But yes i did and i am ready to give my life for the [color=red][b]blood god[/b][/color]";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = speaker1;
					break;
				case 6:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"Me too, weird i thought i would be more scared knowing the end nears";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = speaker2;
					break;
				case 7:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"Same for me, about an hour more hour until we are directly under the [color=blue][b]United World headqarters[/b][/color] \n and show them the biggest explotion they have ever seen.";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = speaker1;

					FirstPoint = true;
					GetNode<Enemy>("../Enemy2").FirstPoint = true;
					GetNode<AnimatedSprite>("../Enemy2/AnimatedSprite").Animation = "default";
					GetNode<Enemy>("../Enemy1").FirstPoint = true;
					GetNode<AnimatedSprite>("AnimatedSprite").Animation = "default";
					break;
				case 8:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"I still think [color=red][b]ezekiel's[/b][/color] plan is stupid, we could have blown it up without anybody knowing anything";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = speaker1;

					break;
				case 9:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"Don't speak bad about the prophet, amd you know that [color=red][b]heavens light[/b][/color] needs the money to plan more attacks";
					Owner.GetNode<Sprite>("Control/Panel/Panel/portraitnpc").Texture = speaker2;
					break;
				case 10:
					Owner.GetNode<RichTextLabel>("Control/Panel/Panel/RichTextLabel").BbcodeText =
						"As long as we have hostages they wont do anything";
					break;
			}
		}

		if (dialogPos == 11)
		{
			GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
			Owner.GetNode<Panel>("Control/Panel").Visible = false;
			GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnhidePlayer");
			GetNode<SignalManager>("/root/SignalManager").EmitSignal("UnBlockMovement");
			GetNode<SignalManager>("/root/SignalManager").EmitSignal("DisableToilet");
			GetNode<State>("/root/State").AddState(Statetype.HIDDEN);
			Visible = false;
			startAction = false;
			startTimer.Stop();
			GetParent().RemoveChild(this);
			QueueFree();
		}

		dialogPos++;
	}

	public override void _PhysicsProcess(float delta)
	{
		if (startAction == false)
		{
			return;
		}
		
		velocity = new Vector2();
		GetNode<AnimatedSprite>("AnimatedSprite").FlipH = true;
		velocity.x += 1;

		velocity = velocity.Normalized() * speed;

		if (Position.x >= dest.x && FirstPoint == false)
		{
			if (startTimer.IsStopped())
			{
				startTimer.Start();
			}

			if (turn == true)
			{
				GetNode<AnimatedSprite>("AnimatedSprite").FlipH = false;
			}
			GetNode<AnimatedSprite>("AnimatedSprite").Animation = "idle";

			return;
		}


		if (Position.x >= dest2.x && FirstPoint)
		{
	
			return;
		}

		MoveAndSlide(velocity * delta);
	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
