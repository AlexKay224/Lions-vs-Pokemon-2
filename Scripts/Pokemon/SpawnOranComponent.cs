using Godot;
using System;

public partial class SpawnOranComponent : Node
{
	[Export]
	public PokemonScene pokeRef;
	[Export]
	public Timer timer;

	private PackedScene oranBerry;
	private SignalHandlers _signalHandlers;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_signalHandlers = GetNode<SignalHandlers>("/root/SignalHandlers");
		oranBerry = ResourceLoader.Load<PackedScene>("res://Scenes/Misc/oran_berry.tscn");
		timer.WaitTime = pokeRef.pokemonData.speed;
		timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void onTimeout() {
		OranBerry newBerry = oranBerry.Instantiate<OranBerry>();
		float randX = pokeRef.GlobalPosition.X + GD.Randi() % 10 - 5;
		float randY = pokeRef.GlobalPosition.Y + GD.Randi() % 10 - 5;
		newBerry.GlobalPosition = new Vector2(randX, randY);
		_signalHandlers.EmitSignal(nameof(SignalHandlers.SendOranBerryToContainer), newBerry);
		timer.Start();
	}
}
