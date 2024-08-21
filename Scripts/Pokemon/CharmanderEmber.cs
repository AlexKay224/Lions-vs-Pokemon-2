using Godot;
using System;

public partial class CharmanderEmber : Projectile
{

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		GetNode<Sprite2D>("ProjectileSprite").GetNode<AnimationPlayer>("AnimationPlayer").Play("flicker");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
