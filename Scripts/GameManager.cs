using Godot;
using System;
using System.Diagnostics;

[GlobalClass]
public partial class GameManager : Node
{
	private SignalHandlers _signalHandlers;
	private bool initSignal;
	private int oranBerryCount;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_signalHandlers = GetNode<SignalHandlers>("/root/SignalHandlers");
		_signalHandlers.AddOranBerry += incrementOranBerry;

		oranBerryCount = 3;
		initSignal = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(!initSignal)	{ _signalHandlers.EmitSignal(nameof(SignalHandlers.UpdateOranBerryTally), oranBerryCount); initSignal = true; }
	}

	public void incrementOranBerry(int num) {
		oranBerryCount += num;
		_signalHandlers.EmitSignal(nameof(SignalHandlers.UpdateOranBerryTally), oranBerryCount);
	}

	public int GetOranCurrency() {
		return oranBerryCount;
	}

	public void reduceOranCurrency(int num) {
		oranBerryCount -= num;
		_signalHandlers.EmitSignal(nameof(SignalHandlers.UpdateOranBerryTally), oranBerryCount);
	}
}
