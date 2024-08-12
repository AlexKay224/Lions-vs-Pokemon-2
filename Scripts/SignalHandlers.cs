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
}
