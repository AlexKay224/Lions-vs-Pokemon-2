using Godot;
using System;

public partial class Lion : PathFollow2D
{
	[Export]
	public LionResource lResource;

	private float currentHealth;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentHealth = lResource.health;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void takeDamage(float damage) {
		currentHealth -= damage;
		if(currentHealth <= 0) {
			Die();
		}
	}

	public void Die() {
		QueueFree();
	}
}