using Godot;
using System;

public class Player : RigidBody2D
{
    private Vector2 velocity = Vector2.Zero;
    private bool canMoveForward = true;
    [Export] private float speed = 100;
    private bool run = false;

    private AnimatedSprite animater;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animater = GetNode<AnimatedSprite>("PAnimlayer");
    }


    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("run"))
        {
            run = true;
        }


        if (inputEvent.IsActionReleased("run"))
        {
            run = false;
        }
    }


    public override void _PhysicsProcess(float delta)
    {
        velocity = new Vector2();
        if (Input.IsActionPressed("ui_right"))
        {
            velocity.x += 1;
        }

        if (Input.IsActionPressed("ui_left"))
        {
            velocity.x -= 1;
        }

        velocity = velocity.Normalized() * speed;

        animater.SpeedScale = 1f;
        if (run)
        {
            velocity *= 3f;
            animater.SpeedScale = 2f;
        }

        if (canMoveForward == false && velocity.x < 0)
        {
            animater.Animation = "idle";
        }
        else
        {
            if (velocity == Vector2.Zero)
            {
                animater.Animation = "idle";
            }
            else
            {
                animater.Animation = "walking";
            }
        }

        if (velocity.x > 0)
        {
            animater.FlipH = true;
        }
        else
        {
            animater.FlipH = false;
        }
    }

    private void _on_Area2D_body_exited(object body)
    {
        canMoveForward = true;
    }

    private void _on_Area2D_body_entered(object body)
    {
        canMoveForward = false;
    }


    private void _on_Phone_body_entered(object body)
    {
        GetNode<Sprite>("warning").Visible = true;
    }


    private void _on_Phone_body_exited(object body)
    {
        GetNode<Sprite>("warning").Visible = false;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}