using Godot;
using System;

public partial class pokemon_button : Button
{

	private Pokemon pokemonResource;
	private SignalHandlers _signalHandlers;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<TextureRect>("PokemonImage").Texture = pokemonResource.texture;
		_signalHandlers = GetNode<SignalHandlers>("/root/SignalHandlers");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public Pokemon getPokemonResource() {
		return pokemonResource;
	}

	public void setPokemonResource(Pokemon p) {
		pokemonResource = p;
	}

	public void onButtonDown() {
		_signalHandlers.EmitSignal(nameof(SignalHandlers.PassPokemonResource), pokemonResource);
	}
}
