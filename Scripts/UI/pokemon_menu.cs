using Godot;
using System;

public partial class pokemon_menu : HBoxContainer
{

	private SignalHandlers _signalHandlers;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_signalHandlers = GetNode<SignalHandlers>("/root/SignalHandlers");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void onMenuEntered() {
		_signalHandlers.EmitSignal(nameof(SignalHandlers.ToggleInMenuOn));
	}

	public void onMenuExited() {
		_signalHandlers.EmitSignal(nameof(SignalHandlers.ToggleInMenuOff));	
	}
}
