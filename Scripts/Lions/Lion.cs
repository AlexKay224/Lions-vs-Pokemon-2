using Godot;
using System;
using System.Net;

public partial class Lion : PathFollow2D
{
	[Export]
	public LionResource lResource;
	[Export]
	public AnimationPlayer animPlayer;
	[Export]
	public Timer attackTimer;

	private float currentHealth;

	private bool isEating;
	private PokemonScene currentPokemon;
	private SignalHandlers _signalHandlers;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentHealth = lResource.health;
		animPlayer.Play("walk");
		isEating = false;
		_signalHandlers = GetNode<SignalHandlers>("/root/SignalHandlers");

		_signalHandlers.PokemonFainted += clearCurrentPokemon;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!isEating) Progress += lResource.Speed * (float) delta;
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

	public void onCollidePokemon(Node2D pokemon) {
		isEating = true;
		if(pokemon is PokemonScene)
		currentPokemon = (PokemonScene) pokemon;
		attackTimer.Start();
	}

	public void setIsEating(bool e) {
		isEating = e;
	}

	public void onAttackTimeout() {
		currentPokemon.takeDamage(lResource.damage, this);
	}

	//Helper method for _Process - checks if current pokemon is null or has been removed from memory
	public bool isCurrentPokemonValid() {
		if(!IsInstanceValid(currentPokemon)) return true;
		if(currentPokemon is null) return true;
		return false;
	}

	public void clearCurrentPokemon(PokemonScene fainted) {
		if(fainted.Equals(currentPokemon)) {
			currentPokemon = null;
			attackTimer.Stop();
			isEating = false;
		}
	}
}
