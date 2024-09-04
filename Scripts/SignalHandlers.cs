using Godot;
using System;

[GlobalClass]
public partial class SignalHandlers : Node
{
	[Signal]
	public delegate void PassPokemonResourceEventHandler(Pokemon resource);
	[Signal]
	public delegate void ToggleInMenuOnEventHandler();
	[Signal]
	public delegate void ToggleInMenuOffEventHandler();
	[Signal]
	public delegate void AddOranBerryEventHandler(int num);
	[Signal]
	public delegate void UpdateOranBerryTallyEventHandler(int currentNum); 
	[Signal]
	public delegate void EmptyFaintedPokemonTileEventHandler(Vector2I tileLoc);
	[Signal]
	public delegate void SendOranBerryToContainerEventHandler(OranBerry oranBerry);
	[Signal]
	public delegate void PokemonFaintedEventHandler(PokemonScene fainted);
}
