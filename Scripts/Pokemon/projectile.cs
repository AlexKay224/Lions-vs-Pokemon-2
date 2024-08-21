using Godot;
using System;

public partial class Projectile : Area2D
{

	public float damage;
	public float speed;
	public Vector2 direction;

	// Called when the node enters the scene tree for the first time

	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

    public override void _PhysicsProcess(double delta)
    {
        Position += direction * (float) delta;
    }

	public void onHitLion(Area2D lion) {
		Lion lionCast = (Lion) lion.GetParent();
		lionCast.takeDamage(damage);
		QueueFree();
	}

	public void onTimeout() {
		QueueFree();
	}
}
