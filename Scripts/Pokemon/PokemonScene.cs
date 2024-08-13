using Godot;
using System;

public partial class PokemonScene : StaticBody2D
{
	[Export]
	public Pokemon pokemonData;

	private float currentHealth;

	public Vector2I tileLoc;

	private SignalHandlers _signalHandlers;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentHealth = pokemonData.health;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void takeDamage(float damage) {
		currentHealth -= damage;
		if(currentHealth <= 0) Die();
	}

	public void Die() {
		QueueFree();
		_signalHandlers.EmitSignal(nameof(SignalHandlers.EmptyFaintedPokemonTile), tileLoc);
	}
}
