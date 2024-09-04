using Godot;
using System;
using System.Diagnostics;

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
		_signalHandlers = GetNode<SignalHandlers>("/root/SignalHandlers");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void takeDamage(float damage, Lion l) {
		currentHealth -= damage;
		if(currentHealth <= 0) Die(l);
	}

	public void Die(Lion l) {
		_signalHandlers.EmitSignal(nameof(SignalHandlers.EmptyFaintedPokemonTile), tileLoc);
		if(IsInstanceValid(this)) _signalHandlers.EmitSignal(nameof(SignalHandlers.PokemonFainted), this);
		QueueFree();
	}
}
